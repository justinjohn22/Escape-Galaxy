using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
  public GameObject[] asteroids;
  public bool leftSpawner;

  private string tagToCompare = "Empty";
  void OnTriggerEnter2D(Collider2D other)
  {

    if (leftSpawner)
    {
      tagToCompare = "Empty";
    }
    else
    {
      tagToCompare = "EmptyRight";
    }

    if (other.CompareTag(tagToCompare))
    {
      if (PlayerPrefs.GetInt("AsteroidCount", 0) <= 5)
      {
        int randInt = Random.Range(0, asteroids.Length);
        Instantiate(asteroids[randInt], transform.position, Quaternion.identity);

        PlayerPrefs.SetInt("AsteroidCount", PlayerPrefs.GetInt("AsteroidCount") + 1);
      }
    }
  }
}
