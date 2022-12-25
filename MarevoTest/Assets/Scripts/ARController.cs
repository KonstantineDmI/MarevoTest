using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARController : MonoBehaviour
{
    [SerializeField] private XROrigin xrOrigin;
    [SerializeField] private ARPlaneManager planeManager;
    [SerializeField] private ARRaycastManager raycastManager;

    public void DisableAR(bool state)
    {
        xrOrigin.enabled = !state;
        planeManager.enabled = !state;
        raycastManager.enabled = !state;
    }
}
