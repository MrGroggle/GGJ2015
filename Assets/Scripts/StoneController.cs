using UnityEngine;
using System.Collections;
class StoneController : MonoBehaviour 
{
	
	public int stoneHealth = 5;
	
	public Transform rock;
	private GameObject stone;

	void Start()
	{
		stone = this.gameObject;
	}
	
	void FixedUpdate()
	{
		if(stoneHealth <= 0)
		{
			CreateRocks();
		}
	}
	
	void CreateRocks()
	{
		Destroy (stone);
		Vector3 position = new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(-1.0f, 1.0f));
		Instantiate(rock, stone.transform.position + new Vector3(0, 0, 0) + position, Quaternion.identity);
		Instantiate(rock, stone.transform.position + new Vector3(2, 2, 0) + position, Quaternion.identity);
		Instantiate(rock, stone.transform.position + new Vector3(5, 5, 0) + position, Quaternion.identity);
	}

}



