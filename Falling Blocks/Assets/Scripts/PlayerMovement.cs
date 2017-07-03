using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float speed;
	float screenHalfWidthInWorldUnits;

	void Start () {
		float halfPlayerWidth = transform.localScale.x / 2;
		screenHalfWidthInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize + halfPlayerWidth;

	}
	
	void Update () {
		Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), 0);
		Vector2 moveAmount = input.normalized * speed * Time.deltaTime;
		transform.Translate(moveAmount);


		if (transform.position.x < -screenHalfWidthInWorldUnits)
			transform.position = new Vector2(screenHalfWidthInWorldUnits, transform.position.y);

		if (transform.position.x > screenHalfWidthInWorldUnits)
			transform.position = new Vector2(-screenHalfWidthInWorldUnits, transform.position.y);




		//transform.position = camera.ViewportToWorldPoint(new Vector3(1f, -3.8f, 0));











	}
}
