using UnityEngine;
using System.Collections;

public class FlameDamage : MonoBehaviour 
{

	void OnCollisionEnter(Collision collision) 
	{

		Debug.Log("ON Enter");
	}
	void OnCollisionStay(Collision collision) 
	{
		
		Debug.Log("Stay");
	}
}
