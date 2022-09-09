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
            if (collision.gameObject.name.Contains("Scene"))
            {
                GetComponent<Player>().sceneName = SceneManager.GetActiveScene().name;
                GetComponent<Player>().Save();
                SceneManager.LoadScene(collision.gameObject.name);
            }
            if (collision.gameObject.name.Split('-')[0] == "Collectable")
            {
                if (collision.gameObject.name.Split('-')[1].Contains("Note"))
                    UI.ui.InstantiateUIObject(collision.gameObject.GetComponent<CollectableNotes>().GetNote());
                else if (collision.gameObject.name.Split('-')[1].Contains("Scrap"))
                    GetComponent<Player>().GainScrap(3 * Random.Range(1,3));
                else if (collision.gameObject.name.Split('-')[1].Contains("Health"))
                    GetComponent<Player>().GainHealth(20);
                else if (collision.gameObject.name.Split('-')[1].Contains("Bullet"))
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
