using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{

  // Update is called once per frame
  void Update()
  {
    transform.Translate(Vector2.right * 3 * Time.deltaTime);
  }
}
