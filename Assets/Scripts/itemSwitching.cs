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
						weapon1.SetActive (false);
						weapon2.SetActive (true);


				} else {
						weapon1.SetActive (true);
						weapon2.SetActive (false);
				}
			
			
	}


}

