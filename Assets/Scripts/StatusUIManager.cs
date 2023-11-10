using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StatusUIManager : MonoBehaviour
{
    public Image BuildUI;
    public Image RunUI;
    public Canvas PassCanvas;
    public Canvas InGameCanvas;
    public Button StopBut;
    public Button StartBut;
    private StatusManager StatusManager;

    void Start()
    {
        GameObject EventSystem = GameObject.FindGameObjectWithTag("EventSystem");
        if (EventSystem)
        {
            StatusManager = EventSystem.GetComponent<StatusManager>();
        } else
        {
            Debug.LogError("cant find eventsystem");
        }

        StartBut.image.enabled = false;
        StartBut.enabled = false;
        StartBut.interactable = false;

        PassCanvas.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (RunUI)
        {
            RunUI.enabled = !StatusManager.isBuild;
        }

        if (BuildUI)
        {
            BuildUI.enabled = StatusManager.isBuild;
        }

        if (GameControllerMP.instance.isPass)
        {
            InGameCanvas.enabled = false;
            PassCanvas.enabled = true;
        }
    }

    public void StopGame()
    {
        StopBut.image.enabled = false;
        StopBut.enabled = false;
        StopBut.interactable = false;
        StartBut.image.enabled = true;
        StartBut.enabled = true;
        StartBut.interactable = true;
        Time.timeScale = 0;
    }

    public void StartGame()
    {
        StartBut.image.enabled = false;
        StartBut.enabled = false;
        StartBut.interactable = false;
        StopBut.image.enabled = true;
        StopBut.enabled = true;
        StopBut.interactable = true;
        Time.timeScale = 1;
    }

    public void NextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex + 1);
    }

    public void Retry()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
