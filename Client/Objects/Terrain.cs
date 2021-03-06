using Framework;
using Framework.Shaders;
using OpenToolkit.Graphics.OpenGL4;
using OpenToolkit.Mathematics;
using OpenToolkit.Windowing.Common;

namespace Client.Objects
{
    public class Terrain : DrawableObject
    {
        private readonly Texture _texture;
        
        private readonly float[] _vertices =
        {
            // Vertex, Textures
            -1, 0, +1,    0, 10, // Top Left
            +1, 0, +1,   10, 10, // Top Right
            +1, 0, -1,   10,  0, // Bottom Right
            -1, 0, -1,    0,  0, // Bottom Left
        };

        public Terrain(Program program) : base(program)
        {
            Program.Use();

            _texture = new Texture(TextureUnit.Texture0, @"D:\Desktop\grass_1.png");
            _texture.Use();
            
            GL.BindVertexArray(Buffers.VertexArray);
            
            GL.BindBuffer(BufferTarget.ArrayBuffer, Buffers.VertexBuffer);
            GL.BufferData(BufferTarget.ArrayBuffer, 
                size: _vertices.Length * sizeof(float),
                data: _vertices,
                usage: BufferUsageHint.StaticDraw);
            
            GL.EnableVertexAttribArray(0);
            GL.VertexAttribPointer(
                index: 0,
                size: 3,
                type: VertexAttribPointerType.Float,
                normalized: false,
                stride: 5 * sizeof(float),
                offset: 0);
            
            GL.EnableVertexAttribArray(1);
            GL.VertexAttribPointer(
                index: 1,
                size: 2,
                type: VertexAttribPointerType.Float,
                normalized: false,
                stride: 5 * sizeof(float),
                offset: 3 * sizeof(float));
        }

        public override Matrix4 Model { get; } = Matrix4.CreateScale(10, 0, 10);

        public override void Draw(FrameEventArgs e)
        {
            Program.Use();
            _texture.Use();
            GL.BindVertexArray(Buffers.VertexArray);
            GL.DrawArrays(PrimitiveType.TriangleFan, 0, 4);
        }

        public override void Update(FrameEventArgs e)
        {
            Program.Use();

            Program.SetUniformValue("view", Window.Camera.GetViewMatrix());
            Program.SetUniformValue("model", Model);
            Program.SetUniformValue("projection", Window.Camera.GetProjectionMatrix());
        }
    }
}