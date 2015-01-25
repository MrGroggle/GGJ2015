using UnityEngine;
using System.Collections;

public class Crafting : MonoBehaviour 
{
	public GUISkin MenuSkin;
	public GameObject Player;
	public GameObject MainCamera;
	public GameObject Arms;

	// Icons
	public Texture CampfireIcon;
	public Texture CabinIcon;

	// Prefabs
	public GameObject Campfire;
	public GameObject Cabin;

	private bool ShowGUI = false;

	private Inv InvScript;

	void Start()
	{
		InvScript = GetComponent<Inv> ();
	}

	void Update()
	{

		if (Input.GetKeyDown (KeyCode.C)) 
		{
			ShowGUI = !ShowGUI;
		}

		if (ShowGUI) 
		{
			Time.timeScale = 0;
			Player.GetComponent<FPSInputController>().enabled = false;
			Player.GetComponent<MouseLook>().enabled = false;
			MainCamera.GetComponent<MouseLook>().enabled = false;
			Arms.GetComponent<playerControl>().enabled = false;
		}

		if (!ShowGUI) 
		{
			Time.timeScale = 1;
			Player.GetComponent<FPSInputController>().enabled = true;
			Player.GetComponent<MouseLook>().enabled = true;
			MainCamera.GetComponent<MouseLook>().enabled = true;
			Arms.GetComponent<playerControl>().enabled = true;
		}
	}

	void OnGUI()
	{
		if (ShowGUI)
		{
			GUI.skin = MenuSkin;
			GUI.BeginGroup(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 150, 300, 300));
			GUI.Box (new Rect(0, 0, 300, 300), "Crafting System");

			if (GUI.Button(new Rect(10, 50, 50, 50), new GUIContent(CampfireIcon, "Build a campfire (3 wood)")))
			{
				if (InvScript.wood >= 3)
				{
					Debug.Log ("Activated campfire");
					Campfire.SetActive(true);

					InvScript.wood -= 3;
				}
			}

			if (GUI.Button(new Rect(10, 120, 50, 50), new GUIContent(CabinIcon, "Build a cabin (20 wood)")))
			{
				if (InvScript.wood >= 1)
				{
					Cabin.SetActive(true);
					
					InvScript.wood -= 1;
				}
			}

			GUI.Label(new Rect(100, 250, 100, 40), GUI.tooltip);
			GUI.EndGroup();
		}
	}
}
