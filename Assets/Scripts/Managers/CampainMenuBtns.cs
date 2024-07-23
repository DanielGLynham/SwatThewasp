using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CampainMenuBtns : MonoBehaviour
{
    public int levelNumber;

    public void LevelBtnClick()
    {
        SceneManager.LoadScene(levelNumber);
    }
}
