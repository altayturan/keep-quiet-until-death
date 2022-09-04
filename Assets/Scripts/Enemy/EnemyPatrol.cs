using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    EnemyNavMeshMovement m_NavMeshMovement;
    Vector2 center;
    Vector2 target;
    private void Start()
    {
        m_NavMeshMovement = GetComponent<EnemyNavMeshMovement>();
        target = RandomPosGetter(transform.position);
    }
    void FixedUpdate()
    {
        if (m_NavMeshMovement.canMove)
        {
            CancelInvoke("Patrol");
            return;
        }
        if (!IsInvoking("Patrol"))
        {
            InvokeRepeating("Patrol", 0, 3);
        }
    }

    void Patrol()
    {
        Debug.Log("SLM");
        target = (target == center ? RandomPosGetter(transform.position) : center);
        m_NavMeshMovement.SetTarget(target);
    }
    Vector2 RandomPosGetter(Vector2 value)
    {
        Vector2 pos = new Vector2(value.x + Random.Range(-2,2),value.y + Random.Range(-2,2));
        return pos;
    }
}
