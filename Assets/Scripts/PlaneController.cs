using UnityEngine;
using System.Collections;

public class PlaneController : MonoBehaviour {
	float scale = 1.0f;
	float speed = 1.0f;
	public static Mesh viewedModel;
	public Mesh mesh;
	public MeshFilter meshFilter;

	private Vector3[] baseHeight;

	// Use this for initialization
	void Start () {
		meshFilter = GetComponent<MeshFilter>();
		mesh = GetComponent<MeshFilter>().mesh;
		if (baseHeight == null) {
			baseHeight = mesh.vertices;
		}
	}
	
	// Update is called once per frame
	void Update () {

		var vertices = new Vector3[baseHeight.Length];

//		for (var i=0;i<vertices.Length;i++)
//		{
//			var vertex = baseHeight[i];
//			vertex.y += Mathf.Sin(Time.time * speed+ baseHeight[i].x + baseHeight[i].y + baseHeight[i].z) * scale;
//			vertices[i] = vertex;
//		}
		for (var i=0;i<vertices.Length;i++)
		{
			var vertex = baseHeight[i];
			vertex.y += Mathf.Sin(Time.time * speed+ baseHeight[i].x + baseHeight[i].y + baseHeight[i].z) * scale;
			vertices[i] = vertex;
		}
		mesh.vertices = vertices;
		mesh.RecalculateNormals();
	}
}