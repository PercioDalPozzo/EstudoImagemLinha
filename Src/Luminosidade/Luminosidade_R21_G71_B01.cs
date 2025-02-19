using SixLabors.ImageSharp.PixelFormats;

namespace EstudoImagemLinha;

public class Luminosidade_R21_G71_B01 : ILuminosidade
{
    public double GetLuminosidade(Rgba32 pixelColor)
    {
        return 0.2126 * pixelColor.R +
               0.7152 * pixelColor.G +
               0.0722 * pixelColor.B;
    }
}