using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class CampainSpawning : MonoBehaviour
{
    private int levelNum;

    public GameObject wasp, fastWasp, strongWasp, ladyBug, centipede;
    private GameObject manager;
    public bool waveStartAgain, okToSpawn;
    float currCountdownValue;
    public GameObject tText;
    public Text timertxt;
    public bool levelFin;
    private bool canSpawnLB;
    float countdownValue = 5;

    int y = 0; int i = 0;

    List<int> waspsToSpawn = new List<int>();

    private void Start()
    {
        canSpawnLB = true;
        levelNum = SceneManager.GetActiveScene().buildIndex;
        waveStartAgain = true;
        okToSpawn = true;
        levelFin = false;
        manager = GameObject.Find("GameManager");
        manager.GetComponent<LevelManager>().playingCampain = true;
        StartCoroutine(EndedRoundd());
        Spawn();

    }
    private void Update()
    {
        if(!levelFin)
        {
            SpawnSelectedWasps(waspsToSpawn);
            if(levelNum >= 8 && canSpawnLB)
            {
                StartCoroutine(SpawnLadyBug());
            }
        }
        else
        {
            // Finish level screen
            manager.GetComponent<LevelManager>().EndLevel(false);
        }
    }
    private void Spawn()
    {
        switch (levelNum) // choose what to be spawned
        {
            case 0:
                break;
            case 1:
                waspsToSpawn.Add(7);
                break;
            case 2:
                waspsToSpawn.Add(0);
                waspsToSpawn.Add(0);
                break;
            case 3:
                waspsToSpawn.Add(0);
                waspsToSpawn.Add(1);
                waspsToSpawn.Add(0);
                break;
            case 4:
                waspsToSpawn.Add(1);
                waspsToSpawn.Add(1);
                waspsToSpawn.Add(0);
                break;
            case 5:
                waspsToSpawn.Add(1);
                waspsToSpawn.Add(2);
                waspsToSpawn.Add(1);
                break;
            case 6:
                waspsToSpawn.Add(2);
                waspsToSpawn.Add(1);
                waspsToSpawn.Add(2);
                break;
            case 7:
                waspsToSpawn.Add(0);
                waspsToSpawn.Add(3);
                waspsToSpawn.Add(0);
                break;
            case 8:
                waspsToSpawn.Add(3);
                waspsToSpawn.Add(0);
                waspsToSpawn.Add(3);
                break;
            case 9:
                waspsToSpawn.Add(2);
                waspsToSpawn.Add(4);
                waspsToSpawn.Add(0);
                break;
            case 10:
                waspsToSpawn.Add(5);
                waspsToSpawn.Add(0);
                waspsToSpawn.Add(6);
                break;


        }
        CalcWaspsToKill();
    }
    private void CalcWaspsToKill()
    {
        int temp = 0;
        for(int i = 0; i < waspsToSpawn.Count; i++)
        {
            switch(waspsToSpawn[i])
            {
                case 0:
                    temp += 5;
                    break;
                case 1:
                    temp += 3;
                    break;
                case 2:
                    temp += 4;
                    break;
                case 3:
                    temp += 3;
                    break;
                case 4:
                    temp += 8;
                    break;
                case 5:
                    temp += 20;
                    break;
                case 6:
                    temp += 30;
                    break;
                case 7:
                    temp += 5;
                    break;

            }
        }
        this.gameObject.GetComponent<LevelManager>().waspsTappedToNextWave = temp;
    }
    private void SpawnSelectedWasps(List<int> toSpawn)
    {
        if (!waveStartAgain && y < toSpawn.Count)
        {
            switch(toSpawn[y]) // spawn a selection of wasps
            {
                case 0: // 5 wasps

                    if(i < 5)
                    {
                        SpawnOne(wasp, new Vector3(Random.Range(-4, 5), 11, 0), 2.0f);
                    }
                    else
                    {
                        y++;
                        i = 0;
                    }
                    break;
                case 1: // 3 fast wasps
                    if (i < 3)
                    {
                        int toggle = Random.Range(0, 2);
                        if (toggle == 0)
                        {
                            SpawnOne(fastWasp, new Vector3(4, 11, 0), 1.5f);
                        }
                        else
                        {
                            SpawnOne(fastWasp, new Vector3(-4, 11, 0), 1.5f);
                        }
                    }
                    else
                    {
                        y++;
                        i = 0;
                    }
                    break;
                case 2: // 4 strong wasps
                    if (i < 4)
                    {
                        SpawnOne(strongWasp, new Vector3(Random.Range(-4, 5), 11, 0), 1.0f);
                    }
                    else
                    {
                        y++;
                        i = 0;
                    }
                    break;
                case 3: // mix 1
                    if (i < 3)
                    {
                        switch(i)
                        {
                            case 0:
                                SpawnOne(fastWasp, new Vector3(4, 11, 0), 0.0f);
                                break;
                            case 1:
                                SpawnOne(fastWasp, new Vector3(-4, 11, 0), 0.0f);
                                break;
                            case 2:
                                SpawnOne(strongWasp, new Vector3(Random.Range(-4, 5), 11, 0), 1.0f);
                                break;
                        }
                    }
                    else
                    {
                        y++;
                        i = 0;
                    }
                    break;
                case 4: // mix 2
                    if (i < 8)
                    {
                        switch (i)
                        {
                            case 0:
                                SpawnOne(strongWasp, new Vector3(Random.Range(-4, 5), 11, 0), 0.5f);
                                break;
                            case 1:
                                SpawnOne(fastWasp, new Vector3(-4, 11, 0), 0.0f);
                                break;
                            case 2:
                                SpawnOne(fastWasp, new Vector3(4, 11, 0), 0.5f);
                                break;
                            case 3:
                                SpawnOne(strongWasp, new Vector3(0, 11, 0), 0.0f);
                                break;
                            case 4:
                                SpawnOne(wasp, new Vector3(Random.Range(-4, 5), 11, 0), 1.0f);
                                break;
                            case 5:
                                SpawnOne(fastWasp, new Vector3(4, 11, 0), 0.5f);
                                break;
                            case 6:
                                SpawnOne(strongWasp, new Vector3(Random.Range(-4, 5), 11, 0), 0.5f);
                                break;
                            case 7:
                                SpawnOne(fastWasp, new Vector3(4, 11, 0), 1.0f);
                                break;
                        }
                    }
                    else
                    {
                        y++;
                        i = 0;
                    }
                    break;
                case 5: // mix 3
                    if (i < 20)
                    {
                        SpawnOne(fastWasp, new Vector3(0, 11, 0), 0.3f);
                    }
                    else
                    {
                        y++;
                        i = 0;
                    }
                    break;
                case 6: // mix 4
                    if (i < 30)
                    {
                        if(i % 2 == 0)
                        {
                            SpawnOne(fastWasp, new Vector3(0, 11, 0), 0.3f);
                        }
                        else
                        {
                            SpawnOne(strongWasp, new Vector3(Random.Range(-4, 5), 11, 0), 0.6f);
                        }
                    }
                    else
                    {
                        y++;
                        i = 0;
                    }
                    break;
                case 7: //boss
                    SpawnOne(centipede, new Vector3(0, 8, 0), 20f);
                    break;

            }
        }
        else if (y >= toSpawn.Count)
        {
            levelFin = true;
        }
    }
    private void SpawnOne(GameObject waspy, Vector3 pos, float timeToWait)
    {
        if (okToSpawn && !levelFin)
        {
            Instantiate(waspy, pos, Quaternion.identity);
            i++;
            okToSpawn = false;
            StartCoroutine(WaitToSpawnn(timeToWait));
        }
    }

    IEnumerator SpawnWasp()
    {
        yield return new WaitForSeconds(3 - manager.GetComponent<LevelManager>().GetWaveNum() / 5);
        Instantiate(wasp, new Vector3(Random.Range(-4, 5), 11, 0), Quaternion.identity);
    }
    IEnumerator SpawnFastWasp()
    {
        yield return new WaitForSeconds(3 - manager.GetComponent<LevelManager>().GetWaveNum() / 5);
        Instantiate(fastWasp, new Vector3(Random.Range(-4, 5), 11, 0), Quaternion.identity);
    }
    IEnumerator SpawnStrongWasp()
    {
        yield return new WaitForSeconds(3 - manager.GetComponent<LevelManager>().GetWaveNum() / 5);
        Instantiate(strongWasp, new Vector3(Random.Range(-4, 5), 11, 0), Quaternion.identity);
    }

    IEnumerator WaitToSpawnn(float timeToWait)
    {
        yield return new WaitForSeconds(timeToWait);
        okToSpawn = true;
    }
    IEnumerator EndedRoundd()
    {
        StartCoroutine(StartCountdownn());
        yield return new WaitForSeconds(5.0f);
        waveStartAgain = false;
        
    }

    IEnumerator StartCountdownn()
    {
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
    IEnumerator SpawnLadyBug()
    {
        canSpawnLB = false;
        yield return new WaitForSeconds(Random.Range(15, 40));
        if (!levelFin)
        {
            Instantiate(ladyBug, new Vector3(Random.Range(-4, 5), 11, 0), Quaternion.identity);
            canSpawnLB = true;
        }
    }

}
