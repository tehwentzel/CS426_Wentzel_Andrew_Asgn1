using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public Score scoreManager;
    public bool hasScored;
    public Material scoredMaterial;

    void Start(){
        hasScored = false;
    }
    //this method is called whenever a collision is detected
    private void OnCollisionEnter(Collision collision)
    {
        //on collision adding point to the score
        Debug.Log(collision.gameObject.tag);
        if(!hasScored & collision.gameObject.tag == "Bullet"){
            scoreManager.AddPoint();
            hasScored = true;
            gameObject.GetComponent<MeshRenderer>().material = scoredMaterial;
            Destroy(collision.gameObject);
        }

        // printing if collision is detected on the console
        Debug.Log("Collision Detected");
        //after collision is detected destroy the gameobject
        // Destroy(gameObject);
    }
}