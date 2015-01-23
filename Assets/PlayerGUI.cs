using UnityEngine;
using System.Collections;
//Size of textures


public class PlayerGUI : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		chMotor = GetComponent (CharacterMotor);
	}
	
	// Update is called once per frame
	void Update () 
	{
	
	}
	void OnGUI()
	{
		GUI.Box (new Rect (5, 30, 50, 23), "Health");
		GUI.Box (new Rect (5, 55, 50, 23), "Hunger");

		GUI.Box (new Rect (55, 30, barLength, 23), "PLACEHOLDER");
	}


	Vector2 barSize = new Vector2(240, 20);

	//Health
	Vector2 healthPos = new Vector2(20,20);
	float healthDisplay = 1f;
	Texture2D healthBarEmpty;
	Texture2D healthBarFull;

	//Hunger
	Vector2 hungerPos = new Vector2(20,20);
	float hungerDisplay = 1f;
	Texture2D hungerBarEmpty;
	Texture2D hungerBarFull;

	float healthFallRate = 150f;
	float hungerFallRate = 150f;

	CharacterMotor chMotor;
	CharacterController controller;
	bool m_canJump = false;
	float jumpTimer = 0.7f;
	float barLength = 0.0f;
}
