using UnityEngine;
using System.Collections;

public class CubeCollider : MonoBehaviour {

	void OnCollisionEnter(Collision collision) 
	{
		if (collider.tag == "FirstPersonController") 
		{
			Debug.Log("Cube Enter");
		}

	}
	void OnCollisionStay(Collision collision) 
	{
		
		if (collider.tag == "FirstPersonController") 
		{
			Debug.Log("Cube Stay");
		}
	}
}
