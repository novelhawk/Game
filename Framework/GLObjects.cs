using OpenTK.Graphics.OpenGL4;

namespace Framework
{
    public class GLObjects
    {
        private GLHandle? _vertexArray;
        private GLHandle? _vertexBuffer;
        private GLHandle? _elementBuffer;

        public GLHandle VertexArray
        {
            get
            {
                if (!_vertexArray.HasValue)
                    _vertexArray = (GLHandle) GL.GenVertexArray();
                return _vertexArray.Value;
            }
        }

        public GLHandle VertexBuffer
        {
            get
            {
                if (!_vertexBuffer.HasValue)
                    _vertexBuffer = (GLHandle) GL.GenBuffer();
                return _vertexBuffer.Value;
            }
        }

        public GLHandle ElementBuffer
        {
            get
            {
                if (!_elementBuffer.HasValue)
                    _elementBuffer = (GLHandle) GL.GenBuffer();
                return _elementBuffer.Value;
            }
        }
    }
}