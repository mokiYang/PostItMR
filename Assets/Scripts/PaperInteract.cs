using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PaperInteract : MonoBehaviour
{
    public Transform rightHandControllerTransform; // 右手柄的Transform组件
    public float rayLength = 100.0f; // 射线检测的距离

    private GameObject intersectedPaper; // 相交的Paper物体
    private XRRayInteractor rightInteractor;

    void Start()
    {
        // 订阅事件
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
        // 发射射线
        RaycastHit hit;
        if (rightInteractor.TryGetCurrent3DRaycastHit(out hit))
        {
            // 检查是否与具有Paper标签的物体相交
            if (hit.collider.CompareTag("Paper"))
            {
                Debug.Log("!!!!!Paper");
                intersectedPaper = hit.collider.gameObject;
                // 旋转并吸附到手柄位置
                intersectedPaper.transform.Rotate(-90, 0, 0, Space.Self);
                intersectedPaper.transform.position = rightHandControllerTransform.position;
            }
        }
    }

    private void OnRightGripUp()
    {
        if (intersectedPaper != null)
        {
            // 重置旋转
            intersectedPaper.transform.Rotate(0, 0, 0, Space.Self);
            intersectedPaper = null;
        }
    }

    private void OnDestroy()
    {
        // 从事件中移除方法
        InputEvent.Instance.onRightGripEnter -= OnRightGripEnter;
        InputEvent.Instance.onRightGripUp -= OnRightGripUp;
    }
}
