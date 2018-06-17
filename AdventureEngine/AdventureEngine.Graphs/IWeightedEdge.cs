namespace AdventureEngine.Graphing
{
    public interface IWeightedEdge : IEdge
    {
        float Weight { get; set; }
    }
}