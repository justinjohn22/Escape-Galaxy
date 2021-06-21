using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float playerSpeed;
    public int health;

    private bool movingLeft;
    private bool firstInput;

    // Start is called before the first frame update
    void Start()
    {
        movingLeft = true;
        firstInput = false;
    }

    // Update is called once per frame
    void Update()
    {   
        if (health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
