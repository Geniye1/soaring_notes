using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour {

    private PlayeController controller;

    public void Start()
    {
        controller = FindObjectOfType<PlayeController>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
        if (collision.transform.tag == "Player")
        {
            PlayeController.score += 5;
            controller.UpdateScore();
        }
    }
}
