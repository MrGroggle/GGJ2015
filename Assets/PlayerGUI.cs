using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//Size of textures


public class PlayerGUI : MonoBehaviour {	
	
	public Vector2 barSize = new Vector2(240, 20);	
	public float barLength = 0.0f;
	
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
		if(hungerDisplay >= 0.75)
		{
			healthDisplay += Time.deltaTime / healthFallRate;
		}
		if (staminaDisplay >= 1) 
		{
			staminaDisplay = 1f;
		}
		if (staminaDisplay <= 0) 
		{
			staminaDisplay = 0;
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
