using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using UnityEngine.XR.Interaction.Toolkit.AR;
using Unity.XR.CoreUtils;
//using Unity.VisualScripting;
using UnityEngine.XR.ARFoundation.Samples;

public class PlacementArObjetWithAnchor : ARPlacementInteractable
{
    [SerializeField]
    bool prefebPlaced;

    public bool m_PrefebPlaced
    {
        get
        {
            return prefebPlaced;
        }
        set
        {
            prefebPlaced = value;
        }
    }

    protected override GameObject PlaceObject(Pose pose)
    {
        if (prefebPlaced)
        {
            return null;
        }

        prefebPlaced = true;

        var placementObject = Instantiate(placementPrefab, pose.position, pose.rotation); 

        // Create anchor to track reference point and set it as the parent of placementObject.
        var anchor = new GameObject("PlacementAnchor").transform;
        anchor.position = pose.position;
        anchor.rotation = pose.rotation;
        anchor.gameObject.AddComponent<ARAnchor>();
        placementObject.transform.parent = anchor;

        // Use Trackables object in scene to use as parent
        var trackablesParent = xrOrigin != null
            ? xrOrigin.TrackablesParent
#pragma warning disable 618 // Calling deprecated property to help with backwards compatibility.
                : (arSessionOrigin != null ? arSessionOrigin.trackablesParent : null);
#pragma warning restore 618
        if (trackablesParent != null)
            anchor.parent = trackablesParent;

        return placementObject;
    }
}
