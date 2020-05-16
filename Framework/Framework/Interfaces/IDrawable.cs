using OpenToolkit.Mathematics;

namespace Framework
{
    public interface IDrawable
    {
        Matrix4 Model { get; }
        
        void Draw();
    }
}