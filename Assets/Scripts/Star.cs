using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    private StatusManager StatusManager;

    public GameObject vfx;
    private void Start()
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

    private void OnTriggerEnter(Collider other)
    {
        if ((other.CompareTag("Player") || other.CompareTag("Player3D")) && !StatusManager.isBuild)
        {
            //add score
            GameControllerMP.instance.AddScore();

            //play sfx


            //play vfx
            // Instantiate(vfx, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
