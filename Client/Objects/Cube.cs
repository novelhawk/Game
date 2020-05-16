using Framework;
using Framework.Shaders;
using OpenToolkit.Graphics.OpenGL4;
using OpenToolkit.Mathematics;

namespace Client.Objects
{
    public class Cube : DrawableObject, IWorldObject
    {
        public Vector3 Position { get; private set; }
        public Matrix4 Model { get; private set; }

        private readonly float[] _vertices =
        {
            -1, +1, -1, // [Front] Top Left
            +1, +1, -1, // [Front] Top Right
            +1, -1, -1, // [Front] Bottom Right
            -1, -1, -1, // [Front] Bottom Left
            -1, +1, +1, // [Back] Top Left
            +1, +1, +1, // [Back] Top Right
            +1, -1, +1, // [Back] Bottom Right
            -1, -1, +1, // [Back] Bottom Left
        };

        private readonly uint[] _indices =
        {
            // Front
            0, 1, 2,
            0, 2, 3,
            
            // Back
            4, 5, 6, 
            4, 6, 7,
            
            // Right
            1, 2, 6, 
            1, 5, 6,
            
            // Left
            0, 3, 7, 
            0, 7, 4,
            
            // Top
            0, 1, 5, 
            0, 5, 4,
            
            // Bottom
            2, 3, 7, 
            2, 7, 6
        };

        public Cube(Program program) : base(program)
        {
            Program.Use();
            
            GL.BindVertexArray(Buffers.VertexArray);
            
            GL.BindBuffer(BufferTarget.ArrayBuffer, Buffers.VertexBuffer);
            GL.BufferData(BufferTarget.ArrayBuffer, _vertices.Length * sizeof(float), _vertices, BufferUsageHint.StaticDraw);
            
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, Buffers.ElementBuffer);
            GL.BufferData(BufferTarget.ElementArrayBuffer, _indices.Length * sizeof(uint), _indices, BufferUsageHint.StaticDraw);
            
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);
        }

        public void Update()
        {
            Program.Use();

            Position += Vector3.UnitX / 200;
            Model = Matrix4.CreateTranslation(Position);
            
            Program.SetUniformValue("view", Window.Camera.GetViewMatrix());
            Program.SetUniformValue("model", Model);
            Program.SetUniformValue("projection", Window.Camera.GetProjectionMatrix());
        }

        public void Draw()
        {
            Program.Use();
            GL.BindVertexArray(Buffers.VertexArray);
            GL.DrawElements(PrimitiveType.Triangles, _indices.Length, DrawElementsType.UnsignedInt, 0);
        }

        public bool IsDestroyed { get; }
        public void Destroy()
        {
            throw new System.NotImplementedException();
        }
    }
}