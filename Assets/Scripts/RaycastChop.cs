using UnityEngine;
using System.Collections;

public class RaycastChop : MonoBehaviour {
	private float rayLength = 10f;
	
	//private TreeController treeScript;
	private playerControl playerAnim;
	private GameObject hitObject;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit = new RaycastHit();	
		
		if (Physics.Raycast (ray, out hit, rayLength))
		{
			
			if(hit.collider.gameObject.tag == "Tree")
			{
				hitObject = hit.collider.gameObject;	
				playerAnim = GameObject.Find("FPSArms_Axe@Idle").GetComponent<playerControl>();
				
				if(Input.GetButtonDown("Fire1") && playerAnim.canSwing == true)
				{
					hitObject.GetComponent<TreeController>().treeHealth -= 1;
				}				
			}
			
			if(hit.collider.gameObject.tag == "Rock")
			{
				hitObject = hit.collider.gameObject;	
				playerAnim = GameObject.Find("FPSArms_Axe@Idle").GetComponent<playerControl>();
				
				if(Input.GetButtonDown("Fire1"))
				{
					hitObject.GetComponent<StoneController>().stoneHealth -= 1;
				}				
			}
		}
		
	}
}
