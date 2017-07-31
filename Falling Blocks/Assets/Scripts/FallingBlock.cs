using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingBlock : MonoBehaviour {

	public float speed;

	void Update () {

		//Move the block down
		transform.Translate(Vector2.down * speed * Time.deltaTime);
		
	}
}
