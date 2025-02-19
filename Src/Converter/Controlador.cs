namespace EstudoImagemLinha;

public class Controlador
{
    private readonly int _imageHeight;
    private readonly int _imageWidth;
    
    private readonly decimal _range;
    
    public int NovoHeight { get; }
    public int NovoWidth { get; }    
    
    public Controlador(int imageHeight, int imageWidth, int resolution)
    {
        _imageHeight = imageHeight;
        _imageWidth = imageWidth;
        
        NovoHeight = resolution * _imageHeight / 100;
        NovoWidth = resolution * _imageWidth / 100;

        _range = (decimal)_imageHeight / NovoHeight;
    }
    
    public (int yInicio, int yFim) GetY(int y)
    {
        var yInicio = ToInt(y * _range);
        var yFim = ToInt((y+1) * _range);
        
        if (yFim >= _imageHeight)
            yFim = _imageHeight-1;

        return (yInicio, yFim);
    }

    public (int xInicio, int xFim) GetX(int x)
    {
        var xInicio = ToInt(x * _range);
        var xFim = ToInt((x+1) * _range);
        
        if (xFim >= _imageWidth)
            xFim = _imageWidth-1;
        
        return (xInicio, xFim);        
    }

    private int ToInt(decimal valor)
    {
        return (int)Math.Truncate(valor);
    }
}