using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cutscene : MonoBehaviour
{
    public int value;
    Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
        if (value <= PlayerPrefs.GetInt("Cutscene", 0))
            Destroy(gameObject);
        else
            PlayerPrefs.SetInt("Cutscene", PlayerPrefs.GetInt("Cutscene", 0) + 1);
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
