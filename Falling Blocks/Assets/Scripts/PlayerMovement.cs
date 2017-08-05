using System;
using UnityEngine;


public class PlayerMovement : MonoBehaviour {

	public float speed;
	public event Action OnPlayerDeath;
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

	//if it hits a falling block destory the player
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Falling Block")
		{
			//only check if there is something subscribed to the event, otherwise it will be error
			if (OnPlayerDeath != null)
				OnPlayerDeath();

			Destroy(gameObject);
		}
	}
}
