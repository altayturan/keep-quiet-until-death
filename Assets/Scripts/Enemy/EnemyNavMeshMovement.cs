using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavMeshMovement : MonoBehaviour
{
    [SerializeField]
    Transform target;
    NavMeshAgent agent;
    [SerializeField]
    public bool canMove = false, canPlayer = true;
    //gecici kod
    GameObject player;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        player = GameObject.Find("Player");
    }
    private void Update()
    {
        SetCanMove();   
        agent.SetDestination(target.position);
        
        Aim();
    }
    void Aim()
    {
        Vector3 targ = target.transform.localPosition;
        targ.z = 0f;

        Vector3 objectPos = transform.localPosition;
        targ.x = targ.x - objectPos.x;
        targ.y = targ.y - objectPos.y;

        float angle = Mathf.Atan2(targ.y, targ.x) * Mathf.Rad2Deg;
        transform.localRotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
    public void SetTarget(Vector2 position) { target.position = position; }
    public Vector3 GetTarget() { return target.position; }

    public void SetCanMove()
    {
        if(Vector2.Distance(transform.position,GetTarget()) < 1f)
        {
            canMove = false;
            return;
        }
        canMove = true;    
    }

    public void SetTargetPos(Vector2 value) { target.position = value; }
    public void SetCanPlayer(bool value) { canPlayer = value; }
    public bool GetCanPlayer() { return canPlayer; }
}