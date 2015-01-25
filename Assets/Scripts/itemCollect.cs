using UnityEngine;
using System.Collections;

public class itemCollect : MonoBehaviour {
	private Inv inventory;
	private bool guiShow = false;

	public GameObject bush;
	public GameObject player;

	private float rayLength = 10f;
	
	// Use this for initialization
	void Start () 
	{
		inventory = GameObject.Find ("First Person Controller").GetComponent<Inv>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		RaycastHit hit = new RaycastHit();

		if (Physics.Raycast (ray, out hit, rayLength)) {
			if (hit.collider.gameObject.tag == "fish") 
			{
				guiShow = true;

				if (Input.GetButtonDown("Use")) 
				{
					inventory.fish++;
					Destroy (hit.collider.gameObject);
					guiShow = false;
				}

			} 
			if (hit.collider.gameObject.tag == "Log") 
			{
				guiShow = true;
				
				if (Input.GetButtonDown("Use")) 
				{
					inventory.wood++;
					Destroy (hit.collider.gameObject);
					guiShow = false;
				}
				
			} 
			if (hit.collider.gameObject.tag == "Coconut") 
			{
				guiShow = true;
				
				if (Input.GetButtonDown("Use")) 
				{
					inventory.food++;
					Destroy (hit.collider.gameObject);
					guiShow = false;
				}
				
			} 
		}
		else 
		{
			guiShow = false;
			}

	
	}

	void OnGUI()
	{
		if(guiShow == true)
		{
			GUI.Box(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 150, 100, 20), "PICKUP!");
		}
	}


}
