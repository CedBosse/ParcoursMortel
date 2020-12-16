using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Mesh))]
public class planeMeshDeformComponent : MonoBehaviour
{
    public int amplitude = 1;
    private Vector3[] vertices;
    private PlanemeshGeneratorComponent plane;
    private Mesh mesh;
    private float elapsed = 0;
    public bool isMoving = false;
    // Start is called before the first frame update
    void Start()
    {
        plane = GetComponent<PlanemeshGeneratorComponent>();       
        
        mesh = GetComponent<MeshFilter>().mesh;

        vertices = mesh.vertices;

        //GetComponent<MeshFilter>().mesh.vertices = GenerateZ();
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving)
        {
            elapsed += Time.deltaTime;
            GetComponent<MeshFilter>().mesh.vertices = AnimateZ(elapsed);
        }       
    }

    private Vector3[] GenerateZ()
    {
        float intervalX = (2 * Mathf.PI) / plane.nRows;
        float z;

        for (int i = 0; i < plane.nRows; i++)
        {
            z = amplitude * Mathf.Sin(intervalX * i - 7.5f);
            for (int j = 0; j < plane.nColumns; j++)
            {
                vertices[i * plane.nColumns + j].z = z;
            }
        }

        return vertices;
    }

    private Vector3[] AnimateZ(float time)
    {
        float intervalX = (2 * Mathf.PI) / plane.nRows;
        float z;

        for (int i = 0; i < plane.nRows; i++)
        {
            z = amplitude * Mathf.Sin(intervalX * i - time);
            for (int j = 0; j < plane.nColumns; j++)
            {
                vertices[i * plane.nColumns + j].z = z;
            }
        }

        return vertices;
    }
}
