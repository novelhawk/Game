using System;
using System.Runtime.CompilerServices;

namespace Framework
{
    public struct GLHandle : IEquatable<GLHandle>
    {
        public static GLHandle MinusOne = new GLHandle(-1);
        public static GLHandle Zero = new GLHandle(0);
        
        private readonly int _id;

        public GLHandle(int id)
        {
            _id = id;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static implicit operator int(GLHandle handle)
        {
            return handle._id;
        }
        
        public static explicit operator GLHandle(int id)
        {
            return new GLHandle(id);
        }
        
        public static bool operator ==(GLHandle left, GLHandle right)
        {
            return left.Equals(right);
        }

        public static bool operator !=(GLHandle left, GLHandle right)
        {
            return !left.Equals(right);
        }
        
        public bool Equals(GLHandle other)
        {
            return _id == other._id;
        }

        public override bool Equals(object obj)
        {
            return obj is GLHandle other && Equals(other);
        }

        public override int GetHashCode()
        {
            return _id.GetHashCode();
        }
    }
}