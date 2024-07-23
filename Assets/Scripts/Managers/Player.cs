using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private int _health;
    private GameObject gameManager;
    public Sprite fiveHealth, fourHealth, threeHealth, twoHealth, oneHealth, zeroHealth;
    SpriteRenderer sp;
    public GameObject healthSprite;
    private void Start()
    {
        sp = healthSprite.GetComponent<SpriteRenderer>();
        gameManager = GameObject.Find("GameManager");
        _health = 5; 
    }
    public void DecHealth()
    {
        _health--;
        SetSprite();
    }
    private void IncHealth()
    {
        _health++;
        SetSprite();
    }
    private void Update()
    {
        if(_health <= 0)
        {
            //gameManager.GetComponent<LevelManager>().wonGame = false;
            gameManager.GetComponent<LevelManager>().EndLevel(true);
        }
    }
    private void FixedUpdate()
    {
        SetSprite();
    }
    private void SetSprite()
    {
        switch(_health)
        {
            case 0:
                sp.sprite = zeroHealth;
                break;
            case 1:
                sp.sprite = oneHealth;
                break;
            case 2:
                sp.sprite = twoHealth;
                break;
            case 3:
                sp.sprite = threeHealth;
                break;
            case 4:
                sp.sprite = fourHealth;
                break;
            case 5:
                sp.sprite = fiveHealth;
                break;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Wasp" && _health > 0)
        {
            DecHealth();
        }
        else if(other.gameObject.tag == "LadyBug")
        {
            if(_health <= 5)
            {
                IncHealth();
            }
            gameManager.GetComponent<LevelManager>().IncLadyBugSaved();
        }
    }
}
