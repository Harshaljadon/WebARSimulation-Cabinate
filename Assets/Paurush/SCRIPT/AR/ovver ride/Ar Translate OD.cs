using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.Interaction.Toolkit.AR;

public class ArTranslateOD : ARTranslationInteractable
{
    GestureTransformationUtility.Placement m_LastPlacement;
    //Vector3 m_DesiredAnchorPosition ;
    //Vector3 m_DesiredLocalPosition ; 
    //Quaternion m_DesiredRotation ;
    //bool m_IsActive ;
    const float k_DiffThreshold = 0.0001f;



    protected override void OnEndManipulation(DragGesture gesture)
    {
        base.OnEndManipulation(gesture);
        var oldAnchor = transform.parent.gameObject;

        // Use Trackables object in scene to use as parent
        var trackablesParent = xrOrigin != null
            ? xrOrigin.TrackablesParent
#pragma warning disable 618 // Calling deprecated property to help with backwards compatibility.
                : (arSessionOrigin != null ? arSessionOrigin.trackablesParent : null);
#pragma warning restore 618
        if (trackablesParent != null)
            oldAnchor.transform.parent = trackablesParent;
        transform.parent = oldAnchor.transform;
        oldAnchor.AddComponent<ARAnchor>();

        //        var GroundingPlaneHeight = transform.parent.position.y;
        //        var desiredPlacement = xrOrigin != null
        //                ? GestureTransformationUtility.GetBestPlacementPosition(
        //                    transform.parent.position, gesture.position, GroundingPlaneHeight, 0.03f,
        //                    maxTranslationDistance, objectGestureTranslationMode, xrOrigin, fallbackLayerMask: fallbackLayerMask)
        //#pragma warning disable 618 // Calling deprecated method to help with backwards compatibility.
        //                : GestureTransformationUtility.GetBestPlacementPosition(
        //                    transform.parent.position, gesture.position, GroundingPlaneHeight, 0.03f,
        //                    maxTranslationDistance, objectGestureTranslationMode, arSessionOrigin, fallbackLayerMask: fallbackLayerMask);
        //#pragma warning restore 618

        //        var DesiredAnchorPosition = desiredPlacement.placementPosition;



        //        if (!m_LastPlacement.hasPlacementPosition)
        //            return;

        //        var desiredPose = new Pose(DesiredAnchorPosition, m_LastPlacement.placementRotation);

        //        var desiredLocalPosition = transform.parent.InverseTransformPoint(desiredPose.position);

        //        if (desiredLocalPosition.magnitude > maxTranslationDistance)
        //            desiredLocalPosition = desiredLocalPosition.normalized * maxTranslationDistance;
        //        desiredPose.position = transform.parent.TransformPoint(desiredLocalPosition);

        //        var anchor = new GameObject("PlacementAnchor").transform;
        //        anchor.position = m_LastPlacement.placementPosition;
        //        anchor.rotation = m_LastPlacement.placementRotation;
        //        anchor.gameObject.AddComponent<ARAnchor>();




        //Destroy(oldAnchor);

        //m_DesiredLocalPosition = Vector3.zero;

        //// Rotate if the plane direction has changed.
        //if (((desiredPose.rotation * Vector3.up) - transform.up).magnitude > k_DiffThreshold)
        //    m_DesiredRotation = desiredPose.rotation;
        //else
        //    m_DesiredRotation = transform.rotation;

        //// Make sure position is updated one last time.
        //m_IsActive = true;
    }

}
