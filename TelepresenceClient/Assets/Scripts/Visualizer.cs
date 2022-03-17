using UnityEngine;

// Original license:
// MIT License
//
// Copyright (c) 2020 Takashi Yoshinaga
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
//     furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

[RequireComponent(typeof(MeshFilter))]
public class Visualizer : MonoBehaviour
{
    Mesh mesh;
    int[] indices;

    private MeshFilter meshFilter;

    void Awake()
    {
        meshFilter = gameObject.GetComponent<MeshFilter>();
    }
  
    public void UpdateMeshInfo(Vector3[] vertices, Color[] colors)
    {
        if (mesh == null)
        {

            mesh = new Mesh
            {
                indexFormat = UnityEngine.Rendering.IndexFormat.UInt32
            };

            //PointCloudの点の数はDepthのピクセル数から計算
            int num = vertices.Length;
            indices = new int[num];
            for (int i = 0; i < num; i++) { indices[i] = i; }

            //meshを初期化
            mesh.vertices = vertices;
            mesh.colors = colors;
            mesh.SetIndices(indices, MeshTopology.Points, 0);

            //meshを登場させる
            meshFilter.mesh = mesh;
        }
        else
        {
            mesh.vertices = vertices;
            mesh.colors = colors;
            mesh.RecalculateBounds();
        }
    }
}
