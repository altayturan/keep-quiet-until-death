using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField, Header("0 is default, 1 is sneak, 2 is run")] 
    private float[] allSpeeds;
    private int activeSpeed = 0;
    private Transform player;
    [SerializeField] private Transform playerShootPos;
    Animator animator;
    Vector2 activeState;
    private bool rightPressed => Input.GetKey(KeyCode.D);
    private bool leftPressed => Input.GetKey(KeyCode.A);
    private bool upPressed => Input.GetKey(KeyCode.W);
    private bool downPressed => Input.GetKey(KeyCode.S);
    private bool runPressed => Input.GetKey(KeyCode.LeftShift);
    private bool sneakPressed => Input.GetKey(KeyCode.LeftControl);
    void Start()
    {
        player = GetComponent<Transform>();
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        Move();
        Rotate();
        //if satýrý kaldýrýlýrsa sapan çekerken sneak olmasýna raðmen default ses çýkarýr
        if(!GetComponent<PlayerSlingshot>().GetShooting())
            MovementSpeed();
    }
    void MovementSpeed()
    {
        if (sneakPressed)
            SetActiveSpeed(1);
        else if (runPressed && activeState.magnitude != 0  && GetComponent<Player>().LoseStamina(1))
            SetActiveSpeed(2);
        else if (rightPressed || leftPressed || downPressed || upPressed)
            SetActiveSpeed(0);
        else
            SetActiveSpeed(1);
    }
    void Move()
    {
        activeState = new Vector2(0, 0);

        if (rightPressed)
            activeState += Vector2.right;
        if (leftPressed)
            activeState += Vector2.left;
        if (upPressed)
            activeState += Vector2.up;
        if (downPressed)
            activeState += Vector2.down;

        player.Translate(activeState * allSpeeds[activeSpeed] * Time.deltaTime, Space.World);

        if (activeState.magnitude != 0)
            animator.SetBool("isWalking", true);
        else
            animator.SetBool("isWalking", false);
        if(runPressed)
            animator.SetBool("isRunning", true);
        else
            animator.SetBool("isRunning", false);
    }
    void Rotate()
    {
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 dir = worldPosition - player.position;
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        player.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
    }
    public void SetActiveSpeed(int value) { activeSpeed = value; GetComponent<PlayerNoise>().SetRange(value); }
    public int GetActiveSpeed() { return activeSpeed; }
    public Transform GetPlayerShootPos() { return playerShootPos; }
}
