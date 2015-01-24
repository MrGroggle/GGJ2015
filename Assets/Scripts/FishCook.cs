using UnityEngine;
using System.Collections;

public class FishCook : MonoBehaviour 
{
	private GameObject Player;
	
	void Start () 
	{
		Player = GameObject.FindGameObjectWithTag ("Player");
	}

	void Update () 
	{
		RaycastHit hit = new RaycastHit();
		Vector3 fwd = Player.transform.TransformDirection (Vector3.forward);

		//if (RaycastHit(Physics.Raycast (Player.transform.position, fwd, out hit, 3f)))
		//{
		//	Debug.Log (Time.realtimeSinceStartup.ToString() + ": Can cook");
		//}
	}
}
