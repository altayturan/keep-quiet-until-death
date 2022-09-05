using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slingshot : MonoBehaviour
{
    float totalRange, speed;
    GameObject hitEffect, player;
    void Start()
    {
        GetComponent<Rigidbody2D>().velocity = (player.transform.up).normalized * speed;
        Debug.Log("range = " + totalRange + "   /    speed = " + speed);
        Invoke("Particle", totalRange / speed);
        Destroy(this.gameObject, totalRange / speed);
    }
    void Particle() { Destroy(Instantiate(hitEffect, transform.position, Quaternion.identity), 5f); }
    public void SetVariables(float speed,  float totalRange, GameObject hitEffect, GameObject player) 
    {
        this.speed = speed; 
        this.totalRange = totalRange;
        this.hitEffect = hitEffect;
        this.player = player;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Particle();
        Destroy(gameObject);
    }
}
