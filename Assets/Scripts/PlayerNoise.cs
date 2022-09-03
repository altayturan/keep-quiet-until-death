using UnityEngine;

public class PlayerNoise : MonoBehaviour
{
    private float range;

    [SerializeField, Header("0 is default, 1 is sneak, 2 is run, 3 is fire")]
    private float[] allRanges;
    [SerializeField]
    private LayerMask enemyLayer;

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, allRanges[0]);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(this.transform.position, allRanges[1]);
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(this.transform.position, allRanges[2]);
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(this.transform.position, allRanges[3]);
    }
    public void SetEnemyNoise()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(this.transform.position, range, Vector2.zero, 1000, enemyLayer);
        foreach (var rycst in hits)
        {
            rycst.collider.gameObject
        }
    }
}
