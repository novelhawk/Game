namespace Framework.ObjectLoader
{
    public struct Face
    {
        public Face(int[] vertex, int[] texture, int[] normal)
        {
            Vertex = vertex;
            Texture = texture;
            Normal = normal;
        }

        public int[] Texture { get; }

        public int[] Vertex { get; }

        public int[] Normal { get; }
    }
}