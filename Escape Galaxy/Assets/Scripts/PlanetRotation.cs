using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetRotation : MonoBehaviour
{
    // Update is called once per frame
    public float spinValue;
    void Update()
    {
        transform.Rotate(0, 0, spinValue * Time.deltaTime);
    }
}
