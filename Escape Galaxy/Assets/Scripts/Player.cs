using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    private bool movingLeft;
    public float playerSpeed;
    public int health;

    // Start is called before the first frame update
    void Start()
    {
        movingLeft = true;
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
            movingLeft = true;
        }

        if (!movingLeft)
        {
            transform.Translate(Vector2.left * Time.deltaTime * playerSpeed);
        }

        if (Input.GetMouseButtonDown(0))
        {
            movingLeft = !movingLeft;
            if (!movingLeft)
            {
                transform.Rotate(0, -180, 0);
            }
            else
            {
                transform.Rotate(0, 180, 0);
            }
        }
    }
}
