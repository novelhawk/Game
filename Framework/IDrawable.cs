using OpenTK;

namespace Framework
{
    public interface IDrawable
    {
        Matrix4 Model { get; }
        
        void Draw();
    }
}