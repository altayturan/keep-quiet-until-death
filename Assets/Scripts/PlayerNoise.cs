using System.Collections;
using UnityEngine;

public class PlayerNoise : MonoBehaviour
{
    private float range = 0;

    [SerializeField, Header("0 is default, 1 is sneak, 2 is run, 3 is fire")]
    private float[] allRanges;
    [SerializeField]
    private LayerMask enemyLayer;
    private float decreaseCount = .05f;
    private bool canDecrease = true;
    private void Update()
    {
        SetEnemyNoise();
        DynamicRange();
    }
    void DynamicRange()
    {
        DecreaseRange();
    }
    public void SetRange(float value) { range = value;}
    public void SetRange(int value)
    {
        if (range <= allRanges[value])
        {
            SetRange(allRanges[value]);
            if (canDecrease)
                StartCoroutine(canDecreaseEnum());
        }
    }
    IEnumerator canDecreaseEnum()
    {
        canDecrease = false;
        yield return new WaitForSeconds(.5f);
        canDecrease = true;
    }
    void DecreaseRange() { if (range >= allRanges[1] && canDecrease) SetRange(range - decreaseCount); }
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
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(this.transform.position, range);
    }
    public void SetEnemyNoise()
    {
        RaycastHit2D[] hits = Physics2D.CircleCastAll(this.transform.position, range, Vector2.zero, 1000, enemyLayer);
        foreach (var rycst in hits)
            rycst.collider.gameObject.GetComponent<EnemyNavMeshMovement>().SetTargetPos(this.transform.position);
    }
}
