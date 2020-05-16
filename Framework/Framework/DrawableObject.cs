using Framework.Shaders;

namespace Framework
{
    public abstract class DrawableObject
    {
        protected DrawableObject(Program program)
        {
            Program = program;
            Buffers = new GLObjects();
        }

        protected GLObjects Buffers { get; }

        protected Program Program { get; }
    }
}