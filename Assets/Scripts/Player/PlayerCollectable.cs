using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollectable : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Interact"))
            UI.ui.SetActive(UI.ui.interactButton, true);
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(collision.gameObject.name.Split('-')[0] == "Collectable")
            {
                if (collision.gameObject.name.Split('-')[1] == "Note")
                    UI.ui.InstantiateUIObject(collision.gameObject.GetComponent<CollectableNotes>().GetNote());
                else if (collision.gameObject.name.Split('-')[1] == "Scrap")
                    UI.ui.InstantiateUIObject(collision.gameObject.GetComponent<CollectableNotes>().GetNote());
                else if (collision.gameObject.name.Split('-')[1] == "Health")
                    GetComponent<PlayerStats>().GainHealth(20);
                else if (collision.gameObject.name.Split('-')[1] == "Bullet")
                    UI.ui.InstantiateUIObject(collision.gameObject.GetComponent<CollectableNotes>().GetNote());
                UI.ui.SetActive(UI.ui.interactButton, false);
                Destroy(collision.gameObject);
            }
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Interact"))
            UI.ui.SetActive(UI.ui.interactButton, false);
    }
}
