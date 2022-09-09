using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float damage;

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.transform.CompareTag("Player"))
            Damage(collision.gameObject.GetComponent<Player>());
    }

    void Damage(Player player)
    {
        player.LoseHealth(damage);
    }
}
