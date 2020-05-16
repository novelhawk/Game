using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using Framework.Exceptions;
using OpenToolkit.Graphics.OpenGL4;

namespace Framework.Shaders
{
    public class ProgramBuilder
    {
        private readonly int _handle;
        private readonly List<int> _shaders = new List<int>(6);

        public ProgramBuilder()
        {
            _handle = GL.CreateProgram();
#if GL_ERRORS_CHECK
            if (_handle <= 0)
                throw new Exception("Failed to create program");            
#endif
        }

        public ProgramBuilder WithShader(ShaderType type, string source)
        {
            var shader = GL.CreateShader(type);
            GL.ShaderSource(shader, source);
            GL.CompileShader(shader);
            CheckShaderCompilationErrors(shader);
            
            _shaders.Add(shader);
            return this;
        }

        public ProgramBuilder WithFileShader(ShaderType type, string path)
        {
            var source = File.ReadAllText(path);

            return WithShader(type, source);
        }

        public Program Build()
        {
            foreach (var shader in _shaders)
            {
                GL.AttachShader(_handle, shader);
            }
            
            GL.LinkProgram(_handle);
            CheckProgramLinkErrors();

            foreach (var shader in _shaders)
            {
                GL.DetachShader(_handle, shader);
                GL.DeleteShader(shader);
            }
            
            return new Program(_handle);
        }

        [Conditional("GL_ERRORS_CHECK")]
        private static void CheckShaderCompilationErrors(int shader)
        {
            GL.GetShader(shader, ShaderParameter.CompileStatus, out var code);
            if (code == (int) All.True) 
                return;
            
            var errorLog = GL.GetShaderInfoLog(shader);
            throw new GLException($"Error occurred whilst compiling Shader({shader})", errorLog);
        }

        [Conditional("GL_ERRORS_CHECK")]
        private void CheckProgramLinkErrors()
        {
            GL.GetProgram(_handle, GetProgramParameterName.LinkStatus, out var code);
            if (code == (int) All.True) 
                return;
            
            var errorLog = GL.GetProgramInfoLog(_handle);
            throw new GLException($"Error occurred whilst linking Program({_handle})", errorLog);
        }
    }
}