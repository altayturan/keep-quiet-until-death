using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(AudioSource))]
public class EtkilesimliObje : MonoBehaviour
{
    
    [SerializeField] private AudioClip[] audioClip;
    [SerializeField] private float range;
    [SerializeField]
    private LayerMask enemyLayer;
    public GameObject shadow, lightSource;

    private AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if(audioClip.Length > 1)
            audioSource.clip = audioClip[Random.Range(0, audioClip.Length)];
        else
            audioSource.clip = audioClip[0];

    }

    public void PlaySound()
    {
        Debug.Log("Çalýþtý");
        audioSource.PlayOneShot(audioSource.clip,1f);

        StartCoroutine(InteractEnum());
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
    IEnumerator InteractEnum()
    {

        RaycastHit2D[] hits = Physics2D.CircleCastAll(this.transform.position, range, Vector2.zero, 1000, enemyLayer);
        foreach (var rycst in hits)
            if (rycst.collider.gameObject.GetComponent<EnemyNavMeshMovement>() != null)
            {
                rycst.collider.gameObject.GetComponent<EnemyNavMeshMovement>().SetTargetPos(this.transform.position);
                rycst.collider.gameObject.GetComponent<EnemyNavMeshMovement>().SetCanPlayer(false);
                yield return new WaitForSeconds(3f);
                rycst.collider.gameObject.GetComponent<EnemyNavMeshMovement>().SetCanPlayer(true);
            }

       
    }
}
