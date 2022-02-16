using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
 public GameObject[] obstaclePattern;
 public float startTimeBtwSpawn;
 public float decreaseTime;
 public float minTime = 0.65f;


 private bool initial = true;
 private float timeBtwSpawn;

 // Update is called once per frame
 void Update()
 {
  if (timeBtwSpawn <= 0)
  {
   int randInt = Random.Range(0, obstaclePattern.Length);
   if (!initial)
   {
    Instantiate(obstaclePattern[randInt], transform.position, Quaternion.identity);
   }
   else
   {
    initial = false;
   }

   timeBtwSpawn = startTimeBtwSpawn;

   if (startTimeBtwSpawn >= minTime)
   {
    startTimeBtwSpawn -= decreaseTime;
   }

  }
  else
  {
   timeBtwSpawn -= Time.deltaTime;
  }

 }
}
