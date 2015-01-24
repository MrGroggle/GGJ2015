#pragma strict

private var hasAxe : boolean = false;

private var canSwing : boolean = true;
private var isSwinging : boolean = false;
var swingTimer : float = 0.7;

private var controller : CharacterController;
//private var playerGUI : PlayerGUI;

function Start()
{
	hasAxe = true;
	controller = GameObject.Find("First Person Controller").GetComponent(CharacterController);
	//playerGUI = GameObject.Find("First Person Controller").GetComponent(PlayerGUI);
}

function Update()
{
	//If we aren't moving and if we aren't swinging, then we idle!
	
	if(controller.velocity.magnitude <= 0 && isSwinging == false)
	{
		animation.Play("Idle");
		animation["Idle"].wrapMode = WrapMode.Loop;
		animation["Idle"].speed = 0.2;
	}
	
	//If we're holding shift and moving, then sprint!
	
	if(controller.velocity.magnitude > 0 && Input.GetKey(KeyCode.LeftShift))
	{
		animation.Play("Sprint");
		animation["Sprint"].wrapMode = WrapMode.Loop;
	}
	
	if(hasAxe == true && canSwing == true)
	{
		if(Input.GetMouseButtonDown(0))
		{
			//Stamina reduction applied to the PlayerGUI script
			//playerGUI.staminaBarDisplay -= 0.1;
			
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
}
