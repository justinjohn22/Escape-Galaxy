using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float playerSpeed;
    public int health;
    public Text healthDisplay;
 

    private Shake shake;
    private bool movingLeft;
    private bool firstInput;
    private float boost;

    private bool sideBoost;

    private float startTime, endTime;

    // Start is called before the first frame update
    void Start()
    {
        movingLeft = true;
        firstInput = false;
        boost = 4.5f; // defualt = 4
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();
        sideBoost = false;
    
    }

    // Update is called once per frame
    void Update()
    {
        healthDisplay.text = health.ToString();

        if (transform.position.y < 2)
        {
            shake.CamShake();
            transform.Translate(Vector2.up * Time.deltaTime * boost);
        }

        if (health < 0)
        {
            SceneManager.LoadScene("GameOver");
        }

        if (Input.GetMouseButtonDown(0))
        {
            firstInput = true;
            movingLeft = !movingLeft;
            startTime = Time.time;
            sideBoost = true;
        } 

        if (Input.GetMouseButtonUp(0))
        {
            startTime = 0;
            sideBoost = false;
        }

        Debug.Log(endTime - startTime);

        if (firstInput)
        {   
 
            if (movingLeft && startTime > 0.1f)
            {
                transform.Translate(Vector2.left * Time.deltaTime * playerSpeed * 1.5f);
            } 
            else if (!movingLeft && startTime > 0.1f)
            {
                transform.Translate(Vector2.right * Time.deltaTime * playerSpeed * 1.5f);   
            }
       
            else if (movingLeft && !sideBoost)
            {
                transform.Translate(Vector2.left * Time.deltaTime * playerSpeed);
            }
            else if (!movingLeft && !sideBoost)
            {
                transform.Translate(Vector2.right * Time.deltaTime * playerSpeed);
            }
            
        } 
      
    }
}
