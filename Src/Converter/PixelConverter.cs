using System.Diagnostics;
using SixLabors.ImageSharp.PixelFormats;

namespace EstudoImagemLinha;

public class PixelConverter 
{
    private readonly ILuminosidade _luminosidade;
    
    public PixelConverter(ILuminosidade luminosidade)
    {
        _luminosidade = luminosidade;
    }        

    public double PixelToFator(Rgba32 pixelColor)
    {
        var luminosidade = _luminosidade.GetLuminosidade(pixelColor);
        var response = 100 - Math.Round(luminosidade / 255 * 100);
        return response;
    }
}