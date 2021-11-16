using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
  public GameObject asteroidSpawner;

  void Start()
  {
    PlayerPrefs.SetInt("SpawnAsteroid", 1);
  }

  void Update()
  {
    if (PlayerPrefs.GetInt("SpawnAsteroid", 0) == 1)
    {
      Instantiate(asteroidSpawner, transform.position, Quaternion.identity);
      PlayerPrefs.SetInt("SpawnAsteroid", 0);
    }
  }
}
