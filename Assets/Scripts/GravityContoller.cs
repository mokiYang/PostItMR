using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityContoller : MonoBehaviour
{
    public float gravityScale = 1.0f;

    private Rigidbody rb;

    void FixedUpdate()
    {
        // ����������Ӱ����ٶȷ���
        Vector3 gravity = Physics.gravity * gravityScale;
        rb.AddForce(gravity, ForceMode.Acceleration);

        // ����������Ӱ����ٶȷ���
        Vector3 horizontalVelocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        Vector3 dragForce = -horizontalVelocity * rb.drag;
        rb.AddForce(dragForce, ForceMode.Acceleration);
    }
}
