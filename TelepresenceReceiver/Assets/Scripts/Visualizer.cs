using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
public class Visualizer : MonoBehaviour
{
    Mesh _mesh;
    int[] _indices;
    private MeshFilter _meshFilter;

    void Awake()
    {
        _meshFilter = gameObject.GetComponent<MeshFilter>();
    }
  
    public void UpdateMeshInfo(Vector3[] vertices, Color[] colors)
    {
        if (_mesh == null)
        {
            _mesh = new Mesh
            {
                indexFormat = UnityEngine.Rendering.IndexFormat.UInt32
            };

            int num = vertices.Length;
            _indices = new int[num];
            for (int i = 0; i < num; i++) { _indices[i] = i; }

            _mesh.vertices = vertices;
            _mesh.colors = colors;
            _mesh.SetIndices(_indices, MeshTopology.Points, 0);

            _meshFilter.mesh = _mesh;
        }
        else
        {
            _mesh.vertices = vertices;
            _mesh.colors = colors;
            _mesh.RecalculateBounds();
        }
    }
}
