using SixLabors.ImageSharp.PixelFormats;

namespace EstudoImagemLinha;

public interface ILuminosidade
{
    double GetLuminosidade(Rgba32 pixelColor);
}