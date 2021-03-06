namespace Framework.Interfaces
{
    public interface IDestroyable
    {
        bool IsDestroyed { get; }
        void Destroy();
    }
}