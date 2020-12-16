using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RipleComponent : MonoBehaviour
{
	//Public
	public float minImpulse = 2;
	public float malleability = 0.05f;
	public float radius = 0.1f;

	//Private
	private Mesh m;
	private MeshCollider mc;
	private Vector3[] verts;
	private Vector3[] iVerts;

	private void Start()
	{
		m = GetComponent<MeshFilter>().mesh;
		mc = GetComponent<MeshCollider>();
		iVerts = m.vertices;
	}

	private void OnCollisionEnter(Collision collision)
	{
		Debug.Log("touché");
		//Get point, impulse mag, and normal
		Vector3 pt = transform.InverseTransformPoint(collision.GetContact(0).point);
		Vector3 nrm = transform.InverseTransformDirection(collision.GetContact(0).normal);
		float imp = collision.impulse.magnitude;
		if (imp < minImpulse)
			return;

		//Deform vertices
		verts = m.vertices;
		float scale; 
		for (int i = 0; i < verts.Length; i++)
		{
			//Get deformation scale based on distance
			scale = Mathf.Clamp(radius - (pt - verts[i]).magnitude, 0, radius);

			//Deform by impulse multiplied by scale and strength parameter
			verts[i] += nrm * imp * scale * malleability;
		}

		//Apply changes to collider and mesh
		m.vertices = verts;
		mc.sharedMesh = m;

		m.RecalculateNormals();
		m.RecalculateBounds();
	}

	private void OnApplicationQuit()
	{
		//Need to reset mesh after quit
		m.vertices = iVerts;
	}
}

