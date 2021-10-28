using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuarkSpawner : MonoBehaviour
{
    public GameObject strangeQuark;

    private float time_btwn_spawn;
    private float timer;

    private float bullet_time_btwn_spawn;
    private float bullet_timer;

    private bool shoot;


    // Start is called before the first frame update
    void Start()
    {
        time_btwn_spawn = 6.0f;
        timer = 0.0f;

        bullet_time_btwn_spawn = 3.2f;
        bullet_timer = 0.0f;
        shoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        timer += 0.03f;
        if (timer > time_btwn_spawn)
        {
            bullet_timer += 0.3f;
            if(bullet_timer > bullet_time_btwn_spawn)
            {
                timer = 0.0f;
                bullet_timer = 0.0f;
            }

            if (shoot)
            {
                Instantiate(strangeQuark, transform.position, Quaternion.identity);
            }
            shoot = !shoot;


        }
    }
}
