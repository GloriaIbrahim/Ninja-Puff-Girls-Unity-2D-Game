﻿using UnityEngine;
using System.Collections;

public class DeadPeople : MonoBehaviour {

    // Use this for initialization
    void Start()
    {

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Gloria" || other.tag == "Meran" || other.tag == "Lorina")
        {
            FindObjectOfType<HealthController>().takeDamage(1);
            Debug.Log("Triggered");
        }
    }
    // Update is called once per frame
    void Update()
    {

    }
}
