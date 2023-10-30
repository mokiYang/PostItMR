using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerNew : MonoBehaviour
{
    private StatusManager StatusManager;
    public float playerSpeed;
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
            rb.freezeRotation = false;
        }
        else
        {
            rb.useGravity = true;
            rb.isKinematic = false;
            rb.freezeRotation = true;
            Vector3 moveDirection = -1 * StatusManager.axisDirection.x * transform.right;
            rb.MovePosition(rb.position + moveDirection * playerSpeed * Time.deltaTime);
        }
    }
}
