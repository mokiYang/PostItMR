using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatusUIManager : MonoBehaviour
{
    public Image BuildUI;
    public Image RunUI;
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
    }

    // Update is called once per frame
    void Update()
    {
        RunUI.enabled = !StatusManager.isBuild;
        BuildUI.enabled = StatusManager.isBuild;
    }
}
