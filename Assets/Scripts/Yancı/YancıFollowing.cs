using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YancıFollowing : MonoBehaviour
{
    Vector2 center;
    Vector2 target;
    private void Start()
    {
        target = RandomPosGetter(transform.position);
        InvokeRepeating("Patrol",0,2f);
    }

    void Patrol()
    {
        target = (target == center ? RandomPosGetter(transform.position) : center);
        transform.Translate(target);
    }
    Vector2 RandomPosGetter(Vector2 value)
    {
        Vector2 pos = new Vector2(value.x + Random.Range(-2, 2), value.y + Random.Range(-2, 2));
        return pos;
    }


}