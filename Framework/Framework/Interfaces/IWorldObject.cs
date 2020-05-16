using OpenToolkit.Mathematics;

namespace Framework
{
    public interface IWorldObject : IDestroyable
    {
        Vector3 Position { get; }
    }
}