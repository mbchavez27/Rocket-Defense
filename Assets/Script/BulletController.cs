using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    //Get Components
    Rigidbody2D rb2d;

    //Bullet Attributes
    public float bulletSpeed = 50f;
    public GameObject earthParticles;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.up * bulletSpeed * Time.deltaTime;
    }

    void OnBecameInvisible()
    {
        Destroy(this.gameObject);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "earth")
        {
            MeteorController.hit = true;
            UIManager.health -= .1f;
            Instantiate(earthParticles, this.gameObject.transform.position, this.gameObject.transform.rotation);
            CameraShake.ShakeShakeCamera();
            Destroy(this.gameObject);
        }
    }
}
