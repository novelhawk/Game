using Framework;
using Framework.Shaders;
using OpenTK;
using OpenTK.Graphics.OpenGL4;

namespace Client.Objects
{
    public class Terrain : DrawableObject, IDrawable, IWorldObject
    {
        private readonly float[] _vertices =
        {
            // Vertex  Textures
            -1, 0, +1, 0, 1, // Top Left
            +1, 0, +1, 1, 1, // Top Right
            +1, 0, -1, 1, 0, // Bottom Right
            -1, 0, -1, 0, 0, // Bottom Left
        };
        
        private readonly Texture _texture;

        public Terrain(Shader shader) : base(shader)
        {
            Shader.Use();

            _texture = new Texture(TextureUnit.Texture0, @"C:\Users\utente\Desktop\Assets\Textures\grass_1.png");
            _texture.Use();
            
            GL.BindVertexArray(GLObjects.VertexArray);
            
            GL.BindBuffer(BufferTarget.ArrayBuffer, GLObjects.VertexBuffer);
            GL.BufferData(BufferTarget.ArrayBuffer, _vertices.Length * sizeof(float), _vertices, BufferUsageHint.StaticDraw);
            
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 5 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);
            
            GL.VertexAttribPointer(1, 2, VertexAttribPointerType.Float, false, 5 * sizeof(float), 3 * sizeof(float));
            GL.EnableVertexAttribArray(1);
        }

        public void Update()
        {
            Shader.Use();

            Shader.SetMatrix4("view", Window.Camera.GetViewMatrix());
            Shader.SetMatrix4("model", Model);
            Shader.SetMatrix4("projection", Window.Camera.GetProjectionMatrix());
        }

        public Matrix4 Model { get; } = Matrix4.CreateScale(0.2f, 0.2f, 0.2f);

        public void Draw()
        {
            Shader.Use();
            _texture.Use();
            GL.BindVertexArray(GLObjects.VertexArray);
            GL.DrawArrays(PrimitiveType.TriangleFan, 0, 4);
        }

        public bool IsDestroyed { get; }
        public void Destroy()
        {
            throw new System.NotImplementedException();
        }

        public Vector3 Position { get; }
    }
}