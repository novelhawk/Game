namespace Framework.ObjectLoader
{
    public struct Model
    {
        public Model(float[] vertices, float[] textures, float[] normals, uint[] indices)
        {
            Vertices = vertices;
            Textures = textures;
            Normals = normals;
            
            Indices = indices;
        }

        public float[] Vertices { get; }

        public float[] Textures { get; }

        public float[] Normals { get; }

        public uint[] Indices { get; }
    }
}