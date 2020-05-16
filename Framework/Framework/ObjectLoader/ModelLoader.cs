using System.IO;

namespace Framework.ObjectLoader
{
    public static class ModelLoader
    {
        /*
         * Version 0x01
         * == HEADER ==
         * VERSION: 0x01
         * CoordsPerVertex: 0x03/0x04
         * CoordsPerTexture: 0x02/0x03
         * NumberTriangles: X
         * == PAYLOAD ==
         * (X, Y, Z, [W]), (U, V, [W]), (X, Y, Z) : repeating X * 3
         */
        
        public static float[] Load(string path)
        {
            using var fs = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.Read);
            using var reader = new BinaryReader(fs);
            
            // Assert.That(reader.ReadByte() == 0x01);
                
            var coordsPerVertex = reader.ReadByte();
            var coordsPerTexture = reader.ReadByte();
            const byte coordsPerNormal = 3;

            var numberOfTriangles = reader.ReadInt32();

            var data = new float[numberOfTriangles * (coordsPerVertex)];

            for (int i = 0; i < data.Length; i++)
                data[i] = reader.ReadSingle();
                
            return data;
        }
    }
}