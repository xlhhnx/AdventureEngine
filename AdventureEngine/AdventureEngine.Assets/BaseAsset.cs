namespace AdventureEngine.AssetManagement
{
    public abstract class BaseAsset : IAsset
    {
        public virtual string Id { get { return _id; } }
        public abstract bool Loaded { get; }

        protected string _id;

        public BaseAsset(string id)
        {
            _id = id;
        }

        public abstract void Unload();
    }
}