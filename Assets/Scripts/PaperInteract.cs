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
            // ��ȡ��ײ��ķ���
            // Vector3 normal = collision.transform.forward;

            // ������ת�Ƕ���ʹ paper �ķ����� wall �ķ���һ��
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
