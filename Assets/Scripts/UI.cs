using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public static UI ui;


    [SerializeField]
    GameObject interactButton;

    private void Start()
    {
        if (ui == null) ui = this;
    }

    public void SetInteractButton(bool value) { interactButton.SetActive(value); }
    public void InstantiateUIObject(GameObject gameObject) { Instantiate(gameObject, this.gameObject.transform); }
}
