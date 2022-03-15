namespace Utils
{
    using System;
    using UnityEngine;

    public class VerticesColorsHandler
    {
        public static byte[] GeneratePayload(Vector3[] vertices, Color[] colors)
        {
            // Build the array of floats
            var floatArray = new float[vertices.Length * 3 + colors.Length * 3];

            // Process the Vertices
            for (var i = 0; i < vertices.Length; i++)
            {
                floatArray[3 * i] = vertices[i].x;
                floatArray[3 * i + 1] = vertices[i].y;
                floatArray[3 * i + 2] = vertices[i].z;
            }
        
            // Process the Colors
            for (var i = 0; i < colors.Length; i++)
            {
                var baseIndex = vertices.Length * 3;
                floatArray[3 * i + baseIndex] = colors[i].r;
                floatArray[3 * i + 1 + baseIndex] = colors[i].g;
                floatArray[3 * i + 2 + baseIndex] = colors[i].b;
            }

            var byteArray = new byte[floatArray.Length * 4];
            Buffer.BlockCopy(floatArray, 0, byteArray, 0, byteArray.Length);
            
            var result = CLZF2.Compress(byteArray);

            return result;
        }

        public static Vector3[] GetVertices(byte[] byteArray, bool isCompressed = true)
        {
            var ar = byteArray;
            if (isCompressed)
                ar = CLZF2.Decompress(byteArray);
            
            var floatArray = new float[ar.Length / 4];
            Buffer.BlockCopy(ar, 0, floatArray, 0, ar.Length);
            
            // Extract Vertices
            return GetVertices(floatArray);
        }

        public static Vector3[] GetVertices(float[] floatArray)
        {
            // Extract Vertices
            var numItems = (floatArray.Length / 2) / 3;
            Vector3[] vertices = new Vector3[numItems];
            
            // Process Vector3 data
            for (var i = 0; i < (floatArray.Length / 2); i+=3)
            {
                var ind = i / 3;
                vertices[ind].x = floatArray[i];
                vertices[ind].y = floatArray[i+1];
                vertices[ind].z = floatArray[i+2];
            }

            return vertices;
        }

        public static Color[] GetColors(byte[] byteArray, bool isCompressed = true)
        {
            var ar = byteArray;
            if (isCompressed)
                ar = CLZF2.Decompress(byteArray);
            
            var floatArray = new float[ar.Length / 4];
            Buffer.BlockCopy(ar, 0, floatArray, 0, ar.Length);
            
            // Extract Colors
            return GetColors(floatArray);
        }

        public static Color[] GetColors(float[] floatArray)
        {
            // Extract Colors
            var numItems = (floatArray.Length / 2) / 3;
            Color[] colors = new Color[numItems];
            
            // Process Color data
            var start = floatArray.Length/2;
            for (var i = start; i < (floatArray.Length); i+=3)
            {
                var ind = (i-start) / 3;
                colors[ind].r = floatArray[i];
                colors[ind].g = floatArray[i+1];
                colors[ind].b = floatArray[i+2];
            }

            return colors;
        }
    }
}