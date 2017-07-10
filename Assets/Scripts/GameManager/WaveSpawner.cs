using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour {

	Transform spawnPoint;
	float timeCountDown = 2f;

	private int indexWave = 0;
	private int indexEnemy = 0;
	private float timeNextEnemy = 0f;
	private float timeNextWave = 0f;
    private float timeDelaySelectTroop = 0f;

	// Update is called once per frame
	void Update () {

        if (BuildManager.instance.isPlay)
        {
            if (LoadLevel.instance.timeStart <= Time.timeSinceLevelLoad - timeDelaySelectTroop)
            {
                if (indexWave < LoadLevel.instance.totalWave && timeNextWave <= 0)
                {
                    if (indexEnemy < (int)LoadLevel.instance.dataWaves[indexWave, WaveElement.enemyNum] && timeNextEnemy <= 0)
                    {
                        int lane = (int)LoadLevel.instance.dataWaves[indexWave, WaveElement.enemyLane];
                        if (lane == 5)
                        {
                            lane = Random.Range(0, 5); // random 0 1 2 3 4
                        }
                        else if (lane == 6)
                        {
                            lane = Random.Range(0, 2); // random 0 1
                        }
                        else if (lane == 7)
                        {
                            lane = Random.Range(3, 5); // random 3 4
                        }
                        else if (lane == 8)
                        {
                            lane = Random.Range(1, 4); // random 1 2 3
                        }

                        SpawnEnemy((int)LoadLevel.instance.dataWaves[indexWave, WaveElement.enemyType], lane);
                        timeNextEnemy = LoadLevel.instance.dataWaves[indexWave, WaveElement.timeNextEnemy];
                        indexEnemy++;
                    }
                    else if (indexEnemy == (int)LoadLevel.instance.dataWaves[indexWave, WaveElement.enemyNum])
                    {
                        indexEnemy = 0;
                        timeNextEnemy = 0;
                        timeNextWave = LoadLevel.instance.dataWaves[indexWave, WaveElement.timeNextWave];
                        indexWave++;
                    }


                }
                timeNextEnemy -= Time.deltaTime;
                timeNextWave -= Time.deltaTime;

            }

            timeCountDown -= Time.deltaTime;
        }
        else
        {
            timeDelaySelectTroop += Time.deltaTime;
        }
	}

	void SpawnEnemy(int enemyID, int lane)
	{	
		spawnPoint = WayPoints.instance.points[lane];
		Instantiate (LoadPrefab.instance.listEnemyPrefab[enemyID], spawnPoint.position, spawnPoint.rotation);
	}
}
