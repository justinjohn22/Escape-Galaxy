using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelSpawn : MonoBehaviour
{

    public GameObject fuelBg;
    public GameObject fuelBgRed;
    // Update is called once per frame
    void Update()
    {
       if (PlayerPrefs.GetInt("FuelSpawn") == 1)
       {
           Instantiate(fuelBg, transform.position, Quaternion.identity);
           PlayerPrefs.SetInt("FuelSpawn", 0);
       } 
       else if (PlayerPrefs.GetInt("FuelSpawn") == 2)
       {
           Instantiate(fuelBgRed, transform.position, Quaternion.identity);
            PlayerPrefs.SetInt("FuelSpawn", 0);
        }
    }
}
