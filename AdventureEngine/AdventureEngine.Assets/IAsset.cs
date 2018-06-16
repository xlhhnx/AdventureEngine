
namespace AdventureEngine.AssetManagement
{
    public interface IAsset
    {
        string Id { get; }
        bool Loaded { get; }

        void Unload();
    }
}