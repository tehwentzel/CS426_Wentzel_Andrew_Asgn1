using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public Score scoreManager;

    //this method is called whenever a collision is detected
    private void OnCollisionEnter(Collision collision)
    {
        //on collision adding point to the score
        scoreManager.RemovePoint();
        // printing if collision is detected on the console
        Debug.Log("Collision Detected");
        //after collision is detected destroy the gameobject
        Destroy(gameObject);
    }
}