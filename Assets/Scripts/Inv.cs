using UnityEngine;
using System.Collections;



public class Inv : MonoBehaviour {
	public GUISkin menuSkin;
	public int wood= 0;
	public int fish = 0;
	public int water= 0;
	public int stone = 0;
	public int food = 0;
	public int minimumVal = 0;
	private bool showGUI = false;
	private PlayerGUI playerGUI;


	void Start()
	{
		playerGUI = GameObject.Find("First Person Controller").GetComponent<PlayerGUI>();
	}
	// Update is called once per frame
	void Update () {

		if(wood <= 0)
		{
			wood = minimumVal;
		}
		
		if(fish <= 0)
		{
			fish = minimumVal;
		}
		
		if(food <= 0)
		{
			food = minimumVal;
		}
		
		if(water <= 0)
		{
			water = minimumVal;
		}
		
		if(stone <= 0)
		{
			stone = minimumVal;
		}
		
		if(Input.GetKeyDown(KeyCode.I))
		{
			showGUI = !showGUI;
			
		}

		if ( showGUI == true)
		{
			Time.timeScale = 0;
			GameObject.Find("First Person Controller").GetComponent<FPSInputController>().enabled = false;
			GameObject.Find("First Person Controller").GetComponent<MouseLook>().enabled = false;
			GameObject.Find("Main Camera").GetComponent<MouseLook>().enabled = false;
			GameObject.Find("FPSArms_Axe@Idle").GetComponent<playerControl>().enabled = false;
			
		} 	
		
		if ( showGUI == false)
		{
			Time.timeScale = 1;
			GameObject.Find("First Person Controller").GetComponent<FPSInputController>().enabled = true;
			GameObject.Find("First Person Controller").GetComponent<MouseLook>().enabled = true;
			GameObject.Find("Main Camera").GetComponent<MouseLook>().enabled = true;
			GameObject.Find("FPSArms_Axe@Idle").GetComponent<playerControl>().enabled = true;
			
		} 
	}


	void OnGUI()
	{
		if (showGUI == true)
		{
			GUI.skin = menuSkin;
			GUI.BeginGroup(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 150, 300, 300));
			GUI.Box(new Rect(0, 0, 300, 300), "Basic Inventory");

			//get wood! ;)
			GUI.Label(new Rect(10, 50, 50, 50), "Wood");
			GUI.Box(new Rect(60, 50, 20, 20), "" + wood);

			GUI.Label(new Rect(10, 80, 50, 50), "Stone");
			GUI.Box(new Rect(60, 80, 20, 20), "" + stone);

			//more holders for items in game
			GUI.Label(new Rect(10, 130, 50, 50), "Fish");
			GUI.Box(new Rect(60, 130, 20, 20), "" + fish);
			
			//Edable items
			GUI.Label(new Rect(10, 190, 50, 50), "Food");
			GUI.Box(new Rect(60, 190, 20, 20), "" + food);
			if(GUI.Button(new Rect(100, 190, 100, 20), "Eat Food?"))
			{
				if(food >= 1)
				{
					food--;
					Eat();
				}
			}
			
			GUI.Label(new Rect(10, 210, 50, 50), "Water");
			GUI.Box(new Rect(60, 210, 20, 20), "" + water);
			if(GUI.Button(new Rect(100, 210, 100, 20), "Drink Water?"))
			{
				if(water >= 1)
				{
					water--;
					Drink();
				}
			}
			
			GUI.EndGroup();
		}
		
	}
	void Eat()
	{
		playerGUI.hungerDisplay += 0.1f;
	}
	
	void Drink()
	{
		//playerGUI.thirstBarDisplay += 0.1;
	}

}
