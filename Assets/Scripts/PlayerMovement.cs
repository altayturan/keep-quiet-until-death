using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField, Header("0 is default, 1 is sneak, 2 is run")] 
    private float[] allSpeeds;
    private int activeSpeed = 0;
    private Transform player;

    private bool rightPressed => Input.GetKey(KeyCode.D);
    private bool leftPressed => Input.GetKey(KeyCode.A);
    private bool upPressed => Input.GetKey(KeyCode.W);
    private bool downPressed => Input.GetKey(KeyCode.S);
    private bool runPressed => Input.GetKey(KeyCode.LeftShift);
    private bool sneakPressed => Input.GetKey(KeyCode.LeftControl);
    void Start()
    {
        player = GetComponent<Transform>();
    }
    void Update()
    {
        MovementSpeed();
        Move();
        Rotate();
    }
    void MovementSpeed()
    {
        if (sneakPressed)
            SetActiveSpeed(1);
        else if (runPressed)
            SetActiveSpeed(2);
        else if (rightPressed || leftPressed || downPressed || upPressed)
            SetActiveSpeed(0);
        else
            SetActiveSpeed(1);
    }
    void Move()
    {
        if(rightPressed)
            player.Translate(Vector2.right * allSpeeds[activeSpeed] * Time.deltaTime, Space.World );
        if (leftPressed)
            player.Translate(Vector2.left * allSpeeds[activeSpeed] * Time.deltaTime, Space.World );
        if (upPressed)
            player.Translate(Vector2.up * allSpeeds[activeSpeed] * Time.deltaTime,Space.World );
        if (downPressed)
            player.Translate(Vector2.down * allSpeeds[activeSpeed] * Time.deltaTime, Space.World );
    }
    void Rotate()
    {
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 dir = worldPosition - player.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        player.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
    }
    public void SetActiveSpeed(int value) { activeSpeed = value; GetComponent<PlayerNoise>().SetRange(value); }
}
