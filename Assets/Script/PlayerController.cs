using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //Get Components
    Rigidbody2D rb2d;
    AudioSource audioSource;
    public AudioClip shoot;


    //Player Attributes
    public float moveSpeed = 10f;
    public float rotateSpeed = 10f;
    float ammo;
    public float maxammo = 20f;
    public Transform gunSpawn;
    public GameObject lazers;

    //Shooting Attributes
    public float shootRate, shootDelay = .3f;



    void Start()
    {
        ammo = maxammo;
        audioSource = GetComponent<AudioSource>();
        rb2d = GetComponent<Rigidbody2D>();   
    }

    void Update()
    {
        if (Time.timeScale == 1)
        {
            Movements();
            Shooting();
            UIManager.ammonum = ammo;
        }

        if (!SoundController.soundon)
        {
            audioSource.enabled = false;
        }
    }

    void Movements()
    {
        //Move Up
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.up * moveSpeed * Time.deltaTime;
        }
        //Rotate
        if (Input.GetKey(KeyCode.A)) //Rotate Left
        {
            transform.Rotate(0f, 0f, rotateSpeed * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.D)) //Rotate Right
        {
            transform.Rotate(0f, 0f, -rotateSpeed * Time.deltaTime);
        }
    }

    void Shooting()
    {
        if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0) && ammo > 0)
        {
            shootRate += 1 * Time.deltaTime;
            if (shootRate >= shootDelay)
            {
                shootRate = 0f;
                audioSource.PlayOneShot(shoot);
                Instantiate(lazers, gunSpawn.position, gunSpawn.rotation);
                ammo--;
                if(ammo <= 0)
                {
                    StartCoroutine(Reload());
                }
            }
        }
    }

   
    IEnumerator Reload()
    {
        ammo = 0;
        yield return new WaitForSeconds(1f);
        ammo = maxammo;
    }
}
