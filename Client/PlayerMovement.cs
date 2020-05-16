using Framework;
using OpenToolkit.Windowing.Common;
using OpenToolkit.Windowing.Common.Input;

namespace Client
{
    public class PlayerMovement
    {
        private readonly Camera _camera;
        
        public PlayerMovement(Camera camera)
        {
            _camera = camera;
        }

        public void OnKeyDown(KeyboardKeyEventArgs e)
        {
            const float cameraSpeed = 4;
            
            switch (e.Key)
            {
                case Key.W:
                    _camera.Position += _camera.Front * cameraSpeed; // Forward 
                    break;
                case Key.S:
                    _camera.Position -= _camera.Front * cameraSpeed; // Backwards
                    break;
                case Key.A:
                    _camera.Position -= _camera.Right * cameraSpeed; // Left
                    break;
                case Key.D:
                    _camera.Position += _camera.Right * cameraSpeed; // Right
                    break;
                case Key.E:
                case Key.Space:
                    _camera.Position += _camera.Up * cameraSpeed; // Up
                    break;
                case Key.Q:
                case Key.ShiftLeft:
                    _camera.Position -= _camera.Up * cameraSpeed; // Down
                    break;
            }
        }

        public void OnMouseMove(MouseMoveEventArgs e)
        {
            const float sensitivity = 1;
            
            // Apply the camera pitch and yaw (we clamp the pitch in the camera class)
            _camera.Yaw += e.DeltaX * sensitivity;
            _camera.Pitch -= e.DeltaY * sensitivity; // reversed since y-coordinates range from bottom to top
        }
    }
}