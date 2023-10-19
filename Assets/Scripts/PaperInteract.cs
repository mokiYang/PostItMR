using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaperInteract : MonoBehaviour
{
    private Quaternion originalRotation;

    private void Start()
    {
        originalRotation = transform.rotation;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Wall"))
        {
            // 获取碰撞点的法线
            // Vector3 normal = collision.transform.forward;

            // 计算旋转角度以使 paper 的法线与 wall 的法线一致
            // Vector3 paperNormal = transform.forward;
            // Quaternion rotation = Quaternion.FromToRotation(paperNormal, normal);
 
            // transform.rotation = rotation * transform.rotation;
            transform.rotation = collision.transform.rotation;
        }
    }

    //private void OnTriggerExit(Collider collision)
    //{
        //Debug.Log("!!!!!!!!!!!OnTriggerExit");
        //if (collision.CompareTag("Wall"))
        //{
            //transform.rotation = originalRotation;
        //}
    //}
}
