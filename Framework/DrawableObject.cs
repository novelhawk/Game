using Framework.Shaders;

namespace Framework
{
    public abstract class DrawableObject
    {
        private readonly GLObjects _objects;
        private readonly Shader _shader;
        
        public DrawableObject(Shader shader)
        {
            _shader = shader;
            _objects = new GLObjects();
        }

        protected GLObjects GLObjects => _objects;
        protected Shader Shader => _shader;
    }
}