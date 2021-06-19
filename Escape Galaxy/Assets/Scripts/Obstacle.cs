using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public int damage;
    public bool remove;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponent<Player>().health -= damage;
            Debug.Log(other.GetComponent<Player>().health);
            if (remove)
            {
                Destroy(gameObject);
            }
        }
    }
}
