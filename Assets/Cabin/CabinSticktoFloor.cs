using UnityEngine;
using System.Collections;

public class CabinSticktoFloor : MonoBehaviour {

	void OnCollisionEnter(Collision collision) 
	{
		if (collision.gameObject.tag == "Terrain") {
						this.gameObject.rigidbody.constraints = RigidbodyConstraints.FreezeAll;
				}

	}

}
