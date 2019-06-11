using System;
using OpenTK.Graphics.OpenGL4;

namespace Framework.Exceptions
{
    [Serializable]
    public class GLException : Exception
    {
        public GLException() : base("Unexpected error with OpenGL")
        {
        }
    
        public GLException(ErrorCode error) : base($"Error {error} occurred on OpenGL call")
        {
        }

        public GLException(string message) : base(message)
        {
        }
    }
}