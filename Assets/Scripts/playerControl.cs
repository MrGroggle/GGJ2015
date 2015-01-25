using UnityEngine;
using System.Collections;

public class playerControl : MonoBehaviour 
{
		
	private CharacterController controller;
	private PlayerGUI playerGUI;	
	private CharacterMotor motor;
	
	private bool hasAxe = false;
	public bool canSwing = true;
	private bool isSwinging = false;	
	private bool canJump = true;
	private bool canSprint = true;
	
	public float swingTimer = 0.7f;		
	public float jumpTimer = 2f;

	void Start()
	{
		hasAxe = true;
		controller = GameObject.Find ("First Person Controller").GetComponent<CharacterController> ();
		motor = GameObject.Find ("First Person Controller").GetComponent<CharacterMotor>();
		// implement player gui 
		playerGUI = GameObject.Find("First Person Controller").GetComponent<PlayerGUI>();

	}


	// Update is called once per frame
	void Update () {
	
		//If we aren't moving and if we aren't swinging, then we idle!
		if(controller.velocity.magnitude <= 0 && isSwinging == false)
		{
			motor.movement.maxForwardSpeed = 6;
			motor.movement.maxSidewaysSpeed = 6;
			animation.Play("Idle");
			animation["Idle"].wrapMode = WrapMode.Loop;
			animation["Idle"].speed = 0.2f;
			playerGUI.staminaDisplay += Time.deltaTime / playerGUI.staminaFallRate;	//Regenerate stamina at base rate
		}
		
		//If we're holding shift and moving, then sprint!
		
		if(controller.velocity.magnitude > 0 && Input.GetKey(KeyCode.LeftShift) && canSprint == true)
		{
			isSwinging = false;
			motor.movement.maxForwardSpeed = 10;
			motor.movement.maxSidewaysSpeed = 10;
			animation.Play("Sprint");
			animation["Sprint"].wrapMode = WrapMode.Loop;
			playerGUI.staminaDisplay -= Time.deltaTime / playerGUI.staminaFallRate * 1.5f;
		}
		else
		{	//Regenerate stamina at a slightly diminished rate if we're not sprinting		
			playerGUI.staminaDisplay += Time.deltaTime / playerGUI.staminaFallRate *0.75f;
		}
		
		if(hasAxe == true && canSwing == true)
		{
			if(Input.GetButton("Fire1"))
			{
				//Stamina reduction applied to the PlayerGUI script
				playerGUI.staminaDisplay -= 0.1f;
				
				//Swinging animation
				animation.Play("Swing");
				animation["Swing"].speed = 2;
				isSwinging = true;
				canSwing = false;
			}
		}		
		if(canSwing == false)
		{
			swingTimer -= Time.deltaTime;
		}
		
		if(swingTimer <= 0)
		{
			swingTimer = 1;
			canSwing = true;
			isSwinging = false;
		}
		if(Input.GetButtonDown("Jump") && canJump == true)
		{
			playerGUI.staminaDisplay -= 0.1f;
			StartCoroutine(WaitForJump ());	

		}
		if(canJump == false)
		{
			motor.jumping.enabled = false;
			jumpTimer -= Time.deltaTime;
		}
		
		if(jumpTimer <= 0)
		{
			jumpTimer = 2;			
			motor.jumping.enabled = true;
			canJump = true;
		}
		if(playerGUI.staminaDisplay <= 0.1)
		{
			canSwing = false;
			canJump = false;
			motor.jumping.enabled = false;
		}
		if(playerGUI.staminaDisplay <= 0)
		{
			canSprint = false;
			motor.movement.maxForwardSpeed = 6;
			motor.movement.maxSidewaysSpeed = 6;
		}
		if(playerGUI.staminaDisplay >= 0.5)
		{
			canSprint = true;
		}
	}
	
	IEnumerator WaitForJump()
	{
		yield return new WaitForSeconds(0.1f);
		canJump = false;

	}
}
