using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{

  public bool moveLeft;

  // Update is called once per frame
  void Update()
  {
    if (moveLeft)
    {
      transform.Translate(Vector2.left * 3 * Time.deltaTime);
    }
    else
    {
      transform.Translate(Vector2.right * 3 * Time.deltaTime);
    }

  }
}
