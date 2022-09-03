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
        Rotate();
    }

    void Move()
    {
        if(rightPressed)
            player.Translate(Vector2.right * speed * Time.deltaTime, Space.World );
        if (leftPressed)
            player.Translate(Vector2.left * speed * Time.deltaTime, Space.World );
        if (upPressed)
            player.Translate(Vector2.up * speed * Time.deltaTime,Space.World );
        if (downPressed)
            player.Translate(Vector2.down * speed * Time.deltaTime, Space.World );
    }

    void Rotate()
    {
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 dir = worldPosition - player.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        player.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
    }
}
