using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    public RuntimeAnimatorController Red;
    public RuntimeAnimatorController Green;
    private StatusManager StatusManager;

    void Start()
    {
        GameObject EventSystem = GameObject.FindGameObjectWithTag("EventSystem");
        if (EventSystem)
        {
            StatusManager = EventSystem.GetComponent<StatusManager>();
        }
        else
        {
            Debug.LogError("cant find eventsystem");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (StatusManager.isBuild)
        {
            gameObject.GetComponent<Animator>().runtimeAnimatorController = Red;
        } else
        {
            gameObject.GetComponent<Animator>().runtimeAnimatorController = Green;
        }
    }
}
