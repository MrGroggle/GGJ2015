using UnityEngine;
using System.Collections;
//Size of textures


public class PlayerGUI : MonoBehaviour {

	// Use this for initialization
	void Start () 
	{
		//chMotor = GetComponent (CharacterMotor);
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
	public Vector2 healthPos = new Vector2(20,20);
	public float healthDisplay = 1f;
	public Texture2D healthBarEmpty;
	public Texture2D healthBarFull;

	 //Hunger
	public Vector2 hungerPos = new Vector2(20,20);
	public float hungerDisplay = 1f;
	public Texture2D hungerBarEmpty;
	public Texture2D hungerBarFull;

	public float healthFallRate = 150f;
	public float hungerFallRate = 150f;

	//public CharacterMotor chMotor;
	public CharacterController controller;
	public bool m_canJump = false;
	public float jumpTimer = 0.7f;
	public float barLength = 0.0f;
}
