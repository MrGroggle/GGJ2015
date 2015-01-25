using UnityEngine;
using System.Collections;



public class CompletedLevel : MonoBehaviour {

	public string Level;

	void OnTriggerEnter(Collider other) 
	{
		Application.LoadLevel (Level);
	}
}
