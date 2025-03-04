using UnityEngine;

public class TargetMarkerMesh : MonoBehaviour
{
    private Mesh mesh;
    private Material material;

    [Header("Marker Settings")]
    public float radius = 1f;
    public int segments = 36;
    public float duration = 2f; // How long the marker stays visible

    [Header("Pulsing Effect")]
    public float pulseSpeed = 2f;
    public float pulseScale = 0.05f;

    void Awake()
    {
        MeshFilter meshFilter = gameObject.AddComponent<MeshFilter>();
        MeshRenderer meshRenderer = gameObject.AddComponent<MeshRenderer>();
        mesh = new Mesh();
        meshFilter.mesh = mesh;

        // Red transparent material
        material = new Material(Shader.Find("Standard"));
        material.color = new Color(1, 0, 0, 0.3f); // Semi-transparent red
        material.SetFloat("_Mode", 3);
        material.EnableKeyword("_ALPHABLEND_ON");
        material.renderQueue = 3000;
        material.SetInt("_Cull", (int)UnityEngine.Rendering.CullMode.Off);
        meshRenderer.material = material;

        CreateCircleMesh();
         Destroy(gameObject, duration); // Auto-destroy after duration
    }

    void Update()
    {
        float scale = 0.5f + Mathf.Sin(Time.time * pulseSpeed) * pulseScale;
        transform.localScale = new Vector3(scale, 0.5f, scale);
    }

    private void CreateCircleMesh()
    {
        Vector3[] vertices = new Vector3[segments + 1];
        int[] triangles = new int[segments * 3];

        vertices[0] = Vector3.zero;
        for (int i = 0; i < segments; i++)
        {
            float angle = Mathf.Deg2Rad * (360f / segments) * i;
            vertices[i + 1] = new Vector3(Mathf.Cos(angle) * radius, 0, Mathf.Sin(angle) * radius);
        }

        for (int i = 0; i < segments; i++)
        {
            triangles[i * 3] = 0;
            triangles[i * 3 + 1] = i + 1;
            triangles[i * 3 + 2] = (i + 2 > segments) ? 1 : i + 2;
        }

        mesh.vertices = vertices;
        mesh.triangles = triangles;
        mesh.RecalculateNormals();
    }
}
