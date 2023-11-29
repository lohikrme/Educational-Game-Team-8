// locates in mainscene - canvas - MainMenuButton

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuButtonScript : MonoBehaviour
{
    public Button mainMenuButton;

    private void Start()
    {
        mainMenuButton.onClick.AddListener(MainMenuButtonClick);
    }

    void Update()
    {
        // Check if the 'M' key was pressed
        if (Input.GetKeyDown(KeyCode.M))
        {
            MainMenuButtonClick();
        }
    }

    // go to the 'MainMenu' scene
    private void MainMenuButtonClick()
    {
        SceneManager.LoadScene("MainMenu");


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