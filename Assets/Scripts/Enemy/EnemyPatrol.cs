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
        PatrolEnumStarter();
    }
    /*
    void FixedUpdate()
    {
        if (m_NavMeshMovement.canMove)
        {
            CancelInvoke("Patrol");
            return;
        }
        if (!IsInvoking("Patrol"))
        {
            InvokeRepeating("Patrol", 0, 4);
        }
    }
    */

    void Patrol()
    {
        target = (target == center ? RandomPosGetter(transform.position) : center);
        m_NavMeshMovement.SetTarget(target);
    }
    Vector2 RandomPosGetter(Vector2 value)
    {
        Vector2 pos = new Vector2(value.x + Random.Range(-2,2),value.y + Random.Range(-2,2));
        return pos;
    }
    void PatrolEnumStarter() { StartCoroutine(PatrolEnum()); }
    IEnumerator PatrolEnum()
    {
        yield return new WaitForSeconds(5f);
        if(m_NavMeshMovement.canMove)
            Patrol();
        PatrolEnumStarter();
    }
}