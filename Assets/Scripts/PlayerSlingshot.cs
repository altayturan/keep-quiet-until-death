using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSlingshot : MonoBehaviour
{
    [SerializeField]
    float range = 5f, percentIncrease = 1f, stoneSpeed = 1f;
    float rangePercent;
    bool shooting;
    [SerializeField]
    GameObject stone, hitPoint;

    PlayerMovement playerMovement;
    GameObject hitPointer;
    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }
    private void Update()
    {
        if (Input.GetMouseButtonDown(1) && !GetShooting())
            StartShooting();
        if (Input.GetMouseButton(1) && GetShooting())
            HoldShooting();
        if (Input.GetMouseButtonUp(1) && GetShooting())
            Shoot();
    }
    public void StartShooting() { SetShooting(true); hitPointer = Instantiate(hitPoint, playerMovement.GetPlayerShootPos().position, Quaternion.identity); }
    public void SetShooting(bool value) => shooting = value;
    public bool GetShooting() { return shooting; }
    public void HoldShooting()
    {
        rangePercent += percentIncrease * Time.deltaTime;
        rangePercent = Mathf.Clamp(rangePercent, 0, 100);
        playerMovement.SetActiveSpeed(1);
        UI.ui.SetSlider(UI.ui.slingSlider, 100, (int)rangePercent);
        hitPointer.transform.position = playerMovement.GetPlayerShootPos().position + this.transform.up * (range * rangePercent / 100) * 9;
    }
    public void Shoot()
    {
        SetShooting(false);
        GameObject bullet = Instantiate(stone, playerMovement.GetPlayerShootPos().position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().AddForce(this.transform.up * stoneSpeed, ForceMode2D.Impulse);
        Destroy(bullet, range * rangePercent / 100);
        rangePercent = 0;
        UI.ui.SetSlider(UI.ui.slingSlider, 100, (int)rangePercent);
        Destroy(hitPointer);
    }
}