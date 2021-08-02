using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float movementSpeed;
    private float startTime;
    private bool stingerSelected;

    void Start()
    {
        if (PlayerPrefs.GetInt("SelectedPlayer") == 4)
        {
            stingerSelected = true;
        } else
        {
            stingerSelected = false;
        }
    }

    // Update is called once per frame
    void Update()
    {   
        
        transform.Translate(Vector2.up * movementSpeed * Time.deltaTime);
       
        if (stingerSelected)
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
                transform.Translate(Vector2.up * 1.5f * Time.deltaTime);
            }

        }

    }
}
