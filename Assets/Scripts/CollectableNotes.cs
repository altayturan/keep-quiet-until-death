using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableNotes : MonoBehaviour
{
    [SerializeField] GameObject note;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            UI.ui.SetInteractButton(true);
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            if (Input.GetKeyDown(KeyCode.E))
            {
                UI.ui.InstantiateUIObject(note);
                UI.ui.SetInteractButton(false);
                Destroy(gameObject);
            }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            UI.ui.SetInteractButton(false);
    }
}
