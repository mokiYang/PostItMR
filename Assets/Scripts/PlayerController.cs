using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject ParentModule;
    public float playerSpeed;
    public float jumpForce;
    public float raycastDistance;

    private StatusManager StatusManager;
    private Rigidbody rb;
    private bool canJump = true;
    private bool isJumping = false;
    private float gravity = 15f;
    private Vector3 velocity;

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

        if (ParentModule)
        {
            // ��ȡ����� x y �᷶Χ
        }
    }

    private void Update()
    {
        if (!StatusManager.isBuild)
        {
            Vector3 moveDirection = new Vector3(-1 * StatusManager.axisDirection.x, 0, 0);
            rb.MovePosition(rb.position + moveDirection * playerSpeed * Time.fixedDeltaTime);

            if (StatusManager.isJump && canJump)
            {
                canJump = false;
                isJumping = true;
                velocity = new Vector3(0f, 0f, -1 * jumpForce);
            }

            if (isJumping)
            {
                rb.AddForce(velocity);
                velocity.z += gravity * Time.fixedDeltaTime;
                RaycastHit hit;
                Vector3 rayDirection = new Vector3(0f, 0f, 1f);

                // palyer ��ʼ�����˶���ʱ��������
                if (velocity.z > 0 && Physics.Raycast(transform.position, rayDirection, out hit, raycastDistance))
                {
                    if (hit.collider.CompareTag("Road"))
                    {
                        isJumping = false;
                        canJump = true;
                    }
                }
            }
        }
    }
}
