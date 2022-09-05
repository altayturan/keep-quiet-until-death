using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGunshot : MonoBehaviour
{

    [SerializeField]
    float speed = 1f, reloadTime = 1f;
    bool canShoot = true;
    [SerializeField]
    GameObject bullet, hitEffect;

    PlayerMovement playerMovement;

    bool canTwice = true;
    public void SetCanTwice(bool value) { canTwice = value; }
    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }
    private void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0) && canShoot && canTwice)
            Shoot();
    }
    void Shoot()
    {
        GameObject throws = Instantiate(bullet, playerMovement.GetPlayerShootPos().position, Quaternion.identity);
        throws.GetComponent<Gunshot>().SetVariables(speed, hitEffect, this.gameObject);
        StartCoroutine(ReloadTime());
    }
    IEnumerator ReloadTime()
    {
        canShoot = false;
        yield return new WaitForSeconds(reloadTime);
        canShoot = true;
    }
}
