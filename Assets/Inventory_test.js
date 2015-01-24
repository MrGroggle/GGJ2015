#pragma strict


var menuSkin : GUISkin;
var wood : int = 0;
var stone : int = 0;
var fish : int = 0;
var cookedFish : int = 0;
var water : int = 0;
var bandage : int = 0;

var food : int = 0;


var minimumVal : int = 0;
 
private var showGUI : boolean = false; //turn Inv on and off


function Update()
{
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
	
	if(bandage <= 0)
	{
		bandage = minimumVal;
	}
	
	if(Input.GetKeyDown(KeyCode.I))
	{
		showGUI = !showGUI;
		
	}
		
	if ( showGUI == true)
	{
		Time.timeScale = 0;
		GameObject.Find("First Person Controller").GetComponent(FPSInputController).enabled = false;
		GameObject.Find("First Person Controller").GetComponent(MouseLook).enabled = false;
		GameObject.Find("Main Camera").GetComponent(MouseLook).enabled = false;
		GameObject.Find("FPSArms_Axe@Idle").GetComponent(playerControl).enabled = false;
		
	} 	
	
	if ( showGUI == false)
	{
		Time.timeScale = 1;
		GameObject.Find("First Person Controller").GetComponent(FPSInputController).enabled = true;
		GameObject.Find("First Person Controller").GetComponent(MouseLook).enabled = true;
		GameObject.Find("Main Camera").GetComponent(MouseLook).enabled = true;
		GameObject.Find("FPSArms_Axe@Idle").GetComponent(playerControl).enabled = true;
		
	} 
}

function OnGUI()
{
	if (showGUI == true)
	{
		GUI.skin = menuSkin;
			GUI.BeginGroup(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 150, 300, 300));
				GUI.Box(Rect(0, 0, 300, 300), "Basic Inventory");
				
				//get wood! ;)
				GUI.Label(Rect(10, 50, 50, 50), "Wood");
				GUI.Box(Rect(60, 50, 20, 20), "" + wood);
				
				//more holders for items in game
				GUI.Label(Rect(10, 130, 50, 50), "Fish");
				GUI.Box(Rect(60, 130, 20, 20), "" + fish);
				
				//Edable items
				GUI.Label(Rect(10, 190, 50, 50), "Food");
				GUI.Box(Rect(60, 190, 20, 20), "" + food);
				if(GUI.Button(Rect(100, 190, 100, 20), "Eat Food?"))
				{
					if(food >= 1)
					{
						food--;
						Eat();
					}
				}
				
				GUI.Label(Rect(10, 210, 50, 50), "Water");
				GUI.Box(Rect(60, 210, 20, 20), "" + water);
				if(GUI.Button(Rect(100, 210, 100, 20), "Drink Water?"))
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

function Eat()
{
	//playerGUI.hungerBarDisplay += 0.1;
}

function Drink()
{
	//playerGUI.thirstBarDisplay += 0.1;
}

