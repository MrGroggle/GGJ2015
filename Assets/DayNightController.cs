using UnityEngine;
using System.Collections;

public class DayNightController : MonoBehaviour 
{
	public Light DayLight;
	public Light NightLight;
	public float DayDuration = 120f;

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
		Timer += Time.deltaTime / DayDuration;

		DayLight.transform.position = new Vector3 (StartTransform.position.x, Mathf.Cos (Timer) * Offset, StartTransform.position.z + (Mathf.Sin (Timer) * Offset));
		DayLight.transform.rotation = Quaternion.LookRotation (transform.position - DayLight.transform.position);

		NightLight.transform.position = new Vector3 ((StartTransform.position.x), Mathf.Cos (Timer) * -Offset, StartTransform.position.z - (Mathf.Sin (Timer) * Offset));
		NightLight.transform.rotation = Quaternion.LookRotation (transform.position - NightLight.transform.position);

		if (DayLight.transform.position.y < 0) 
		{
			DayLight.enabled = false;
		}
		else if (DayLight.transform.position.y > 0)
		{
			DayLight.enabled = true;
		}

		if (NightLight.transform.position.y < 0) 
		{
			NightLight.enabled = false;
		}
		else if (NightLight.transform.position.y > 0)
		{
			NightLight.enabled = true;
		}
	}
}
