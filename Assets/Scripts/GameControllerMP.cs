using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControllerMP : MonoBehaviour
{
    public static GameControllerMP instance;

    public int score = 0;
    public int index = 0;

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

    public void LoadNextLevel()
    {
        index++;
        SceneManager.LoadScene(index);
    }
}
