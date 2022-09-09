using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscene : MonoBehaviour
{
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            Next();
    }
    private void Next()
    {
        animator.SetTrigger("Next");
    }
    public void Close()
    {
        Destroy(gameObject);
    }
    public void PlayerCanShoot() { GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerGunshot>().SetCanShoot(true); }
    public void PlayerCantShoot() { GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerGunshot>().SetCanShoot(false); }
}
