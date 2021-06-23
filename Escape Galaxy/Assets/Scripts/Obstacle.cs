using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public int damage;
    public bool remove;
    public bool instantKill;
    public GameObject effect;

    private int ZERO = 0;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (!instantKill)
            {
                other.GetComponent<Player>().health -= damage;
            } else
            {   
                other.GetComponent<Player>().health = ZERO;
            }
            
            if (remove)
            {
                Instantiate(effect, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
        }
    }
}
