using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawning : MonoBehaviour
{
    public GameObject wasp, fastWasp, strongWasp, ladyBug;
    private GameObject manager;
    public bool waveStartAgain, okToSpawn;
    float currCountdownValue;
    public GameObject tText;
    public Text timertxt;
    public bool gameOver;

    public void Start()
    {
        gameOver = false;
        waveStartAgain = true;
        okToSpawn = true;
        manager = GameObject.Find("GameManager");
        StartCoroutine(EndedRound());
        StartCoroutine(Spawn());
    }
    private void Update()
    {
        if (!waveStartAgain && okToSpawn && !gameOver)
        {
            GameObject spawnable = ChooseWasp();
            if (spawnable == fastWasp)
            {
                Instantiate(fastWasp, new Vector3(0, 11, 0), Quaternion.identity);
                okToSpawn = false;
                StartCoroutine(Spawn());
            }
            else
            {
                Instantiate(spawnable, new Vector3(Random.Range(-4, 5), 11, 0), Quaternion.identity);
                okToSpawn = false;
                StartCoroutine(Spawn());
            }
        }

        if(waveStartAgain == true)
        {
            StartCoroutine(EndedRound());
        }
    }
    private GameObject ChooseWasp()
    {
        int rand;
        int wave = manager.GetComponent<LevelManager>().GetWaveNum();
        if (wave < 4)
        {
            rand = 0;
        }
        else if(wave > 3 && wave < 6)
        {
            rand = Random.Range(0, 1);
        }
        else if(wave > 5 && wave < 8)
        {
            rand = Random.Range(0, 2);
        }
        else
        {
            rand = rand = Random.Range(0, 5);
        }

        GameObject ret;
        switch (rand)
        {
            case 0:
                ret = wasp;
                break;
            case 1:
                ret = fastWasp;
                break;
            case 2:
                ret = strongWasp;
                break;
            case 3:
                ret = ladyBug;
                break;
            default:
                ret = wasp;
                break;
        }
        return ret;
    }
    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(3 - manager.GetComponent<LevelManager>().GetWaveNum() / 5 );
        okToSpawn = true;
    }
    IEnumerator EndedRound()
    {
        StartCoroutine(StartCountdown());
        yield return new WaitForSeconds(5.0f);
        waveStartAgain = false;
    }

    IEnumerator StartCountdown()
    {
        float countdownValue = 5;
        tText.SetActive(true);
        currCountdownValue = countdownValue;
        timertxt.text = "--" + currCountdownValue + "--";
        while (currCountdownValue > 0)
        {
            yield return new WaitForSeconds(1.0f);
            currCountdownValue--;
            timertxt.text = "--" + currCountdownValue + "--";
        }
        tText.SetActive(false);
    }
}
