using System;
using Client.Objects;
using Framework;
using Framework.Shaders;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL4;

namespace Client
{
    public class Window : GameWindow
    {
        public static Camera Camera { get; private set; }
        
        public Window() : base(
            1280,
            720,
            GraphicsMode.Default,
            "Client",
            GameWindowFlags.Default,
            DisplayDevice.Default,
            4, 2,
            GraphicsContextFlags.Default)
        {
            VSync = VSyncMode.On;
        }

        private Terrain _terrain;
        protected override void OnLoad(EventArgs e)
        {
            Startup.AttachLogger();
            GL.ClearColor(Color4.DarkTurquoise);
            
            var shader = new Shader("Shaders/textured.vert", "Shaders/textured.frag");
            
            Camera = new Camera(1280 / 720f);
            Camera.Position = new Vector3(0, 0, -3);
            
            _terrain = new Terrain(shader);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            Camera.Update((float) e.Time);
            _terrain.Update();
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);
            
            _terrain.Draw();
            
            SwapBuffers();
        }
    }
}