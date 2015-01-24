using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//Size of textures


public class PlayerGUI : MonoBehaviour {	
	
	public Vector2 barSize = new Vector2(240, 20);
	
	//Health
	public float healthFallRate = 150f;

	public Vector2 healthPos = new Vector2(20,20);
	public float healthDisplay = 1f;
	public Texture2D healthBarEmpty;
	public Texture2D healthBarFull;
	
	//Hunger
	public float hungerFallRate = 150f;

	public Vector2 hungerPos = new Vector2(80,20);
	public float hungerDisplay = 1f;
	public Texture2D hungerBarEmpty;
	public Texture2D hungerBarFull;
	
	//Stamina
	public float staminaFallRate = 150f;
	
	public Vector2 staminaPos = new Vector2(80,20);
	public float staminaDisplay = 1f;
	public Texture2D staminaBarEmpty;
	public Texture2D staminaBarFull;

	
	private CharacterMotor motor;
	public CharacterController controller;
	public bool canJump = true;
	public float jumpTimer = 0.7f;
	public float barLength = 0.0f;

	// Use this for initialization
	void Start () 
	{
		controller = GetComponent<CharacterController>();
		motor = GetComponent<CharacterMotor>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (hungerDisplay <= 0) 
		{
			hungerDisplay = 0;
			healthDisplay -= Time.deltaTime / healthFallRate;
		}
		if(healthDisplay <=0)
		{
			characterDeath();
		}
		if (hungerDisplay >= 0) 
		{
			hungerDisplay -= Time.deltaTime / hungerFallRate;
		}
		if (hungerDisplay >= 1) 
		{
			hungerDisplay = 1f;
		}
		if (staminaDisplay >= 1) 
		{
			staminaDisplay = 1f;
		}
		if (staminaDisplay <= 0) 
		{
			staminaDisplay = 0;
			motor.movement.maxForwardSpeed = 6;
			motor.movement.maxSidewaysSpeed = 6;
		}
		if (controller.velocity.magnitude > 0 && Input.GetButton("Sprint")) 
		{
			motor.movement.maxForwardSpeed = 10;
			motor.movement.maxSidewaysSpeed = 10;
			staminaDisplay -= Time.deltaTime / staminaFallRate * 1.5f;
		} 
		else 
		{
			motor.movement.maxForwardSpeed = 6;
			motor.movement.maxSidewaysSpeed = 6;
			staminaDisplay += Time.deltaTime / staminaFallRate;
		}

		if (Input.GetButton("Jump") && canJump == true) 
		{
			Debug.Log("Jumping");
			staminaDisplay -= 0.2f;
		}
		if (!canJump)
		{
			jumpTimer = Time.deltaTime;
			motor.jumping.enabled = false;
		}
		
		if(jumpTimer <= 0)
		{
			canJump = true;
			motor.jumping.enabled = true;
			jumpTimer = 0.7f;
		}
		
		if(staminaDisplay <= 0.2f)
		{
			canJump = false;
			motor.jumping.enabled = false;
		}	
		


	}
	void OnGUI()
	{
		//Health
		GUI.BeginGroup (new Rect (healthPos.x, healthPos.y, barSize.x, barSize.y));
		GUI.Box (new Rect (0, 0, barSize.x, barSize.y), healthBarEmpty);

		GUI.BeginGroup (new Rect (0, 0, barSize.x * healthDisplay, barSize.y));
		GUI.Box (new Rect (0, 0, barSize.x, barSize.y), healthBarFull);

		GUI.EndGroup ();
		GUI.EndGroup ();

		//Hunger
		GUI.BeginGroup (new Rect (hungerPos.x, hungerPos.y, barSize.x, barSize.y));
		GUI.Box (new Rect (0, 0, barSize.x, barSize.y), hungerBarEmpty);
		
		GUI.BeginGroup (new Rect (0, 0, barSize.x * hungerDisplay, barSize.y));
		GUI.Box (new Rect (0, 0, barSize.x, barSize.y), hungerBarFull);
		
		GUI.EndGroup ();
		GUI.EndGroup ();

		//Stamina
		GUI.BeginGroup (new Rect (staminaPos.x, staminaPos.y, barSize.x, barSize.y));
		GUI.Box (new Rect (0, 0, barSize.x, barSize.y), staminaBarEmpty);
		
		GUI.BeginGroup (new Rect (0, 0, barSize.x * staminaDisplay, barSize.y));
		GUI.Box (new Rect (0, 0, barSize.x, barSize.y), staminaBarFull);
		
		GUI.EndGroup ();
		GUI.EndGroup ();
	}
	
	void characterDeath()
	{
		Application.LoadLevel("SurvivalScene");
	}

}
