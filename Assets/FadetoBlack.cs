using UnityEngine;
using System.Collections;

public class FadetoBlack : MonoBehaviour {

	// Use this for initialization
	void Start () {


	}
	void Awake()
	{

		guiTexture.pixelInset = new Rect (0f, 0f, Screen.width, Screen.height);
	}
	// Update is called once per frame
	void Update () {
		guiTexture.enabled = true;
		guiTexture.color = Color.Lerp(guiTexture.color, Color.black, 1.5f * Time.deltaTime);

		if (guiTexture.color.a >= 0.95f) 
		{
			Application.LoadLevel("SurvivalScene");
		}
	}
}
