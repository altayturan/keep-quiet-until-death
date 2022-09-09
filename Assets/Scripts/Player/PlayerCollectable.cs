using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
            if (collision.gameObject.name.Split('_')[0] == "Scene")
                SceneManager.LoadScene(collision.gameObject.name);
            if (collision.gameObject.name.Split('-')[0] == "Scene")
                SceneManager.LoadScene(collision.gameObject.name);
            if (collision.gameObject.name.Split('-')[0] == "Collectable")
            {
                if (collision.gameObject.name.Split('-')[1] == "Note")
                    UI.ui.InstantiateUIObject(collision.gameObject.GetComponent<CollectableNotes>().GetNote());
                else if (collision.gameObject.name.Split('-')[1] == "Scrap")
                    GetComponent<Player>().GainScrap(3 * Random.Range(1,3));
                else if (collision.gameObject.name.Split('-')[1] == "Health")
                    GetComponent<Player>().GainHealth(20);
                else if (collision.gameObject.name.Split('-')[1] == "Bullet")
                    GetComponent<Player>().GainBullet(1);
                UI.ui.SetActive(UI.ui.interactButton, false);
                Destroy(collision.gameObject);
            }
            if (collision.gameObject.name == "InSceneTeleporter")
                gameObject.transform.position = collision.gameObject.GetComponent<TeleporterData>().GetTransform().position;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Interact"))
            UI.ui.SetActive(UI.ui.interactButton, false);
    }
}
