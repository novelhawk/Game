using System;
using Client.Objects;
using Framework;
using Framework.Shaders;
using OpenToolkit.Graphics.OpenGL4;
using OpenToolkit.Mathematics;
using OpenToolkit.Windowing.Common;
using OpenToolkit.Windowing.Desktop;

namespace Client
{
    public class Window : GameWindow
    {
        private Terrain _terrain;
        private PlayerMovement _movement;
        private Cube _cube;
        
        public Window() : base(GameWindowSettings.Default, NativeWindowSettings)
        {
            Load += OnLoad;
        }

        private static NativeWindowSettings NativeWindowSettings =>
            new NativeWindowSettings
            {
                Title = "Client",
                Size = new Vector2i(1280, 720),
                APIVersion = new Version(4, 2),
                Profile = ContextProfile.Core
            };
        
        public static Camera Camera { get; private set; }

        private new void OnLoad()
        {
            Startup.AttachLogger();
            
            GL.ClearColor(Color4.DarkTurquoise);
            GL.Enable(EnableCap.DepthTest);
            
            var untextured = new ProgramBuilder()
                .WithFileShader(ShaderType.VertexShader, "./Shaders/main.vert")
                .WithFileShader(ShaderType.FragmentShader, "./Shaders/main.frag")
                .Build();
            
            var textured = new ProgramBuilder()
                .WithFileShader(ShaderType.VertexShader, "./Shaders/textured.vert")
                .WithFileShader(ShaderType.FragmentShader, "./Shaders/textured.frag")
                .Build();
            
            Camera = new Camera(1280 / 720f);
            Camera.Position = new Vector3(0, 1, 0);
            Camera.Pitch = -90;
            
            _terrain = new Terrain(textured);
            RenderFrame += _terrain.Draw;
            UpdateFrame += _terrain.Update;
            
            _movement = new PlayerMovement(Camera);
            KeyDown += _movement.OnKeyDown;
            MouseMove += _movement.OnMouseMove;
            
            _cube = new Cube(untextured);
            RenderFrame += _cube.Draw;
            UpdateFrame += _cube.Update;
            
            Camera.TrackObject(_cube);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            
            base.OnRenderFrame(e);
            
            GL.Flush();
            SwapBuffers();
        }
    }
}