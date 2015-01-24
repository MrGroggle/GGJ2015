using UnityEngine;
using System.Collections;

public class CampfireInstantiator : MonoBehaviour 
{
	public Transform CampfirePrefab;
	public GameObject Player;

	private bool CanBuild = false;

	void Start()
	{
		Color GreenColour = Color.green;
		GreenColour.a = 0.5f;
		renderer.material.color = GreenColour;
		CanBuild = true;
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag == "Terrain" || other.gameObject.tag == "Tree") 
		{
			Color RedColour = Color.red;
			RedColour.a = 0.5f;
			renderer.material.color = RedColour;
			CanBuild = false;
		}
	}

	void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag == "Terrain" || other.gameObject.tag == "Tree") 
		{
			Color GreenColour = Color.green;
			GreenColour.a = 0.5f;
			renderer.material.color = GreenColour;
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
