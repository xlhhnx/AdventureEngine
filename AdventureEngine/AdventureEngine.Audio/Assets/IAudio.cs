using AdventureEngine.AssetManagement;
using AdventureEngine.AssetManagement.Assets;

namespace AdventureEngine.AudioManagement.Assets
{
    public interface IAudio : IAsset
    {
        AudioAsset AudioAsset { get; }
    }
}