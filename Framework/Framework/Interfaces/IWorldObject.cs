using OpenToolkit.Mathematics;

namespace Framework.Interfaces
{
    public interface IWorldObject : IDestroyable
    {
        Vector3 Position { get; }
    }
}