using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fuel : MonoBehaviour
{
    public float fuelIncrement;
    public bool blackHole;
    //  public GameObject fuelBg;

    private int MAX_FUEL = 100;
    private int FUEL_INCREMENT_BOUNDARY = 93;

    void OnTriggerEnter2D(Collider2D other)
    {   

        if (other.CompareTag("Player"))
        {
            if (blackHole)
            {
                fuelIncrement = other.GetComponent<Player>().fuel * 0.35f * -1;
            }

            // Debug.Log("Fuel Increment Value: " + fuelIncrement.ToString());

            if (other.GetComponent<Player>().fuel <= FUEL_INCREMENT_BOUNDARY)
            {
                other.GetComponent<Player>().fuel += fuelIncrement;
                displayFuelChange();

            } 
            else if (other.GetComponent<Player>().fuel >= FUEL_INCREMENT_BOUNDARY)
            {   
                if (!blackHole)
                {
                    other.GetComponent<Player>().fuel = MAX_FUEL;
                }
                
                displayFuelChange();
            }
           
        }

    }

    private void displayFuelChange()
    {
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
