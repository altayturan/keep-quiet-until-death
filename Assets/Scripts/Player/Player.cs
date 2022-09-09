using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public float health;
    public int scrapMetal;
    public int bullet, maxBullet;
    public string sceneName;
    public int cutscene;

    [SerializeField] float maxHealth, maxStamina;
    float stamina;
    PlayerMovement playerMovement;
    [ContextMenu("Save")]

    
    public void Save()
    {
        DataSaver.Save(this);
    }
    [ContextMenu("Load")]
    public void Load()
    {
        Player player = DataSaver.Load(this);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        string tag = collision.tag;
        if (tag == "Grass" || tag == "Garbage" || tag == "Lamp" || tag == "Tree")
            collision.GetComponent<EtkilesimliObje>().PlaySound();
    }
    private void Start() 
    {
        GainHealth(0);
        GainStamina(maxStamina);
        GainBullet(0);
        GainScrap(0);
        playerMovement = GetComponent<PlayerMovement>();

        Load();

    }
    public float GetHealth() { return health; }
    public float GetStamina() { return stamina; }
    public void SetHealth(float value) { health = value; }
    public void SetStamina(float value) { stamina = value; }

    private void Update()
    {
        if (playerMovement != null)
            if (playerMovement.GetActiveSpeed() != 2)
                GainStamina(1);
    }
    public void GainHealth(float value)
    {
        SetHealth(health + value);
        if (GetHealth() > maxHealth) SetHealth(maxHealth);
        else if (GetHealth() < 0) Debug.Log("ah!");
        UI.ui.SetSlider(UI.ui.healthBar, maxHealth, health);
    }
    public void LoseHealth(float value)
    {
        SetHealth(GetHealth() - value);
        if (GetHealth() < 0)
            SceneManager.LoadScene(sceneName);
        UI.ui.SetSlider(UI.ui.healthBar, maxHealth, health);
    }
    public void GainStamina(float value)
    {
        SetStamina(stamina + value);
        if (GetStamina() > maxStamina) SetStamina(maxStamina);
        UI.ui.SetSlider(UI.ui.staminaBar, maxStamina, stamina);
    }
    public bool LoseStamina(float value)
    {
        SetStamina(stamina - value);
        if (GetStamina() < 0) return false;
        UI.ui.SetSlider(UI.ui.staminaBar, maxStamina, stamina);
        return true;
    }
    public void GainBullet(int value)
    {
        if (bullet + value <= maxBullet)
            bullet += value;
        UI.ui.SetText(UI.ui.bulletText, bullet.ToString());
    }
    public bool LoseBullet(int value)
    {
        if (bullet - value >= 0)
        {
            bullet -= value;
            UI.ui.SetText(UI.ui.bulletText, bullet.ToString());
            return true;
        }
        return false;
    }
    public void GainScrap(int value)
    {
        scrapMetal += value;
        UI.ui.SetText(UI.ui.scrapText, scrapMetal.ToString());
    }
}
