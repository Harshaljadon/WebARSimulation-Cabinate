using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARFoundation.Samples;

public class OffARPlaneAtDisable : MonoBehaviour
{
    public ARPlaneManager aRPlaneManager;
    private void OnDisable()
    {
        aRPlaneManager.SetTrackablesActive(false);
    }
}
