using System;
using OpenToolkit.Graphics.OpenGL4;

namespace Framework.Exceptions
{
    [Serializable]
    public class GLException : Exception
    {
        public GLException() : base("Unexpected error with OpenGL")
        {
        }
    
        public GLException(ErrorCode error, string longMessage = null) : base($"Error {error} occurred on OpenGL call")
        {
            LongMessage = longMessage;
        }

        public GLException(string message, string longMessage = null) : base(message)
        {
            LongMessage = longMessage;
        }
        
        public string LongMessage { get; }
    }
}