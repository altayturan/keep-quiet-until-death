using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovements : MonoBehaviour
{
  public Transform target;

    public float yumos = 0.025f;
    public Vector3 offset;

    private void LateUpdate()
    {
        Vector3 anlikPos = target.position + offset;
        Vector3 yumosPos = Vector3.Lerp(transform.position, anlikPos, yumos);
        transform.position = new Vector3(yumosPos.x,yumosPos.y,yumosPos.z - 10);
    }
}
