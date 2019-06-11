namespace Framework.ObjectLoader
{
    public struct Model
    {
        private readonly float[] _vertices;
        private readonly float[] _textures;
        private readonly float[] _normals;

        private readonly uint[] _indices;

        public Model(float[] vertices, float[] textures, float[] normals, uint[] indices)
        {
            _vertices = vertices;
            _textures = textures;
            _normals = normals;
            
            _indices = indices;
        }

        public float[] Vertices => _vertices;
        public float[] Textures => _textures;
        public float[] Normals => _normals;
        public uint[] Indices => _indices;
    }
}