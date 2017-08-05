using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockSpawner : MonoBehaviour {

	public GameObject FallingBlockPrefab;
	public Vector2 spawnCooldownMinMax;
	public float maxBlockAngle;
	public Vector2 blockSizeMinMax;
	float blockHalfWidth;

	Vector2 screenHalfSizeWorldUnits;
	float nextSpawnTime;

	void Start () {

		//calculate the game screen size
		screenHalfSizeWorldUnits = new Vector2(Camera.main.aspect * Camera.main.orthographicSize, Camera.main.orthographicSize);

		//calculate half the blocks width -> no overlap on the sides
		blockHalfWidth = transform.localScale.x / 2;

	}
	
	// Update is called once per frame
	void Update () {
		//spawn blocks after cooldown is over
		if (Time.time > nextSpawnTime)
		{
			float spawnCooldown = Mathf.Lerp(spawnCooldownMinMax.y, spawnCooldownMinMax.x, Difficulty.GetDifficultyPercent());
			nextSpawnTime = Time.time + spawnCooldown;

			//calculate random block size and angle
			float blockSize = Random.Range(blockSizeMinMax.x, blockSizeMinMax.y);
			float blockAngle = Random.Range(-maxBlockAngle, maxBlockAngle);

			//set spawnposition so that blocks won't overlap with sides or top
			Vector2 spawnPosition = new Vector2(Random.Range(-screenHalfSizeWorldUnits.x + blockHalfWidth, screenHalfSizeWorldUnits.x - blockHalfWidth), screenHalfSizeWorldUnits.y + blockSize);
			//instantiate
			GameObject block = Instantiate(FallingBlockPrefab, spawnPosition, Quaternion.Euler(Vector3.forward * blockAngle)) ;
			//change instantiated block's size
			block.transform.localScale = Vector3.one * blockSize;


			
		}

		

		
	}
	

	
}
