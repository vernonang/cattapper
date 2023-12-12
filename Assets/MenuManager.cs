using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public GameObject settingsMenu;
    public GameObject upgradeMenu;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void openSettingsMenu()
    {
        settingsMenu.SetActive(true);
    }

    public void closeSettingsMenu()
    {
        settingsMenu.SetActive(false);
    }

    public void openUpgrades()
    {
        upgradeMenu.SetActive(true);
    }

    public void closeUpgrades()
    {
        upgradeMenu.SetActive(false);
    }

    public void exitGame()
    {
        Application.Quit();
    }
}
