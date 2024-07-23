using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    private int waspsKilled;
    private int fastWaspsKilled;
    private int strongWaspsKilled;
    private int totalWaspsKilled;
    public int waspsTappedToNextWave;
    private int waspsTappedThisWave;
    private int wave;
    private int ladyBugsSaved;
    private int ladyBugsKilled;
    private int healthLost;
    private float timeSinceStart;
    private int score;

    public Text scoreText;
    public Text waveText;
    public Text waspsToNextWave;
    public Text waspsKilledUI, LadyBugsKilledUI, LadyBugsSavedUI;
    
    GameObject spawner, player;
    public bool playingCampain = true;

    public GameObject wonLevelUI, LostLevelUI, duringLevelUI, generalEndLevelUI;
    public bool wonGame;
    public int toEndLevelCounter;

    private void Start()
    {
        toEndLevelCounter = 0;
        spawner = GameObject.Find("GameManager");
        player = GameObject.Find("Player");

        waspsKilled = 0;
        fastWaspsKilled = 0;
        strongWaspsKilled = 0;
        totalWaspsKilled = 0;
        wave = 1;
        ladyBugsSaved = 0;
        healthLost = 0;
        timeSinceStart = 0;
        waspsTappedThisWave = 0;

        score = 0;
        if (SceneManager.GetActiveScene().buildIndex == 0 || SceneManager.GetActiveScene().name == "MainMenu")
        {
            playingCampain = false;
            waspsTappedToNextWave = wave * 6;
        }

        wonLevelUI.SetActive(false);
        LostLevelUI.SetActive(false);
        duringLevelUI.SetActive(true);
        generalEndLevelUI.SetActive(false);
    }
    public void IncWaspKilled()
    {
        ChangeScore(1);
        waspsKilled++;
        waspsTappedThisWave++;
        totalWaspsKilled++;
        toEndLevelCounter++;
    }
    public void IncFastWaspKilled()
    {
        toEndLevelCounter++;
        ChangeScore(1);
        fastWaspsKilled++;
        waspsTappedThisWave++;
        totalWaspsKilled++;
    }
    public void IncStrongWaspKilled()
    {
        toEndLevelCounter++;
        ChangeScore(1);
        strongWaspsKilled++;
        waspsTappedThisWave++;
        totalWaspsKilled++;
    }
    public void IncWave()
    {
        if (playingCampain)
        {
            spawner.GetComponent<CampainSpawning>().waveStartAgain = true;
        }
        else
        {
            spawner.GetComponent<Spawning>().waveStartAgain = true;
            waspsTappedToNextWave = wave * 6;
        }
        wave++;
        waspsTappedThisWave = 0;
    }
    public int GetWaveNum()
    {
        return wave;
    }
    public void IncLadyBugSaved()
    {
        ladyBugsSaved++;
    }
    public void IncLadyBugKilled()
    {
        if(!playingCampain)
        {
            toEndLevelCounter++;
        }
        player.GetComponent<Player>().DecHealth();
        ChangeScore(-5);
        ladyBugsKilled++;
    }
    public void IncHealthLost()
    {
        healthLost++;
    }
    public void ChangeScore(int num)
    {
        score += num;
    }
    private void Update()
    {
        timeSinceStart += Time.deltaTime;
        scoreText.text = "Score: "+ score;
        int waspsLeft = waspsTappedToNextWave - waspsTappedThisWave;
        if(playingCampain)
        {
            waspsToNextWave.text = "Next Level: " + waspsLeft;
            waveText.text = "Level: " + SceneManager.GetActiveScene().buildIndex;
        }
        else
        {
            waspsToNextWave.text = "Next Wave: " + waspsLeft;
            waveText.text = "Wave: " + wave;

            if(waspsTappedToNextWave == waspsTappedThisWave)
            {
                IncWave();
            }
        }
    }
    public void EndLevel(bool playerDied)
    {
        if(!playingCampain)
        {

            this.gameObject.GetComponent<Spawning>().gameOver = true;
        }
        else
        {
            this.gameObject.GetComponent<CampainSpawning>().levelFin = true;
        }
        waspsKilledUI.text = "wasps killed: " + totalWaspsKilled + "\n :)";
        LadyBugsKilledUI.text = "Lady Bugs killed: " + ladyBugsKilled + "\n :(";
        LadyBugsSavedUI.text = "Lady Bugs Saved: " + ladyBugsSaved + "\n :)";

        if ((toEndLevelCounter >= waspsTappedToNextWave))
        {
            wonLevelUI.SetActive(true);
            LostLevelUI.SetActive(false);
            duringLevelUI.SetActive(false);
            generalEndLevelUI.SetActive(true);
        }
        else if(playerDied)
        {
            wonLevelUI.SetActive(false);
            LostLevelUI.SetActive(true);
            duringLevelUI.SetActive(false);
            generalEndLevelUI.SetActive(true);
        }
    }
}
