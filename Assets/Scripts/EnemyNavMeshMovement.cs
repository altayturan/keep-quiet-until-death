using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyNavMeshMovement : MonoBehaviour
{
    [SerializeField]
    Transform target;
    NavMeshAgent agent;

    private bool canMove = false;
    //gecici kod
    Transform player;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        //gecici kod
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    private void Update()
    {
        //gecici kod
        
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
    public Vector2 GetTarget() { return target.position; }

    public void SetCanMove(bool value)
    {
        canMove = value;
    }

    public void SetTargetPos(Vector2 value)
    {
        target.position = value;
    }
}