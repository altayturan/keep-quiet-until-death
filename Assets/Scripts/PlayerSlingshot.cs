using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSlingshot : MonoBehaviour
{
    [Range(0, 100), SerializeField] float rangePercent;
    [SerializeField]
    float range = 5f, percentIncrease = 1f;
    [SerializeField]
    bool shooting;

    private void Update()
    {
        if (Input.GetMouseButtonDown(1) && !GetShooting())
            SetShooting(true);
        if (Input.GetMouseButton(1) && GetShooting())
            HoldShooting();
        if (Input.GetMouseButtonUp(1) && GetShooting())
            Shoot();
    }

    public void SetShooting(bool value) => shooting = value;
    public bool GetShooting() { return shooting; }
    public void HoldShooting()
    {
        rangePercent += percentIncrease * Time.deltaTime;
        rangePercent = Mathf.Clamp(rangePercent, 0, 100);
        GetComponent<PlayerMovement>().SetActiveSpeed(1);
    }
    public void Shoot()
    {
        SetShooting(false);
        rangePercent = 0;
        GetComponent<PlayerMovement>().SetActiveSpeed(0);
    }
}
