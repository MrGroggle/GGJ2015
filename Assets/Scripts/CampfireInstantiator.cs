using UnityEngine;
using System.Collections;

public class CampfireInstantiator : MonoBehaviour 
{
	public Transform CampfirePrefab;
	public GameObject Player;

	private bool CanBuild = false;
	private Light FireLight;

	void Start()
	{
		gameObject.AddComponent<Light> ();
		FireLight = gameObject.GetComponent<Light> ();
		FireLight.color = Color.green;
		CanBuild = true;
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Terrain" || other.gameObject.tag == "Tree") 
		{
			FireLight.color = Color.red;
			CanBuild = false;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "Terrain" || other.gameObject.tag == "Tree") 
		{
			FireLight.color = Color.green;
			CanBuild = true;
		}
	}

	void Update()
	{
		if (Input.GetKeyDown ("b") && CanBuild) 
		{
			Instantiate (CampfirePrefab, transform.position, Quaternion.identity);
			Player.GetComponent<Crafting>().Campfire.SetActive(false);
		}
	}
}
