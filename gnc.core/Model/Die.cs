namespace d9.gnc.core.Model;

public class Die(int maxFace, Random? random = null)
{
    public int MaxFace => maxFace;
    private Random Random = random ?? new();
    public override string ToString()
        => $"d{MaxFace}";
    public int Roll()
        => Random.Next(1, MaxFace + 1);
}
