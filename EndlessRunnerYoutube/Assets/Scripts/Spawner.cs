using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour {

    private float timeBtwSpawns;
    public float startTimeBtwSpawns;
    public float timeDecrease;
    public float minTime;
    private int rand;
    public GameObject[] obstacleTemplate;
    public Score scoreManager;

    private void Start()
    {
        timeBtwSpawns = startTimeBtwSpawns;
    }

    private void Update()
    {
        if (timeBtwSpawns <= 0)
        {
            float score = scoreManager.getScore();

            if (score < 20)
            {
                 rand = Random.Range(0, (obstacleTemplate.Length / 2));
            }
            else if (score < 50)
            {
                 rand = Random.Range(0, obstacleTemplate.Length);
            }
            else
            {
                rand = Random.Range((obstacleTemplate.Length / 2), obstacleTemplate.Length);
            }

            //rand = Random.Range(0, obstacleTemplate.Length);
            Instantiate(obstacleTemplate[rand], transform.position, Quaternion.identity);
            timeBtwSpawns = startTimeBtwSpawns;
            if (startTimeBtwSpawns > minTime) {
                startTimeBtwSpawns -= timeDecrease;
            }
        }
        else {
            timeBtwSpawns -= Time.deltaTime;
        }
    }

}
