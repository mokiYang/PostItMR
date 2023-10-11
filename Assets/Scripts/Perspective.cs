using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.XR.PXR;

public class Perspective : MonoBehaviour
{
    private void Awake()
    {
        PXR_Boundary.EnableSeeThroughManual(true);
    }
}
