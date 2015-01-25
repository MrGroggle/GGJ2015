using UnityEngine;
using System.Collections;



public class CompletedLevel : MonoBehaviour {

	public string Level;

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.tag == "Player") {
						Application.LoadLevel (Level);
				}
	}
}
