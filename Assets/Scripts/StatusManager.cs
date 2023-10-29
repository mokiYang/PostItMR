using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusManager : MonoBehaviour
{
    public bool isBuild = true;
    public bool isJump = false;
    public Vector2 axisDirection = new Vector2(0, 0);

    private List<UnityEngine.XR.InputDevice> leftHandedControllers = new List<UnityEngine.XR.InputDevice>();
    private List<UnityEngine.XR.InputDevice> rightHandedControllers = new List<UnityEngine.XR.InputDevice>();
    // private List<UnityEngine.XR.InputDevice> inputDevices = new List<UnityEngine.XR.InputDevice>();
    // Start is called before the first frame update
    void Start()
    {
        var leftDesiredCharacteristics = UnityEngine.XR.InputDeviceCharacteristics.HeldInHand | UnityEngine.XR.InputDeviceCharacteristics.Left | UnityEngine.XR.InputDeviceCharacteristics.Controller;
        var righDesiredCharacteristics = UnityEngine.XR.InputDeviceCharacteristics.HeldInHand | UnityEngine.XR.InputDeviceCharacteristics.Right | UnityEngine.XR.InputDeviceCharacteristics.Controller;
        UnityEngine.XR.InputDevices.GetDevicesWithCharacteristics(leftDesiredCharacteristics, leftHandedControllers);
        UnityEngine.XR.InputDevices.GetDevicesWithCharacteristics(righDesiredCharacteristics, rightHandedControllers);
        // UnityEngine.XR.InputDevices.GetDevices(inputDevices);
    }

    // Update is called once per frame
    void Update()
    {
        foreach (var device in rightHandedControllers)
        {
            bool buildStatus;
            if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primaryButton, out buildStatus) && buildStatus)
            {
                isBuild = true;
            }

            bool runStatus;
            if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.secondaryButton, out runStatus) && runStatus)
            {
                isBuild = false;
            }

            Vector2 direction;
            if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primary2DAxis, out direction) && IsLegalRange(direction))
            {
                axisDirection = direction;
            }
        }

        foreach (var device in leftHandedControllers)
        {
            bool jumpStatus;
            if (device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.primaryButton, out jumpStatus) && jumpStatus)
            {
                isJump = true;
            } else
            {
                isJump = false;
            }
        }
    }

    private bool IsLegalRange(Vector2 vector)
    {
        return vector.x <= 1 && vector.x >= -1 && vector.y <= 1 && vector.y >= -1;
    }
}
