using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float playerSpeed;
    public int health;

    private Shake shake;
    private bool movingLeft;
    private bool firstInput;
    private float boost;

    // Start is called before the first frame update
    void Start()
    {
        movingLeft = true;
        firstInput = false;
        boost = 4.5f; // defualt = 4
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < 2)
        {
            shake.CamShake();
            transform.Translate(Vector2.up * Time.deltaTime * boost);
        }

        if (health <= 0)
        {
            SceneManager.LoadScene("GameOver");
        }

        if (Input.GetMouseButtonDown(0))
        {
            firstInput = true;
            movingLeft = !movingLeft;
        } 

        if (firstInput)
        {
       
            if (movingLeft)
            {
                transform.Translate(Vector2.left * Time.deltaTime * playerSpeed);
            }
            else
            {
                transform.Translate(Vector2.right * Time.deltaTime * playerSpeed);
            }
        }
      
    }
}
