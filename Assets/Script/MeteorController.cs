using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteorController : MonoBehaviour
{
    //Get Component
    Rigidbody2D rb2d;

    //Enemy Attributes
    public static float moveSpeed = 8f;
    public GameObject meteorParticles,earthParticles;
    public static bool hit;

    //Target
    Transform Earth;
    Vector2 movement;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Earth = GameObject.FindGameObjectWithTag("earth").GetComponent<Transform>();
    }


    void Update()
    {
        if (Earth != null)
        {
            Vector3 earthRotation = Earth.position - transform.position;

            transform.position = Vector3.MoveTowards(transform.position, Earth.position, moveSpeed * Time.deltaTime);
        }
        else if(Earth == null)
        {
            // Do Nothing
        }
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "lazer")
        {
            hit = true;
            Instantiate(meteorParticles, this.gameObject.transform.position, this.gameObject.transform.rotation);
            CameraShake.ShakeShakeCamera();
            UIManager.score++;
            Destroy(this.gameObject);
        }
        else if (col.tag == "earth")
        {
            hit = true;
            Instantiate(meteorParticles, this.gameObject.transform.position, this.gameObject.transform.rotation);
            Instantiate(earthParticles, this.gameObject.transform.position, this.gameObject.transform.rotation);
            UIManager.health-=.1f;
            CameraShake.ShakeShakeCamera();
            Destroy(this.gameObject);
        }
        else if (col.tag == "player")
        {
            hit = true;
            Instantiate(meteorParticles, this.gameObject.transform.position, this.gameObject.transform.rotation);
            UIManager.rockethealth-=.1f;
            CameraShake.ShakeShakeCamera();
            Destroy(this.gameObject);
        }
    }
}
