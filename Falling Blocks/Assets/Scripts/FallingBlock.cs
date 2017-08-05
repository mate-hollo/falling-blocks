using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBlock : MonoBehaviour {

	public Vector2 speedMinMax;
	float speed;
	float visibleHeightTreshold;

	void Start()
	{
		//increase the block speed with difficulty
		speed = Mathf.Lerp(speedMinMax.x, speedMinMax.y, Difficulty.GetDifficultyPercent());

		//get height treshold value where the falling block has already left the screen
		visibleHeightTreshold = -Camera.main.orthographicSize - transform.localScale.y;
	}

	void Update () {
		//Move the block down
		transform.Translate(Vector2.down * speed * Time.deltaTime);
		
		//destory gameobject if it reaches the bottom of the screen
		if (transform.position.y < visibleHeightTreshold)
		{
			Destroy(gameObject);
		}
		
	}
}
