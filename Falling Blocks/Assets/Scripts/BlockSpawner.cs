using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour {

	public GameObject FallingBlockPrefab;
	public float spawnCooldown;
	float blockHalfWidth;
	float blockHalfHeight;

	Vector2 screenHalfSizeWorldUnits;
	float nextSpawnTime;

	void Start () {

		//calculate the game screen size
		screenHalfSizeWorldUnits = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);

		//calculate half the blocks width -> no overlap on the sides
		blockHalfWidth = transform.localScale.x / 2;

		//calculate half the blocks height -> no overlap when spawning block on the top
		blockHalfHeight = transform.localScale.y / 2;

	}
	
	// Update is called once per frame
	void Update () {
		//spawn blocks after cooldown is over
		if (Time.time > nextSpawnTime)
		{
			Vector2 spawnPosition = new Vector2(Random.Range(-screenHalfSizeWorldUnits.x + blockHalfWidth, screenHalfSizeWorldUnits.x - blockHalfWidth), screenHalfSizeWorldUnits.y + blockHalfHeight);
			Instantiate(FallingBlockPrefab, spawnPosition, Quaternion.identity);
			nextSpawnTime += spawnCooldown;
		}

		

		
	}
}
