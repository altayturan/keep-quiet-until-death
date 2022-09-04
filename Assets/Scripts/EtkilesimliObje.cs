using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EtkilesimliObje : MonoBehaviour
{
    [SerializeField] private ObjectMaker om;

    private Sprite artwork;
    private AudioSource audioSource;
    private float range;
    void Start()
    {
        GetComponent<SpriteRenderer>().sprite = om.sprite;
        //audioSource = om.audioClip;
        range = om.range;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Ses oynatma kodu
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }
    
}
