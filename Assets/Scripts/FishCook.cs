using UnityEngine;
using System.Collections;

public class FishCook : MonoBehaviour 
{
	private GameObject Player;
	private bool		GUIShow;
	
	private float		CookedTimer;
	private float 		MessageTimer = 1f;
	
	void Start () 
	{
		Player = GameObject.FindGameObjectWithTag ("Player");
		GUIShow = false;
	}

	void Update () 
	{
		RaycastHit hit = new RaycastHit();
		Vector3 fwd = Player.transform.forward;
		GUIShow = false;

		CookedTimer -= Time.deltaTime;

		if (Physics.Raycast (transform.position, fwd, out hit, 3f))
		{
			if (hit.collider.gameObject.tag == "Campfire")
			{
				Debug.DrawRay(transform.position, fwd, Color.cyan);
				Debug.DrawLine(Player.transform.position, hit.point, Color.red);
				GUIShow = true;
			}
		}

		if (GUIShow && Input.GetKeyDown("e"))
		{
			if (Player.GetComponent<Inv>().fish > 0)
			{
				Player.GetComponent<Inv>().fish -= 1;
				Player.GetComponent<Inv>().food += 1;

				CookedTimer = MessageTimer;
			}
		}
	}

	void OnGUI()
	{
		if(GUIShow == true)
		{
			float RectWidth = Screen.width * 0.3f;
			float RectHeight = Screen.height * 0.06f;

			GUI.Box(new Rect(Screen.width / 2f - (RectWidth * 0.5f), Screen.height * 0.25f - (RectHeight * 0.5f), RectWidth, RectHeight), Player.GetComponent<Inv>().fish == 0 ? "You have no fish to cook!" : "Press 'E' to cook a fish");

			if (CookedTimer > 0f)
			{
				GUI.Box(new Rect(Screen.width / 2f - (RectWidth * 0.5f), Screen.height * 0.35f - (RectHeight * 0.5f), RectWidth, RectHeight), "Fish cooked!");
			}
		}
	}
}
