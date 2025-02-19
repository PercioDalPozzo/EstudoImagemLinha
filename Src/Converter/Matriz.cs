namespace EstudoImagemLinha;

public class Matriz
{
    public readonly int Resolution;

    public Matriz(int resolution)
    {
        Resolution = resolution;
    }

    public IList<Coordenada> Coordenadas { get; } = new List<Coordenada>();
    
    public void Add(int x, int y, double luminosidade)
    {
        Coordenadas.Add(new Coordenada(x, y, luminosidade));
    }
}

public record Coordenada(int X, int Y, double Luminosidade){
}