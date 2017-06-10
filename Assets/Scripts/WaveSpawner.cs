﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour {

	public Transform[] listEnemyPrefab;

	public Transform spawnPoint;
	float timeCountDown = 2f;

	private int indexWave = 0;
	private int indexEnemy = 0;
	private float timeNextEnemy = 0f;
	private float timeNextWave = 0f;

	// Update is called once per frame
	void Update () {

		if (LoadLevel.instance.timeStart <= Time.timeSinceLevelLoad)
		{
			if(indexWave < LoadLevel.instance.totalWave && timeNextWave <= 0)
			{
				if (indexEnemy < (int)LoadLevel.instance.dataWaves[indexWave,WaveElement.enemyNum] && timeNextEnemy <= 0) {
					int lane = (int)LoadLevel.instance.dataWaves[indexWave,WaveElement.enemyLane];
					if (lane == 5) {
						lane = Random.Range (0, 5); // random 0 1 2 3 4
					} else if (lane == 6) {
						lane = Random.Range (0, 2); // random 0 1
					} else if (lane == 7) {
						lane = Random.Range (3, 5); // random 3 4
					} else if (lane == 8) {
						lane = Random.Range (1, 4); // random 1 2 3
					}

					SpawnEnemy (indexWave, lane);
					timeNextEnemy = LoadLevel.instance.dataWaves[indexWave,WaveElement.timeNextEnemy];
					indexEnemy++;
				} else if(indexEnemy == (int)LoadLevel.instance.dataWaves[indexWave,WaveElement.enemyNum]){
					indexEnemy = 0;
					timeNextEnemy = 0;
					timeNextWave = LoadLevel.instance.dataWaves[indexWave,WaveElement.timeNextWave];
					indexWave++;
				}


			}
			timeNextEnemy -= Time.deltaTime;
			timeNextWave -= Time.deltaTime;

		}

		timeCountDown -= Time.deltaTime;
	}

	void SpawnEnemy(int indexwave, int lane)
	{	
		spawnPoint = WayPoints.instance.points[lane];
		Instantiate (listEnemyPrefab[indexwave], spawnPoint.position, spawnPoint.rotation);
	}
}
