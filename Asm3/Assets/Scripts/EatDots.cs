using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatDots : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    // Eat the dots
    void OnTriggerEnter2D(Collider2D co)
    {
        if (co.name == "pacman")
            Destroy(gameObject);
    }
}
