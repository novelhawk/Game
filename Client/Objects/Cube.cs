using Framework;
using Framework.Shaders;
using OpenTK;
using OpenTK.Audio.OpenAL;
using OpenTK.Graphics.OpenGL4;

namespace Client.Objects
{
    public class Cube : DrawableObject
    {
        public Vector3 Position { get; }
        public Matrix4 Model { get; }

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
            0, 1, 2, 3, // Front
            4, 5, 6, 7, // Back
            1, 2, 6, 5, // Right
            0, 3, 7, 4, // Left
            0, 1, 5, 4, // Top
            2, 3, 7, 6, // Bottom
        };

        public Cube(Shader shader) : base(shader)
        {
            Shader.Use();
            GL.BindVertexArray(GLObjects.VertexArray);
            
            GL.BindBuffer(BufferTarget.ArrayBuffer, GLObjects.VertexBuffer);
            GL.BufferData(BufferTarget.ArrayBuffer, _vertices.Length * sizeof(float), _vertices, BufferUsageHint.StaticDraw);
            
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, GLObjects.ElementBuffer);
            GL.BufferData(BufferTarget.ElementArrayBuffer, _indices.Length * sizeof(uint), _indices, BufferUsageHint.StaticDraw);
            
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);
        }

        public void Update()
        {
            Shader.Use();
            
            Shader.SetMatrix4("model", Matrix4.Identity);
            Shader.SetMatrix4("view", Matrix4.Identity);
            Shader.SetMatrix4("projection", Matrix4.Identity);
        }

        public void Draw()
        {
            Shader.Use();
            GL.BindVertexArray(GLObjects.VertexArray);
            GL.DrawElements(PrimitiveType.Triangles, _indices.Length, DrawElementsType.UnsignedInt, 0);
        }
    }
}