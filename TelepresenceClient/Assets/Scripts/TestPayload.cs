using UnityEngine;

namespace DefaultNamespace
{
    public class TestPayload : MonoBehaviour
    {
        private void Start()
        {
            Vector3[] vertices = {
                new(1,2,3),
                new(0,0,0)
            };

            Color[] colors = {
                new(3, 2, 1),
                new(0,0,0)
            };

            var payload = VerticesColorHandler.GeneratePayload(vertices, colors);
            var extractedVertices = VerticesColorHandler.GetVertices(payload);
            var extractedColors = VerticesColorHandler.GetColors(payload);

            Debug.Log($"*** Check vertices: {VerticesColorHandler.CheckVertices(vertices, payload)}");
            Debug.Log($"*** Check colors: {VerticesColorHandler.CheckColors(colors, payload)}");
        }
    }
}