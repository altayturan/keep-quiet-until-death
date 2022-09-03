using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float speed;
    private Transform player;

    private bool rightPressed => Input.GetKey(KeyCode.D);
    private bool leftPressed => Input.GetKey(KeyCode.A);
    private bool upPressed => Input.GetKey(KeyCode.W);
    private bool downPressed => Input.GetKey(KeyCode.S);

    void Start()
    {
        player = GetComponent<Transform>();
    }

    void Update()
    {
        Move();
    }

    void Move()
    {
        if(rightPressed)
            player.Translate(Vector2.right * speed * Time.deltaTime);
        if (leftPressed)
            player.Translate(Vector2.left * speed * Time.deltaTime);
        if (upPressed)
            player.Translate(Vector2.up * speed * Time.deltaTime);
        if (downPressed)
            player.Translate(Vector2.down * speed * Time.deltaTime);
    }

    void Rotate()
    {

    }
}
