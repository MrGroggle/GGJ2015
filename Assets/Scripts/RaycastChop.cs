using UnityEngine;
using System.Collections;

public class RaycastChop : MonoBehaviour {
	private float rayLength = 10f;
	
	//private TreeController treeScript;
	private playerControl playerAnim;
	private GameObject tree;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit = new RaycastHit();	
		
		if (Physics.Raycast (ray, out hit, rayLength))
		{
			
			if(hit.collider.gameObject.tag == "Tree")
			{
				tree = hit.collider.gameObject;				
				Debug.DrawLine(ray.origin, hit.point);
				playerAnim = GameObject.Find("FPSArms_Axe@Idle").GetComponent<playerControl>();
				
				if(Input.GetButtonDown("Fire1") && playerAnim.canSwing == true)
				{
					tree.GetComponent<TreeController>().treeHealth -= 1;
				}				
			}
		}
		
	}
}
