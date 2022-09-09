using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gunshot : MonoBehaviour
{
    float speed;
    GameObject hitEffect, player;
    public GameObject deathEffect;
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = (player.transform.up).normalized * speed;
        Destroy(this.gameObject, 100f);
    }
    void Particle() { Destroy(Instantiate(hitEffect, transform.position, Quaternion.identity), 5f); }
    public void SetVariables(float speed, GameObject hitEffect, GameObject player) 
    {
        this.speed = speed; 
        this.hitEffect = hitEffect;
        this.player = player;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            Destroy(Instantiate(deathEffect, collision.transform.position, Quaternion.identity),3F);
            Destroy(collision.gameObject);
        }
        Particle();
        Destroy(gameObject);
    }
}