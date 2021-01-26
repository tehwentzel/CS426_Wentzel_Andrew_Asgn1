// using __ imports namespace
// Namespaces are collection of classes, data types
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// MonoBehavior is the base class from which every Unity Script Derives
public class PlayerMovement : MonoBehaviour
{
    public float speed = 25.0f;
    public float rotationSpeed = 90;
    public float force = 2f;
    public float chargeTimer;
    public float groundHeight;

    public GameObject cannon;
    public GameObject bullet;

    Rigidbody rb;
    Transform t;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        t = GetComponent<Transform>();
        chargeTimer = 0;
        groundHeight = gameObject.transform.position.y;
    }

    void OnEnable(){
        groundHeight = gameObject.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        // Time.deltaTime represents the time that passed since the last frame
        //the multiplication below ensures that GameObject moves constant speed every frame
        if (Input.GetKey(KeyCode.W))
            rb.velocity += this.transform.forward * speed * Time.deltaTime;
        else if (Input.GetKey(KeyCode.S))
            rb.velocity -= this.transform.forward * speed * Time.deltaTime;

        // Quaternion returns a rotation that rotates x degrees around the x axis and so on
        if (Input.GetKey(KeyCode.D))
            t.rotation *= Quaternion.Euler(0, rotationSpeed * Time.deltaTime, 0);
        else if (Input.GetKey(KeyCode.A))
            t.rotation *= Quaternion.Euler(0, -rotationSpeed * Time.deltaTime, 0);

        if (Input.GetKeyDown(KeyCode.Space)){
            if(gameObject.transform.position.y <= groundHeight*1.1){
                rb.AddForce(t.up * force);
            }
        }

        // https://docs.unity3d.com/ScriptReference/Input.html
        if (Input.GetButtonDown("Fire1"))
        {
            chargeTimer = Time.time;
        }
        else if (Input.GetButton("Fire1")){
            if(Time.time - chargeTimer > 5){
                Debug.Log("charged");
            }
        }
        else if(Input.GetButtonUp("Fire1")){
            float chargeMultiplier = Mathf.Max(1, 10*(Time.time - chargeTimer));
            
            GameObject newBullet = GameObject.Instantiate(bullet, cannon.transform.position, cannon.transform.rotation) as GameObject;
            Vector3 bulletVelocity = (t.forward * 200) + t.up*10;
            bulletVelocity = bulletVelocity * Mathf.Min(chargeMultiplier, 50.0f);
            newBullet.GetComponent<Rigidbody>().AddForce(bulletVelocity);
        }

    }
}
