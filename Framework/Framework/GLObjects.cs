using OpenToolkit.Graphics.OpenGL4;

namespace Framework
{
    public class GLObjects
    {
        private GLHandle _vertexBuffer = GLHandle.MinusOne;
        private GLHandle _elementBuffer = GLHandle.MinusOne;
        private GLHandle _colorBuffer = GLHandle.MinusOne;
        private GLHandle _textureBuffer = GLHandle.MinusOne;
        private GLHandle _vertexArray = GLHandle.MinusOne;

        public int VertexBuffer
        {
            get
            {
                if (_vertexBuffer == GLHandle.MinusOne)
                    _vertexBuffer = (GLHandle) GL.GenBuffer(); 
                return _vertexBuffer;
            }
        }

        public int ColorBuffer
        {
            get
            {
                if (_colorBuffer == GLHandle.MinusOne)
                    _colorBuffer = (GLHandle) GL.GenBuffer(); 
                return _colorBuffer;
            }
        }

        public int ElementBuffer
        {
            get
            {
                if (_elementBuffer == GLHandle.MinusOne)
                    _elementBuffer = (GLHandle) GL.GenBuffer(); 
                return _elementBuffer;
            }
        }

        public int TextureBuffer
        {
            get
            {
                if (_textureBuffer == GLHandle.MinusOne)
                    _textureBuffer = (GLHandle) GL.GenBuffer(); 
                return _textureBuffer;
            }
        }

        public int VertexArray
        {
            get
            {
                if (_vertexArray == GLHandle.MinusOne)
                    _vertexArray = (GLHandle) GL.GenVertexArray(); 
                return _vertexArray;
            }
        }
    }
}
