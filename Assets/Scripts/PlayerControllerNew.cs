using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerNew : MonoBehaviour
{
    private StatusManager StatusManager;
    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();

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

    private void Update()
    {
        if (StatusManager.isBuild)
        {
            rb.useGravity = false;
            rb.isKinematic = true;
        }
        else
        {
            rb.useGravity = true;
            rb.isKinematic = false;
            Vector3 moveDirection = -1 * StatusManager.axisDirection.x * transform.right;
            rb.MovePosition(rb.position + moveDirection * Time.deltaTime);
        }
    }
}
