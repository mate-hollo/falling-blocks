﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public float speed;
	float screenHalfWidthInWorldUnits;

	void Start () {
		//calculate half the players width
		float halfPlayerWidth = transform.localScale.x / 2;

		// screen_width/screen height *screen_height (world_units) /2 = screen_width / 2 (world_units)
		//aspect ratio*ortographic_size = screen_width / 2(world_units)
		screenHalfWidthInWorldUnits = Camera.main.aspect * Camera.main.orthographicSize + halfPlayerWidth;

	}
	
	void Update () {
		Vector2 input = new Vector2(Input.GetAxisRaw("Horizontal"), 0);	
		Vector2 moveAmount = input * speed * Time.deltaTime;
		transform.Translate(moveAmount);

		//check when we reach the border on x axis to port the player to the other side
		if (transform.position.x < -screenHalfWidthInWorldUnits)
			transform.position = new Vector2(screenHalfWidthInWorldUnits, transform.position.y);

		if (transform.position.x > screenHalfWidthInWorldUnits)
			transform.position = new Vector2(-screenHalfWidthInWorldUnits, transform.position.y);




		//transform.position = camera.ViewportToWorldPoint(new Vector3(1f, -3.8f, 0));











	}
}
