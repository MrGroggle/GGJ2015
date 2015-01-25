using UnityEngine;
using System.Collections;

public class TreeController : MonoBehaviour 
{
	public int treeHealth = 3;
	public Transform coconut;
	private GameObject tree;
	public Transform logs;
	private int speed = 8;
	
	// Use this for initialization
	void Start () 
	{
		tree = this.gameObject;
		rigidbody.isKinematic = true;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(treeHealth <= 0)
		{
			StartCoroutine(DestroyTree());
		}
	}
	
	IEnumerator DestroyTree()
	{
		rigidbody.isKinematic = false;
		rigidbody.AddForce(transform.forward * speed);	
		yield return new WaitForSeconds(7f);
		Destroy(tree);
		
		Vector3 position = new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(-1.0f, 1.0f));
		Instantiate(logs, tree.transform.position + new Vector3(0,0,0) + position, Quaternion.identity);
		Instantiate(logs, tree.transform.position + new Vector3(2,2,0) + position, Quaternion.identity);
		Instantiate(logs, tree.transform.position + new Vector3(5,5,0) + position, Quaternion.identity);
		
		Instantiate(coconut, tree.transform.position + new Vector3(0,0,0) + position, Quaternion.identity);
		Instantiate(coconut, tree.transform.position + new Vector3(2,2,0) + position, Quaternion.identity);
		Instantiate(coconut, tree.transform.position + new Vector3(5,5,0) + position, Quaternion.identity);
	}
}
