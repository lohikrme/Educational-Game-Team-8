
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

    public int maxHealth = 100;
    public int currentHealth;
    private float counter;

    public HealthBar healthBar;

    void Start()
    {
        GlobalVariables.currentHealth = GlobalVariables.maxHitpoints;
        healthBar.SetMaxHealth(GlobalVariables.maxHitpoints);
    }


    // HERE U DECIDE HOW FAST HP DEPLETES DUE TO INHALING SMOKE
    void Update()
    {
        if (GlobalVariables.currentHealth > 0 && GlobalVariables.charAtBlueHouse == true)
        {
            counter += Time.deltaTime;

            while (counter >= 1)
            {
                TakeDamage(3); 
                counter = 0;
            }
        }
        else if (GlobalVariables.currentHealth <= 0)
        {
            GlobalVariables.charIsDead = true;
            healthBar.SetHealth(GlobalVariables.currentHealth);
        }
    }

    void TakeDamage(int damage)
    {
        GlobalVariables.currentHealth -= damage;

        healthBar.SetHealth(GlobalVariables.currentHealth);
    }

}
