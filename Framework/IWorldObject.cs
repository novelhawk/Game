using OpenTK;

namespace Framework
{
    public interface IWorldObject : IDestroyable
    {
        Vector3 Position { get; }
    }
}