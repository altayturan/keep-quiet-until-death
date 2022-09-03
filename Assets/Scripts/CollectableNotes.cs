using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableNotes : MonoBehaviour
{
    GameObject note;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            UI.ui.SetInteractButton(true);
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            if (Input.GetKeyDown(KeyCode.E))
                UI.ui.InstantiateUIObject(note);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            UI.ui.SetInteractButton(false);
    }
}
