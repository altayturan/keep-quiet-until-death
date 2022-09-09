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
        if (collision.gameObject.tag == "Garbage")
            collision.gameObject.GetComponent<EtkilesimliObje>().PlaySound();

        if (collision.gameObject.tag == "Lamp")
        {
            collision.gameObject.GetComponent<EtkilesimliObje>().PlaySound();
            collision.gameObject.GetComponent<EtkilesimliObje>().shadow.SetActive(true);
            collision.gameObject.GetComponent<EtkilesimliObje>().lightSource.SetActive(false);
        }
        if(collision.gameObject.tag == "Car")
            collision.gameObject.GetComponent<EtkilesimliObje>().PlaySound();
        if(collision.gameObject.tag == "Tree")
            collision.gameObject.GetComponent<EtkilesimliObje>().PlaySound();


        Particle();
        Destroy(gameObject);
    }
}
