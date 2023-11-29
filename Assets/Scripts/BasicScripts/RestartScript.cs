// locates in mainscene - canvas - RestartButton

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RestartButtonScript : MonoBehaviour
{

    public Button restartButton;

    private void Start()
    {
        restartButton.onClick.AddListener(RestartTheGame);
    }

    void Update()
    {
        // Check if the 'R' key was pressed
        if (Input.GetKeyDown(KeyCode.R))
        {
            RestartTheGame();
        }
    }
            
    // restart the game, make sure all variables return to their original state
    private void RestartTheGame()
    {
        // Reload the current scene
        SceneManager.LoadScene("SampleScene");

        // If you've previously set Time.timeScale to 0, make sure to set it back to 1
        Time.timeScale = 1;

        // -------------------------------------------------------------------
        // RESTORE GLOBAL VARIABLES:

        GlobalVariables.maxHitpoints = 100;
        GlobalVariables.currentHealth = GlobalVariables.maxHitpoints;

        GlobalVariables.charAtA1 = false;
        GlobalVariables.charAtA2 = false;
        GlobalVariables.charAtBlueHouse = false;

        GlobalVariables.charIsDead = false;


        // ITEM INFORMATION

        GlobalVariables.fireextinguisherOnHand = false; // InventoryController updates
        GlobalVariables.lidOnHand = false; // InventoryController updates
        GlobalVariables.phoneOnHand = false; // InventoryController updates
        GlobalVariables.fryingpanOnHand = false; // InventoryController updates


        // BLUE HOUSE INFORMATION

        GlobalVariables.electricity = true; // FuseBoxScript updates


        // FIRE INFORMATION
        GlobalVariables.oilFireIsOn = true; // OilFireScript updates
        GlobalVariables.electricFireIsOn = true; // ?? possibly wont be used in final version
    }


}