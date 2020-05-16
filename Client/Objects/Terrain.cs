using Framework;
using Framework.Shaders;
using OpenToolkit.Graphics.OpenGL4;
using OpenToolkit.Mathematics;

namespace Client.Objects
{
    public class Terrain : DrawableObject
    {
        private readonly float[] _vertices =
        {
            // Vertex  Textures
            -1, 0, +1, 0, 10, // Top Left
            +1, 0, +1, 10, 10, // Top Right
            +1, 0, -1, 10, 0, // Bottom Right
            -1, 0, -1, 0, 0, // Bottom Left
        };
        
        private readonly Texture _texture;

        public Terrain(Program program) : base(program)
        {
            Program.Use();

            _texture = new Texture(TextureUnit.Texture0, @"D:\Desktop\grass_1.png");
            _texture.Use();
            
            GL.BindVertexArray(Buffers.VertexArray);
            
            GL.BindBuffer(BufferTarget.ArrayBuffer, Buffers.VertexBuffer);
            GL.BufferData(BufferTarget.ArrayBuffer, _vertices.Length * sizeof(float), _vertices, BufferUsageHint.StaticDraw);
            
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 5 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);
            
            GL.VertexAttribPointer(1, 2, VertexAttribPointerType.Float, false, 5 * sizeof(float), 3 * sizeof(float));
            GL.EnableVertexAttribArray(1);
        }

        public void Update()
        {
            Program.Use();

            Program.SetUniformValue("view", Window.Camera.GetViewMatrix());
            Program.SetUniformValue("model", Model);
            Program.SetUniformValue("projection", Window.Camera.GetProjectionMatrix());
        }

        public Matrix4 Model { get; } = Matrix4.CreateScale(10, 0, 10);

        public void Draw()
        {
            Program.Use();
            _texture.Use();
            GL.BindVertexArray(Buffers.VertexArray);
            GL.DrawArrays(PrimitiveType.TriangleFan, 0, 4);
        }
    }
}