using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleporterData : MonoBehaviour
{
    [SerializeField] Transform transform;

    public Transform GetTransform() { return transform; }
}
