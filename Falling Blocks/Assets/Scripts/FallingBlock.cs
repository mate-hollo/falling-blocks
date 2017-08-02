using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBlock : MonoBehaviour {

	public Vector2 speedMinMax;
	float speed;

	void Start()
	{
		speed = Mathf.Lerp(speedMinMax.x, speedMinMax.y, Difficulty.GetDifficultyPercent());	
	}

	void Update () {
		//Move the block down
		transform.Translate(Vector2.down * speed * Time.deltaTime);
		Debug.Log(speed);
		
	}
}
