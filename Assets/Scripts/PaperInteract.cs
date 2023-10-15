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

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("!!!!!!!!!!!OnCollisionEnter");
        if (collision.collider.CompareTag("Wall"))
        {
            // ��ȡ��ײ��ķ���
            Vector3 normal = collision.contacts[0].normal;

            // ������ת�Ƕ���ʹ paper �ķ����� wall �ķ���һ��
            Vector3 paperNormal = transform.forward;
            Quaternion rotation = Quaternion.FromToRotation(paperNormal, normal);

            transform.rotation = rotation * transform.rotation;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.CompareTag("Wall"))
        {
            transform.rotation = originalRotation;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("!!!!!!!!!!!OnTriggerEnter");
        if (collision.CompareTag("Wall"))
        {
            // ��ȡ��ײ��ķ���
            Vector3 normal = collision.transform.forward;

            // ������ת�Ƕ���ʹ paper �ķ����� wall �ķ���һ��
            Vector3 paperNormal = transform.forward;
            Quaternion rotation = Quaternion.FromToRotation(paperNormal, normal);

            transform.rotation = rotation * transform.rotation;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.CompareTag("Wall"))
        {
            transform.rotation = originalRotation;
        }
    }

    public void Test()
    {
        Debug.Log("!!!!!test");
    }

    public void Test1()
    {
        Debug.Log("!!!!!test1");
    }

    public void Test2()
    {
        Debug.Log("!!!!!test2");
    }

    public void Test3()
    {
        Debug.Log("!!!!!test3");
    }

    public void Test4()
    {
        Debug.Log("!!!!!test4");
    }

    public void Test5()
    {
        Debug.Log("!!!!!test5");
    }

    public void Test6()
    {
        Debug.Log("!!!!!test6");
    }

    public void Test7()
    {
        Debug.Log("!!!!!test7");
    }

    public void test8()
    {
        Debug.Log("!!!!!test8");
    }

    public void test9()
    {
        Debug.Log("!!!!!test9");
    }
}
