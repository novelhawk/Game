using OpenTK.Graphics.OpenGL4;

namespace Framework.Shaders
{
    public class ShaderComponent
    {
        private ShaderType _shaderType;
        
        public ShaderComponent(ShaderType shaderType)
        {
            _shaderType = shaderType;
        }
    }
}