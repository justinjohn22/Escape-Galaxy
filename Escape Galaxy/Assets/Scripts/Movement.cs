using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    public float movementSpeed;
    private float startTime;
    private bool specialPlayer;

    void Start()
    {
        if (PlayerPrefs.GetInt("SelectedPlayer") == 4 || PlayerPrefs.GetInt("SelectedPlayer") == 6)
        {
            specialPlayer = true;
        } else
        {
            specialPlayer = false;
        }
    }

    // Update is called once per frame
    void Update()
    {   

        transform.Translate(Vector2.up * movementSpeed * Time.deltaTime);
      
        if (specialPlayer)
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
