using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float movementSpeed;

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.up * movementSpeed * Time.deltaTime);

    }
}
