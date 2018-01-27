using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class MeshCombiner : MonoBehaviour {

	public void Start()
	{
		MeshCollider[] meshColliders = GetComponentsInChildren<MeshCollider>();
		CombineInstance[] combine = new CombineInstance[meshColliders.Length];
		int i = 0;
		while (i < meshColliders.Length) {
			combine[i].mesh = meshColliders[i].sharedMesh;
			combine[i].transform = meshColliders[i].transform.localToWorldMatrix;
			meshColliders[i].gameObject.active = false;
			i++;
		}
		transform.GetComponent<MeshFilter>().mesh = new Mesh();
		transform.GetComponent<MeshFilter>().mesh.CombineMeshes(combine);
		transform.gameObject.active = true;
	}
}
