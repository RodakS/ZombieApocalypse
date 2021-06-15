using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonScripts : MonoBehaviour
{
    public GameObject DifficultyButtonsObject;
    public GameObject MenuButtonsObject;

    public void StartClick()
    {
        DifficultyButtonsObject.SetActive(true);
        MenuButtonsObject.SetActive(false);
    }

    public void ExitClick()
    {
        Debug.Log("Game is closing");
        Application.Quit();
    }

    public void GoBackClick()
    {
        DifficultyButtonsObject.SetActive(false);
        MenuButtonsObject.SetActive(true);
    }

    public void EasyDifficultyClick()
    {
        StaticDifficulty.playerHPOption = 50000;
        StaticDifficulty.zombieSpawnAmountOption = 3;
        StaticDifficulty.zombieSpawnSpeedOption = 0.2f;
        SceneManager.LoadScene(1);
    }    
    public void MediumDifficultyClick()
    {
        StaticDifficulty.playerHPOption = 40000;
        StaticDifficulty.zombieSpawnAmountOption = 6;
        StaticDifficulty.zombieSpawnSpeedOption = 0.1f;
        SceneManager.LoadScene(1);
    }    
    public void HardDifficultyClick()
    {
        StaticDifficulty.playerHPOption = 30000;
        StaticDifficulty.zombieSpawnAmountOption = 8;
        StaticDifficulty.zombieSpawnSpeedOption = 0.1f;
        SceneManager.LoadScene(1);
    }
    public void GoToMenuClick()
    {
        SceneManager.LoadScene(0);
    }
}
