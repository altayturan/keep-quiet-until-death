using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Etkilesimli Obje" , menuName = "Etkilesimli Obje Yarat")]
public class ObjectMaker : ScriptableObject
{
    public Sprite sprite;
    public AudioSource audioClip;
    public float range = 5;
}
