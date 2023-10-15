using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using Common;
/// <summary>
/// �ṩ���������¼�
/// </summary>
public class InputEvent : MonoSingleton<InputEvent>
{
    //*************�������**************************
    InputDevice leftHandController;
    InputDevice rightHandController;
    InputDevice headController;

    //**************�����ṩ�����¼�******************
    #region public event

    public Action onLeftTriggerEnter;
    public Action onLeftTriggerDown;
    public Action onLeftTriggerUp;

    public Action onRightTriggerEnter;
    public Action onRightTriggerDown;
    public Action onRightTriggerUp;

    public Action onLeftGripEnter;
    public Action onLeftGripDown;
    public Action onLeftGripUp;

    public Action onRightGripEnter;
    public Action onRightGripDown;
    public Action onRightGripUp;

    public Action onLeftAppButtonEnter;
    public Action onLeftAppButtonDown;
    public Action onLeftAppButtonUp;

    public Action onRightAppButtonEnter;
    public Action onRightAppButtonDown;
    public Action onRightAppButtonUp;

    public Action onLeftJoyStickEnter;
    public Action onLeftJoyStickDown;
    public Action onLeftJoyStickUp;

    public Action onRightJoyStickEnter;
    public Action onRightJoyStickDown;
    public Action onRightJoyStickUp;

    public Action<Vector2> onLeftJoyStickMove;
    public Action<Vector2> onRightJoyStickMove;

    public Action onLeftAXButtonEnter;
    public Action onLeftAXButtonDown;
    public Action onLeftAXButtonUp;

    public Action onLeftBYButtonEnter;
    public Action onLeftBYButtonDown;
    public Action onLeftBYButonUp;

    public Action onRightAXButtonEnter;
    public Action onRightAXButtonDown;
    public Action onRightAXButtonUp;

    public Action onRightBYButtonEnter;
    public Action onRightBYButtonDown;
    public Action onRightBYButtonUp;

    #endregion

    //�ṩ״̬�ֵ������¼����feature��״̬
    Dictionary<string, bool> stateDic;

    //����ģʽ�ṩ�ĳ�ʼ������
    protected override void Init()
    {
        base.Init();
        leftHandController = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);
        rightHandController = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
        headController = InputDevices.GetDeviceAtXRNode(XRNode.Head);
        stateDic = new Dictionary<string, bool>();

    }
    //*******************�¼�Դ�Ĵ���**************************

    /// <summary>
    /// ��ť�¼�Դ����ģ��
    /// </summary>
    /// <param name="device">�豸</param>
    /// <param name="usage">��������</param>
    /// <param name="btnEnter">��ʼ���°�ť�¼�</param>
    /// <param name="btnDown">���°�ť�¼�</param>
    /// <param name="btnUp">̧��ť�¼�</param>
    private void ButtonDispatchModel(InputDevice device, InputFeatureUsage<bool> usage, Action btnEnter, Action btnDown, Action btnUp)
    {
        //Ϊ�״�ִ�е�feature���bool״̬ -- �����ж�Enter��Up״̬
        string featureKey = device.name + usage.name;
        if (!stateDic.ContainsKey(featureKey))
        {
            stateDic.Add(featureKey, false);
        }

        bool isDown;
        if (device.TryGetFeatureValue(usage, out isDown) && isDown)
        {
            if (!stateDic[featureKey])
            {
                stateDic[featureKey] = true;
                if (btnEnter != null)
                    btnEnter();
            }
            if (btnDown != null)
                btnDown();
        }
        else
        {
            if (stateDic[featureKey])
            {
                if (btnUp != null)
                    btnUp();
                stateDic[featureKey] = false;
            }
        }
    }

    /// <summary>
    /// ҡ���¼�Դ����ģ��
    /// </summary>
    /// <param name="device">�豸</param>
    /// <param name="usage">��������</param>
    /// <param name="joyStickMove">�ƶ�ҡ���¼�</param>
    private void JoyStickDispatchModel(InputDevice device, InputFeatureUsage<Vector2> usage, Action<Vector2> joyStickMove)
    {
        Vector2 axis;
        if (device.TryGetFeatureValue(usage, out axis) && !axis.Equals(Vector2.zero))
        {
            if (joyStickMove != null)
                joyStickMove(axis);
        }
    }

    //******************ÿ֡��ѯ�����¼�***********************
    private void Update()
    {
        ButtonDispatchModel(leftHandController, CommonUsages.triggerButton, onLeftTriggerEnter, onLeftTriggerDown, onLeftTriggerUp);
        ButtonDispatchModel(rightHandController, CommonUsages.triggerButton, onRightTriggerEnter, onRightTriggerDown, onRightTriggerUp);

        ButtonDispatchModel(leftHandController, CommonUsages.gripButton, onLeftGripEnter, onLeftGripDown, onLeftGripUp);
        ButtonDispatchModel(rightHandController, CommonUsages.gripButton, onRightGripEnter, onRightGripDown, onRightGripUp);

        ButtonDispatchModel(leftHandController, CommonUsages.primaryButton, onLeftAXButtonEnter, onLeftAXButtonDown, onLeftAXButtonUp);
        ButtonDispatchModel(rightHandController, CommonUsages.primaryButton, onRightAXButtonEnter, onRightAXButtonDown, onRightAXButtonUp);

        ButtonDispatchModel(leftHandController, CommonUsages.secondaryButton, onLeftBYButtonEnter, onLeftBYButtonDown, onLeftBYButonUp);
        ButtonDispatchModel(rightHandController, CommonUsages.secondaryButton, onRightBYButtonEnter, onRightBYButtonDown, onRightBYButtonUp);

        ButtonDispatchModel(leftHandController, CommonUsages.primary2DAxisClick, onLeftJoyStickEnter, onLeftJoyStickDown, onLeftJoyStickUp);
        ButtonDispatchModel(rightHandController, CommonUsages.primary2DAxisClick, onRightJoyStickEnter, onRightJoyStickDown, onRightJoyStickUp);

        ButtonDispatchModel(leftHandController, CommonUsages.menuButton, onLeftAppButtonEnter, onLeftAppButtonDown, onLeftAppButtonUp);
        ButtonDispatchModel(rightHandController, CommonUsages.menuButton, onRightAppButtonEnter, onRightAppButtonDown, onRightAppButtonUp);

        JoyStickDispatchModel(leftHandController, CommonUsages.primary2DAxis, onLeftJoyStickMove);
        JoyStickDispatchModel(rightHandController, CommonUsages.primary2DAxis, onRightJoyStickMove);
    }
}
