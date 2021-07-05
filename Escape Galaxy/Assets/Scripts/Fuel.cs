using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuel : MonoBehaviour
{
    public float fuelIncrement;
    public bool blackHole;
  //  public GameObject fuelBg;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {   
            if (other.GetComponent<Player>().fuel <= 95)
            {
               // Instantiate(fuelBg, transform.position, Quaternion.identity);
                other.GetComponent<Player>().fuel += fuelIncrement;
                if (!blackHole)
                {
                    PlayerPrefs.SetInt("FuelSpawn", 1);
                } else
                {
                    PlayerPrefs.SetInt("FuelSpawn", 2);
                }
                
            } 
            else if (other.GetComponent<Player>().fuel >= 95)
            {
               // Instantiate(fuelBg, transform.position, Quaternion.identity);
                other.GetComponent<Player>().fuel = 100;
                if (!blackHole)
                {
                    PlayerPrefs.SetInt("FuelSpawn", 1);
                }
                else
                {
                    PlayerPrefs.SetInt("FuelSpawn", 2);
                }
            }
           
        }


    }
}
