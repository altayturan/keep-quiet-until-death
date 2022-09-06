using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableNotes : MonoBehaviour
{
    [SerializeField] GameObject note;

    public GameObject GetNote() { return note; }
}
