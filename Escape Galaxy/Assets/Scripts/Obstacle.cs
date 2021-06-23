using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public int damage;
    public bool remove;
    public bool instantKill;
    public GameObject effect;

    private Shake shake;
    private int GAME_OVER = 0;

    void Start()
    {
        shake = GameObject.FindGameObjectWithTag("ScreenShake").GetComponent<Shake>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (!instantKill)
            {   
                other.GetComponent<Player>().health -= damage;
                shake.CamShake();
            } else
            {   
                other.GetComponent<Player>().health = GAME_OVER;
            }
            
            if (remove)
            {
                Instantiate(effect, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
}
