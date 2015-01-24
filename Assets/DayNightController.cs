using UnityEngine;
using System.Collections;

public class DayNightController : MonoBehaviour 
{
	public Light DayLight;
	public Light NightLight;
	public float DaySpeed = 120f;
	public float SwitchoffHeight = -100f;

	private float Timer = 0f;
	private float Offset = 500f;
	private Transform StartTransform;

	// Use this for initialization
	void Start () 
	{
		StartTransform = transform;
	}
	
	// Update is called once per frame
	void Update () 
	{
		// Deg2Rad because otherwise 1 rad of time = 1 rotation.
		// Duration * 4 because: x2 for night/day and a further x2 because +- values for sin/cos
		Timer += (Time.deltaTime * Mathf.Deg2Rad) * DaySpeed;

		// Position and rotate the day light 
		DayLight.transform.position = new Vector3 (StartTransform.position.x, Mathf.Cos (Timer) * Offset, StartTransform.position.z + (Mathf.Sin (Timer) * Offset));
		DayLight.transform.rotation = Quaternion.LookRotation (transform.position - DayLight.transform.position);

		// Position and rotate the night light
		NightLight.transform.position = new Vector3 ((StartTransform.position.x), Mathf.Cos (Timer) * -Offset, StartTransform.position.z - (Mathf.Sin (Timer) * Offset));
		NightLight.transform.rotation = Quaternion.LookRotation (transform.position - NightLight.transform.position);

		// Disable sun if it's below the horizon, enable if above
		if (DayLight.transform.position.y < SwitchoffHeight) 
		{
			DayLight.enabled = false;
		}
		else if (DayLight.transform.position.y > SwitchoffHeight)
		{
			DayLight.enabled = true;
		}

		// Disable moon if it's below the horizon, enable if above
		if (NightLight.transform.position.y < SwitchoffHeight) 
		{
			NightLight.enabled = false;
		}
		else if (NightLight.transform.position.y > SwitchoffHeight)
		{
			NightLight.enabled = true;
			NightLight.intensity = 0.5f;
		}
	}
}
