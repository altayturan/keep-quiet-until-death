using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] int maxHealth, maxStamina;
    int health, stamina;
    PlayerMovement playerMovement;

    private void Start() { GainHealth(maxHealth); GainStamina(maxStamina); playerMovement = GetComponent<PlayerMovement>(); }
    public int GetHealth() { return health; }
    public int GetStamina() { return stamina; }
    public void SetHealth(int value) { health = value; }
    public void SetStamina(int value) { stamina = value; }

    private void Update()
    {
        if(playerMovement != null)
        if (playerMovement.GetActiveSpeed() != 2)
            GainStamina(1);
    }
    public void GainHealth(int value)
    {
        SetHealth(health + value);
        if (GetHealth() > maxHealth) SetHealth(maxHealth);
        else if (GetHealth() < 0) Debug.Log("ah!");
        UI.ui.SetSlider(UI.ui.healthBar, maxHealth, health);
    }
    public void GainStamina(int value)
    {
        SetStamina(stamina + value);
        if (GetStamina() > maxStamina) SetStamina(maxStamina);
        UI.ui.SetSlider(UI.ui.staminaBar, maxStamina, stamina);
    }
    public bool LoseStamina(int value)
    {
        SetStamina(stamina - value);
        if (GetStamina() < 0) return false;
        UI.ui.SetSlider(UI.ui.staminaBar, maxStamina, stamina);
        return true;
    }
}