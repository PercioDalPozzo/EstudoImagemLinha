using SixLabors.ImageSharp.PixelFormats;

namespace EstudoImagemLinha;

public class Luminosidade_R1_G8_B1 : ILuminosidade
{
    public double GetLuminosidade(Rgba32 pixelColor)
    {
        return 0.1 * pixelColor.R +
               0.8 * pixelColor.G +
               0.1 * pixelColor.B;
    }
}