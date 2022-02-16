using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidReset : MonoBehaviour
{
  void OnTriggerEnter2D(Collider2D other)
  {
    if (other.CompareTag("Empty") || other.CompareTag("EmptyRight"))
    {
      PlayerPrefs.SetInt("AsteroidCount", 0);
    }
  }
}
