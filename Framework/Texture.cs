using OpenTK.Graphics.OpenGL4;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Advanced;
using SixLabors.ImageSharp.Processing;

namespace Framework
{
    public class Texture
    {
        private readonly GLHandle _handle;
        private readonly TextureUnit _unit;

        public Texture(TextureUnit unit, string path)
        {
            _unit = unit;
            
            _handle = (GLHandle) GL.GenTexture();
            
            GL.ActiveTexture(unit);
            GL.BindTexture(TextureTarget.Texture2D, _handle);

            using (var image = Image.Load(path))
            {
                image.Mutate(x => x.Flip(FlipMode.Vertical));
                
                GL.TexImage2D(
                    TextureTarget.Texture2D, 
                    0, 
                    PixelInternalFormat.Rgba, 
                    image.Width, image.Height, 
                    0,
                    PixelFormat.Rgba, 
                    PixelType.UnsignedByte,
                    image.GetPixelSpan().ToArray());
            }
            
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int) TextureMinFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int) TextureMagFilter.Linear);
            
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int) TextureWrapMode.Repeat);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int) TextureWrapMode.Repeat);
            
            GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);
        }

        public void Use()
        {
            GL.ActiveTexture(_unit);
            GL.BindTexture(TextureTarget.Texture2D, _handle);
        }
    }
}