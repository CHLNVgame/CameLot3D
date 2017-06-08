using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour {

	public Transform[] listEnemyPrefab;

	public Transform spawnPoint;
	float timeCountDown = 2f;


	// Update is called once per frame
	void Update () {
		if (timeCountDown <= 0f) 
		{
			SpawnEnemy ();
			timeCountDown = 2f;
		}

		timeCountDown -= Time.deltaTime;
	}

	void SpawnEnemy()
	{	
		int id = Random.Range (0, listEnemyPrefab.Length);
		spawnPoint = WayPoints.points[Random.Range (0, 5)];
		Instantiate (listEnemyPrefab[0], spawnPoint.position, spawnPoint.rotation);
	}
}
