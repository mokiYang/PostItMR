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
    private Vector3 _initialOffset;
    private Quaternion _initialRelativeRotation;

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

        // 计算初始位置偏移量
        _initialOffset = transform.position - ParentModule.transform.position;

        // 计算初始相对旋转
        _initialRelativeRotation = Quaternion.Inverse(ParentModule.transform.rotation) * transform.rotation;

        if (ParentModule)
        {
            // 获取物体的 x y 轴范围
        }
    }

    private void Update()
    {
        if (!StatusManager.isBuild)
        {
            // 计算初始位置偏移量
            _initialOffset = transform.position - ParentModule.transform.position;

            // 计算初始相对旋转
            _initialRelativeRotation = Quaternion.Inverse(ParentModule.transform.rotation) * transform.rotation;

            Vector3 moveDirection = StatusManager.axisDirection.x * transform.right;
            rb.MovePosition(rb.position + moveDirection * Time.deltaTime);
        }


        if (StatusManager.isBuild)
        {
            // 根据ParentModule的旋转更新偏移量
            Vector3 rotatedOffset = ParentModule.transform.rotation * _initialOffset;

            // 根据ParentModule的位置和旋转后的偏移量设置player的位置
            transform.position = ParentModule.transform.position + rotatedOffset;

            // 根据ParentModule的旋转和初始相对旋转设置player的旋转
            transform.rotation = ParentModule.transform.rotation * _initialRelativeRotation;
        }
    }

    private void FixedUpdate()
    {
        if (StatusManager.isBuild)
        {
            return;
        }

        // Controller();
    }

    private void Controller()
    {
        Vector3 moveDirection = new Vector3(-1 * StatusManager.axisDirection.x, 0, 0);
        RaycastHit rayHit;

        if (Physics.Raycast(transform.position, moveDirection, out rayHit, raycastDistance))
        {
            if (rayHit.collider.CompareTag("Road"))
            {
                moveDirection = new Vector3(0f, 0f, 0f);
            }
        }

        if (StatusManager.isJump && canJump)
        {
            canJump = false;
            isJumping = true;
            velocity = new Vector3(0f, 0f, -1 * jumpForce);
        }

        if (isJumping)
        {
            velocity.z += gravity * Time.fixedDeltaTime;
            RaycastHit hit;
            Vector3 rayDirection = new Vector3(0f, 0f, 1f);

            // palyer 开始向下运动的时候才做检查
            if (velocity.z > 0 && Physics.Raycast(transform.position, rayDirection, out hit, raycastDistance))
            {
                if (hit.collider.CompareTag("Road"))
                {
                    isJumping = false;
                    canJump = true;
                }
            }
        }
        else
        {
            velocity = new Vector3(0f, 0f, 0f);
        }

        Vector3 direction = moveDirection * playerSpeed + velocity;
        rb.MovePosition(rb.position + direction * Time.fixedDeltaTime);

        RaycastHit starHit;

        if (Physics.Raycast(transform.position, direction, out starHit, raycastDistance))
        {
            if (starHit.collider.CompareTag("Star"))
            {
                GameControllerMP.instance.AddScore();
                Destroy(starHit.collider.gameObject);
            }
        }
    }
}
