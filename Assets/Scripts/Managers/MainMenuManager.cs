using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuManager : MonoBehaviour
{
    public GameObject mainMainMenu, playMainMenu, optionsMainMenu, campainMenu;
    private void Start()
    {
        mainMainMenu.SetActive(true);
        playMainMenu.SetActive(false);
        optionsMainMenu.SetActive(false);
        campainMenu.SetActive(false);
    }
    public void Play()
    {
        mainMainMenu.SetActive(false);
        playMainMenu.SetActive(true);
        optionsMainMenu.SetActive(false);
        campainMenu.SetActive(false);
    }
    public void Options()
    {
        mainMainMenu.SetActive(false);
        playMainMenu.SetActive(false);
        optionsMainMenu.SetActive(true);
        campainMenu.SetActive(false);
    }
    public void Campain()
    {
        mainMainMenu.SetActive(false);
        playMainMenu.SetActive(false);
        optionsMainMenu.SetActive(false);
        campainMenu.SetActive(true);
    }
    public void MainMenu()
    {
        mainMainMenu.SetActive(true);
        playMainMenu.SetActive(false);
        optionsMainMenu.SetActive(false);
        campainMenu.SetActive(false);
    }
}
