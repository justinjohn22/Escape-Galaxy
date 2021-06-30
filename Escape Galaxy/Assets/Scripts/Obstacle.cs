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
    private int KILL_VALUE = -1;

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
                shake.CamShake();
                other.GetComponent<Player>().health -= damage;
            } 
            else
            {   
                other.GetComponent<Player>().health = KILL_VALUE;
            }
            
            if (remove)
            {
                Instantiate(effect, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
}
