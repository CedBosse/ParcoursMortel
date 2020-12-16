using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class PlanemeshGeneratorComponent : MonoBehaviour
{
    public int width;
    public int height;
    public int nRows;
    public int nColumns;
    private Queue<Vector3> flagVertices;
    private Queue<int> triangles;
    private Queue<Vector2> uvs;
    [SerializeField] private MeshCollider collider;
    private Mesh meshToDeform;
    private Vector3[] originalVertices, displacedVertices;
    private Vector3[] vertexVelocities;

    // Start is called before the first frame update
    void Awake()
    {       
        flagVertices = new Queue<Vector3>();
        uvs = new Queue<Vector2>();
        triangles = new Queue<int>();
        GetComponent<MeshFilter>().mesh = CreateFlagMesh();
        collider.sharedMesh = CreateFlagMesh();
       
    }
    private void Start()
    {
        meshToDeform = CreateFlagMesh();
        originalVertices = meshToDeform.vertices;
        displacedVertices = new Vector3[originalVertices.Length];
        for (int i = 0; i < originalVertices.Length; i++)
        {
            displacedVertices[i] = originalVertices[i];
        }
        vertexVelocities = new Vector3[originalVertices.Length];
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void UpdateVertex() { }
    private void HandleHit()
    {
        RaycastHit hit;
        if()
    }
    private Mesh CreateFlagMesh()
    {
        RemplirQueue();
        Mesh flagMesh = new Mesh();
        flagMesh.vertices = flagVertices.ToArray();

        flagMesh.triangles = GenerateTriangles();
        flagMesh.uv = GenerateUV();

        flagMesh.RecalculateNormals();
        return flagMesh;
    }

    private void RemplirQueue()
    {
        float distanceRow = nRows / width;//pt switch
        float distanceColumn = nColumns / height;

        for(int i = 0; i < nRows; i++)//x
        {
            for(int j = 0; j < nColumns; j++)//y
            {
                flagVertices.Enqueue(new Vector3(i + distanceRow, j + distanceColumn, 0));
            }
        }
    }

    private int[] GenerateTriangles()
    {
        int[] sommets;
        int nbRangeFait = 1;
        for (int i = 0; i < (nRows * nColumns) -nColumns; i++)
        {
            if (i + 1 == nColumns * nbRangeFait)
            {
                nbRangeFait++;
                continue;
            }
                

            triangles.Enqueue(i);
            triangles.Enqueue(i + 1);
            triangles.Enqueue(i + nColumns + 1);

            triangles.Enqueue(i + nColumns + 1);
            triangles.Enqueue(i + nColumns);
            triangles.Enqueue(i);
        }

        return sommets = triangles.ToArray();
    }

    private Vector2[] GenerateUV()
    {
        float intervalX = 1f/nRows;
        float intervalY = 1f/nColumns;
        for(int i = 0; i < nRows; i++)
        {
            for(int j = 0; j < nColumns; j++)
            {
                uvs.Enqueue(new Vector2(i * intervalX, j * intervalY));
            }
        }

        return uvs.ToArray();
    }

   
}
