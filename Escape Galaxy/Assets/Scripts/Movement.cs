using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float movementSpeed;
    private float startTime;
    private bool specialPlayer;

    private bool stinger, timeWarp;

    void Start()
    {
        stinger = false;
        timeWarp = false;
         
        if (PlayerPrefs.GetInt("SelectedPlayer") == 4)
        {
            stinger = true;
        } 

        if (PlayerPrefs.GetInt("SelectedPlayer") == 6)
        {
            timeWarp = true;
        }
    }

    // Update is called once per frame
    void Update()
    {   

        transform.Translate(Vector2.up * movementSpeed * Time.deltaTime);
      
        if (stinger || timeWarp)
        {
            if (Input.GetMouseButtonDown(0))
            {
                startTime = Time.time;
            }

            if (Input.GetMouseButtonUp(0))
            {
                startTime = 0;
            } 

            if (startTime > 5f)
            {   
                if (stinger)
                {
                    transform.Translate(Vector2.up * 1.5f * Time.deltaTime);
                }
                
                if (timeWarp)
                {
                    transform.Translate(Vector2.up * 2.5f * Time.deltaTime);
                }
            }

        }

    }
}
