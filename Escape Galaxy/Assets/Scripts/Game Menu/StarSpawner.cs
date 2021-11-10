using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpawner : MonoBehaviour
{

    public GameObject[] starArray;


    private float timer = 0.0f;
    private float timer_value = 5;

    // Update is called once per frame
    // Update is called once per frame
    void Update()
    {
        timer += 0.2f;
        if (timer > timer_value)
        {
            timer = 0.0f; 
            int randInt = Random.Range(0, starArray.Length);
            Instantiate(starArray[randInt], transform.position, Quaternion.identity);
            timer_value = Random.Range(4, 10);
            // Debug.Log(timer_value);
        }
    }
}
