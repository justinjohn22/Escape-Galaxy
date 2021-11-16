using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetRotation : MonoBehaviour
{
  // Update is called once per frame
  public float spinValue;

  private int randInt;

  void Start()
  {
    randInt = Random.Range(-1, 1);

    if (randInt == 0)
    {
      randInt++;
    }
  }
  void Update()
  {
    transform.Rotate(0, 0, spinValue * Time.deltaTime * randInt);
  }
}
