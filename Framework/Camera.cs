using System;
using OpenTK;

namespace Framework
{
    public class Camera : IWorldObject, IUpdatable
    {
        private Vector3 _front = -Vector3.UnitZ;
        private Vector3 _up = Vector3.UnitY;
        private Vector3 _right = Vector3.UnitX;
        
        private Vector3 _position;
        private float _pitch;
        private float _yaw = -MathHelper.PiOver2;
        private float _fov = MathHelper.Pi - 0.01f;

        private readonly float _aspectRatio;
        
        private IWorldObject _trackedObject;
        private bool _isTracking;

        public Camera(float aspectRatio)
        {
            _aspectRatio = aspectRatio;
        }
        
        public Vector3 Position
        {
            get
            {
                if (_isTracking)
                    return _trackedObject.Position;
                return _position;
            }
            set
            {
                _position = value;
                _isTracking = false;
                _trackedObject = null;
            } 
        }

        public float FieldOfView
        {
            get => MathHelper.RadiansToDegrees(_fov);
            set
            {
                var angle = MathHelper.Clamp(value, 1f, 45f);
                _fov = MathHelper.DegreesToRadians(angle);
            }
        }

        public float Pitch
        {
            get => MathHelper.RadiansToDegrees(_pitch);
            set
            {
                var angle = MathHelper.Clamp(value, -89f, 89f);
                _pitch = MathHelper.DegreesToRadians(angle);
                UpdateVectors();
            }
        }

        public float Yaw
        {
            get => MathHelper.RadiansToDegrees(_yaw);
            set
            {
                _yaw = MathHelper.DegreesToRadians(value);
                UpdateVectors();
            }
        }

        public bool IsDestroyed { get; private set; }
        
        public void Update(float time)
        {
            if (!_isTracking || IsDestroyed)
                return;

            if (_trackedObject is null || _trackedObject.IsDestroyed)
            {
                _isTracking = false;
                return;
            }
            
            _position = _trackedObject.Position;
        }

        public void TrackObject(IWorldObject obj)
        {
            _trackedObject = obj;
            _isTracking = true;
        }

        public Matrix4 GetViewMatrix()
        {
            return Matrix4.LookAt(_position, _position + _front, _up);
        }

        public Matrix4 GetProjectionMatrix()
        {
            return Matrix4.CreatePerspectiveFieldOfView(_fov, _aspectRatio, 0.01f, 100f);
        }
        
        private void UpdateVectors()
        {
            _front = 
                Vector3.Normalize(
                    new Vector3(
                        (float) Math.Cos(_pitch) * (float) Math.Cos(_yaw),
                        (float) Math.Sin(_pitch), 
                        (float) Math.Cos(_pitch) * (float) Math.Sin(_yaw)));
            
            _right = Vector3.Normalize(Vector3.Cross(_front, Vector3.UnitY));
            _up = Vector3.Normalize(Vector3.Cross(_right, _front));
        }

        public void Destroy()
        {
            _trackedObject = null;
            IsDestroyed = true;
        }
    }
}