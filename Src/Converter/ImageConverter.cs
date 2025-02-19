using System.Text;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;

namespace EstudoImagemLinha;

public class ImageConverter
{
    private readonly Image<Rgba32> _image;

    public ImageConverter(Image<Rgba32> image)
    {
        _image = image;
    }

    public Matriz Convert(PixelConverter pixelConverter, int resolution)
    {
        var matriz = new Matriz(resolution);

        var controlador = new Controlador(_image.Height, _image.Width, resolution);
        
        for (int y = 0; y < controlador.NovoHeight; y++)
        {
            var (yInicio, yFim) = controlador.GetY(y);
            for (int x = 0; x < controlador.NovoWidth; x++)
            {
                var (xInicio, xFim) = controlador.GetX(x);
                var pixelColor = BuildPixel(_image, yInicio, xInicio, yFim, xFim);
                matriz.Add(x,y, pixelConverter.PixelToFator(pixelColor));
            }
        }
        return matriz;        
        
        // var matriz = new Matriz(resolution);
        //
        // var controlador = new Controlador(_image.Height, _image.Width, resolution);
        //
        // for (int y = 0; y < controlador.NovoHeight; y++)
        // {
        //     var (yInicio, yFim) = controlador.GetY(y);
        //     for (int x = 0; x < controlador.NovoWidth; x++)
        //     {
        //         var (xInicio, xFim) = controlador.GetX(x);
        //         var pixelColor = BuildPixel(_image, yInicio, xInicio, yFim, xFim);
        //         matriz.Add(x,y, pixelConverter.PixelToChar(pixelColor));
        //     }
        // }
        // return matriz;
    }

    private Rgba32 BuildPixel(Image<Rgba32> image, int yInicio, int xInicio, int yFim, int xFim)
    {
        var pixels = new List<Rgba32>();
        for (int y = yInicio; y <= yFim; y++)
        {
            for (int x = xInicio; x <= xFim; x++)
            {
                pixels.Add(image[x, y]);
            }
        }
        return PixelMedio(pixels);
    }

    private Rgba32 PixelMedio(List<Rgba32> pixels)
    {
        if (pixels == null || pixels.Count == 0)
        {
            throw new ArgumentException("A lista de pixels vazia.", nameof(pixels));
        }

        byte CalcularMedia(Func<Rgba32, byte> seletor)
        {
            return (byte)(pixels.Sum(p => seletor(p)) / (float)pixels.Count);
        }
        
        var r = CalcularMedia(p => p.R);
        var g = CalcularMedia(p => p.G);
        var b = CalcularMedia(p => p.B);
        
        return new Rgba32(r, g, b);
    }
}