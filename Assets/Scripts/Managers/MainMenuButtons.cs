using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    public GameObject mainMenuManager;

    public void PlayGameBtn()
    {
        mainMenuManager.GetComponent<MainMenuManager>().Play();
    }
    public void OptionsBtn()
    {
        mainMenuManager.GetComponent<MainMenuManager>().Options();
    }
    public void ExitBtn()
    {
        Application.Quit();
    }
    public void PlayCampaignBtn()
    {
        mainMenuManager.GetComponent<MainMenuManager>().Campain();
    }
    public void PlayHuntTheWaspBtn()
    {

    }
    public void PlayEndlessModeBtn()
    {
        SceneManager.LoadScene("SwatTheWasp");
    }
    public void BackToMainMenu()
    {
        mainMenuManager.GetComponent<MainMenuManager>().MainMenu();
    }
}
