namespace Framework.ObjectLoader
{
    public struct Face
    {
        private readonly int[] _vertex;
        private readonly int[] _texture;
        private readonly int[] _normal;

        public Face(int[] vertex, int[] texture, int[] normal)
        {
            _vertex = vertex;
            _texture = texture;
            _normal = normal;
        }

        public int[] Texture => _texture;
        public int[] Vertex => _vertex;
        public int[] Normal => _normal;
    }
}