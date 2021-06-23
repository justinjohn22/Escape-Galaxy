using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanUp : MonoBehaviour
{

    public float lifetime;

    // Start is called before the first frame update
    void Start()
    {   
        // remove obstacles after lifetime ends
        Destroy(gameObject, lifetime);
    }
}
