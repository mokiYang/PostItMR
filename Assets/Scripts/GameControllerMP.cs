using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControllerMP : MonoBehaviour
{
    public static GameControllerMP instance;

    public int score = 0;
    // public int scenceIndex = 0;
    public bool isPass = false;

    public void Awake()
    {
        instance = this;
    }

    public int GetScore()
    {
        return score;
    }

    public void AddScore()
    {
        score ++;
    }

    public void Pass()
    {
        isPass = true;
    }

    public void LoadNextLevel()
    {
        // scenceIndex++;
        // SceneManager.LoadScene(scenceIndex);
    }

    public void ReLoadLevel()
    {
        // SceneManager.LoadScene(scenceIndex);
    }
}
