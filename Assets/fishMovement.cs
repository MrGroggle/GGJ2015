using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class fishMovement : MonoBehaviour {

	public  List<Transform> target;
	public bool isMoving = false;
	public float speed = 5.0f;
	private Transform newTarget;


	void Start()
	{
	animation.Play("Swim");
	animation["Swim"].wrapMode = WrapMode.Loop;
	animation["Swim"].speed = 2;
	}

	// Update is called once per frame
	void Update () {

		if (isMoving == false) 
		{
			newTarget = target[Random.Range(0,target.Count)];
			isMoving = true;

		}

		transform.position = Vector3.MoveTowards (transform.position, newTarget.position, speed * Time.deltaTime);
		transform.LookAt(newTarget);


		if(transform.position == newTarget.position)
		   {
			isMoving = false;
		   }



	
	}
}
