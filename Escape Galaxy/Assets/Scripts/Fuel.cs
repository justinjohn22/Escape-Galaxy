using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuel : MonoBehaviour
{
    public float fuelIncrement;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {   
            if (other.GetComponent<Player>().fuel <= 95)
            {
                other.GetComponent<Player>().fuel += fuelIncrement;
            } 
            else if (other.GetComponent<Player>().fuel >= 95)
            {
                other.GetComponent<Player>().fuel = 100;
            }
           
        }
    }
}
