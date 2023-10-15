using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PaperInteract : MonoBehaviour
{
    public Transform rightHandControllerTransform; // ���ֱ���Transform���
    public float rayLength = 100.0f; // ���߼��ľ���

    private GameObject intersectedPaper; // �ཻ��Paper����
    private XRRayInteractor rightInteractor;

    void Start()
    {
        // �����¼�
        InputEvent.Instance.onRightGripEnter += OnRightGripEnter;
        InputEvent.Instance.onRightGripUp += OnRightGripUp;
    }

    public void test()
    {
        Debug.Log("!!!!!test");
    }

    public void test1()
    {
        Debug.Log("!!!!!test1");
    }

    public void test2()
    {
        Debug.Log("!!!!!test2");
    }

    public void test3()
    {
        Debug.Log("!!!!!test3");
    }

    public void test4()
    {
        Debug.Log("!!!!!test4");
    }

    public void test5()
    {
        Debug.Log("!!!!!test5");
    }

    public void test6()
    {
        Debug.Log("!!!!!test6");
    }

    public void test7()
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

    private void OnRightGripEnter()
    {
        Debug.Log("!!!!!OnRightGripEnter");
        // ��������
        RaycastHit hit;
        if (rightInteractor.TryGetCurrent3DRaycastHit(out hit))
        {
            // ����Ƿ������Paper��ǩ�������ཻ
            if (hit.collider.CompareTag("Paper"))
            {
                Debug.Log("!!!!!Paper");
                intersectedPaper = hit.collider.gameObject;
                // ��ת���������ֱ�λ��
                intersectedPaper.transform.Rotate(-90, 0, 0, Space.Self);
                intersectedPaper.transform.position = rightHandControllerTransform.position;
            }
        }
    }

    private void OnRightGripUp()
    {
        if (intersectedPaper != null)
        {
            // ������ת
            intersectedPaper.transform.Rotate(0, 0, 0, Space.Self);
            intersectedPaper = null;
        }
    }

    private void OnDestroy()
    {
        // ���¼����Ƴ�����
        InputEvent.Instance.onRightGripEnter -= OnRightGripEnter;
        InputEvent.Instance.onRightGripUp -= OnRightGripUp;
    }
}
