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
		Debug.Log ("started");
		inventory = GameObject.Find ("First Person Controller").GetComponent<Inv>();
		Debug.Log ("inventory", inventory);
	}
	
	// Update is called once per frame
	void Update () 
	{
		RaycastHit hit = new RaycastHit();
		Vector3 fwd = transform.TransformDirection (Vector3.forward);

		if (Physics.Raycast (transform.position, fwd, out hit, rayLength)) {
					if (hit.collider.gameObject.tag == "fish") {
						guiShow = true;

								if (Input.GetKeyDown (KeyCode.E)) {

										inventory.fish++;
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
