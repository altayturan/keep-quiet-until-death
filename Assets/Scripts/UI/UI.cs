using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public static UI ui;


    public GameObject
    interactButton,
    healthBar,
    staminaBar,
    scrapText,
    bulletText;


    private void Awake() { if (ui == null) ui = this; }

    public void SetActive(GameObject gameObject, bool value) { gameObject.SetActive(value); }
    public void SetSlider(GameObject gameObject, int maxValue, int currValue) { gameObject.GetComponent<Slider>().maxValue = maxValue; gameObject.GetComponent<Slider>().value = currValue; }
    public void InstantiateUIObject(GameObject gameObject) { Instantiate(gameObject, this.gameObject.transform); }
}