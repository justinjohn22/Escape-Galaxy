using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionManager : MonoBehaviour
{


    private bool stopScrolling = false;

    // Start is called before the first frame update
    void Start()
    {
        // x = 4064
        // Vector3 pos = new Vector3(-10f, 0, 0);
        // shopPanel.transform.position += pos;
        // string[] ships = { "Ship 01", "Ship 02" };
        int[] shipPos = { 4079, 3299 };
        int player_index = PlayerPrefs.GetInt("SelectedPlayer");
        //string tag = ships[player_index];
        //int xPos = shipPos[player_index];

        // transform.position = new Vector3(3299, -42, 0);
        RectTransform myRectTransform = GetComponent<RectTransform>();
        myRectTransform.localPosition += Vector3.right;
        //Debug.Log(tag);

    }

    // Update is called once per frame
    void Update()
    {   
    
       // Vector3 pos = new Vector3(-0.1f, 0, 0);
        //shopPanel.transform.position += pos;

       
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //string[] ships = { "Ship 01", "Ship 02" };
        //int player_index = PlayerPrefs.GetInt("SelectedPlayer");
        //string tag = ships[player_index];
        //Debug.Log("test");
        //if (other.CompareTag(tag))
       // {
        //    stopScrolling = true;
        //}
    }
}
