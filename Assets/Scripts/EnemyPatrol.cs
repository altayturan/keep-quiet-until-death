using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    EnemyNavMeshMovement m_NavMeshMovement;
    Vector2 oldPos;
    private void Start()
    {
        m_NavMeshMovement = GetComponent<EnemyNavMeshMovement>();
    }
    void Update()
    {
        if(this.transform.position == m_NavMeshMovement.GetTarget())
        {
            oldPos = m_NavMeshMovement.GetTarget();
            GoToPos(new Vector2(transform.position.x + Random.Range(0, 5), transform.position.y + Random.Range(0, 5)));
            return;
        }
        GoToPos(oldPos);
    }
    void GoToPos(Vector2 value)
    {
        transform.Translate(value);
    }
}
