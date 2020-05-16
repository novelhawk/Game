using System;
using Framework.Exceptions;
using OpenToolkit.Graphics.OpenGL4;
using OpenToolkit.Mathematics;

namespace Framework.Shaders
{
    public class Program : IDisposable
    {
        private readonly int _handle;
        private bool _disposed;

        internal Program(int handle)
        {
            _handle = handle;
        }

        public static Program FromHandle(int handle)
        {
            if (handle <= 0)
                throw new ArgumentException("Handle must be greater than zero", nameof(handle));
            return new Program(handle);
        }

        public void Use() => Bind();
        
        public void Bind()
        {
            GL.UseProgram(_handle);
        }
        
        public int GetAttribLocation(string attrib)
        {
            return GL.GetAttribLocation(_handle, attrib);
        }

        public int GetUniformLocation(string uniform)
        {
            return GL.GetUniformLocation(_handle, uniform);
        }

        public void SetUniformValue(string attrib, float data)
        {
            var loc = GetUniformLocation(attrib);
            if (loc < 0)
                throw new GLException($"Could not find Uniform({attrib})");
            SetUniformValue(loc, data);
        }
        
        public void SetUniformValue(int location, float data)
        {
            GL.Uniform1(location, data);
        }

        public void SetUniformValue(string attrib, Vector3 data)
        {
            var loc = GetUniformLocation(attrib);
            if (loc < 0)
                throw new GLException($"Could not find Uniform({attrib})");
            SetUniformValue(loc, data);
        }
        
        public void SetUniformValue(int location, Vector3 data)
        {
            GL.Uniform3(location, data);
        }

        public void SetUniformValue(string attrib, int data)
        {
            var loc = GetUniformLocation(attrib);
            if (loc < 0)
                throw new GLException($"Could not find Uniform({attrib})");
            SetUniformValue(loc, data);
        }
        
        public void SetUniformValue(int location, int data)
        {
            GL.Uniform1(location, data);
        }
        
        public void SetUniformValue(string attrib, ref Matrix4 data)
        {
            var loc = GetUniformLocation(attrib);
            if (loc < 0)
                throw new GLException($"Could not find Uniform({attrib})");
            SetUniformValue(loc, ref data);
        }
        
        public void SetUniformValue(string attrib, Matrix4 data)
        {
            var loc = GetUniformLocation(attrib);
            if (loc < 0)
                throw new GLException($"Could not find Uniform({attrib})");
            SetUniformValue(loc, ref data);
        }
        
        public void SetUniformValue(int location, ref Matrix4 data)
        {
            GL.UniformMatrix4(location, false, ref data);
        }
        
        public void SetUniformValue(int location, Matrix4 data)
        {
            GL.UniformMatrix4(location, false, ref data);
        }

        public void Dispose()
        {
            if (!_disposed)
                GL.DeleteProgram(_handle);
            
            _disposed = true;
        }
    }
}