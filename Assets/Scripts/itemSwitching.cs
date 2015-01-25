using UnityEngine;
using System.Collections;

public class itemSwitching : MonoBehaviour {
	public GameObject weapon1;
	public GameObject weapon2;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown(KeyCode.Q))
		    {
			SwapWeapons();
			}


	}

	
	void SwapWeapons()
	{
		if (weapon1.active == true) {
						weapon1.SetActiveRecursively (false);
						weapon2.SetActiveRecursively (true);


				} else {
						weapon1.SetActiveRecursively (true);
						weapon2.SetActiveRecursively (false);
				}
			
			
	}


}

