using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DragDropNonUi : MonoBehaviour
{
    [SerializeField]
    Transform orignalParent;

    [SerializeField]
    Transform stepParent;

    [SerializeField]
    Transform objectToDrage;

    Vector3 initialTransform, myInitialPos, offset;
    public Vector3 newPosition;
    Quaternion iniRot;

    [SerializeField]
    string targetName;
    //private Vector3 offset;
    private bool isDragging = false;
    public UnityEvent performWhenCorrect, performWhenInCorrect;


    public float offsetForwardDirection, camDist;

    [SerializeField]
    TouchResponseManager touchResponseManager;

    [SerializeField]
    TimeLineManager timeLineManager;

    private void OnEnable()
    {
        touchResponseManager = FindObjectOfType<TouchResponseManager>();
        myInitialPos = this.transform.position;
        timeLineManager = FindObjectOfType<TimeLineManager>();

    }

    private void OnMouseDown()
    {

        camDist = Vector3.Distance(transform.position, Camera.main.transform.position);
        offsetForwardDirection = (camDist - 2) * -1;


        touchResponseManager.CameraRotRestrict = false;

        objectToDrage.GetComponent<ScaleWithCameraDistance>().enabled = true;
        initialTransform = objectToDrage.localPosition;
        iniRot = objectToDrage.localRotation;
        objectToDrage.SetParent(stepParent);
        objectToDrage.transform.localPosition = Vector3.zero;
        objectToDrage.transform.localRotation = Quaternion.Euler(0, 0, 0);
        //objectToDrage.transform.localScale = Vector3.one;

        // Calculate the offset between the click point and the object's position
        //offset = transform.position - GetMouseWorldPosition();
        this.transform.GetComponent<Collider>().enabled = false;

        // Set dragging flag to true
        isDragging = true;

        //newPosition = transform.position + Camera.main.transform.forward * offsetForwardDirection;
        newPosition = transform.position +((transform.position - Camera.main.transform.position).normalized * offsetForwardDirection);

        transform.position = newPosition;

        offset = transform.position - MouseWorldPosition() ;
        objectToDrage.GetComponent<ScaleWithCameraDistance>().DraggingSizeUpdate_OnMouseDown();


    }



    private void OnMouseDrag()
    {
        //objectToDrage.GetComponent<ScaleWithCameraDistance>().DraggingSizeUpdate();

        transform.position = MouseWorldPosition() + offset ;
    }
    Vector3 MouseWorldPosition()
    {
        var mouseScreenPos = Input.mousePosition;

        mouseScreenPos.z = Camera.main.WorldToScreenPoint(transform.position).z;

        return Camera.main.ScreenToWorldPoint(mouseScreenPos);


    }

    private void OnMouseUp()
    {
        this.transform.GetComponent<Collider>().enabled = true;
        touchResponseManager.CameraRotRestrict = true;



        // Create a ray from the camera to the mouse pointer
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // RaycastHit variable to store information about the hit
        RaycastHit[] hits = Physics.RaycastAll(ray);

        foreach (RaycastHit hit in hits)
        {
            HitTargetDrageDrop hitTargetDrageDrop = hit.transform.GetComponent<HitTargetDrageDrop>();

                //Debug.Log(hit.transform.gameObject.name);
            // Check if the hit object has the desired targetName
            if (hitTargetDrageDrop != null && hitTargetDrageDrop.hitTargetName == targetName)
            {
                // This is a correct target
                // Handle the correct action here

                timeLineManager.CLickDragDropHitGameObject(targetName);

                performWhenCorrect?.Invoke();
            }
            else
            {
                performWhenInCorrect?.Invoke();
            }
        }



        this.transform.position = myInitialPos;
        objectToDrage.SetParent(orignalParent);
        objectToDrage.localPosition = initialTransform;
        objectToDrage.localRotation = iniRot;
        //objectToDrage.transform.localScale = Vector3.one;
        // Set dragging flag to false when the mouse button is released
        isDragging = false;
        objectToDrage.GetComponent<ScaleWithCameraDistance>().DraggingSizeUpdate_OnMouseUp();

    }


    // Update is called once per frame


    private void OnTouchBegin(Vector2 touchPosition)
    {
       
    }

    private void OnTouchEnd()
    {
       
    }


    private void OnTouchMove(Vector2 touchPosition)
    {

    }




    private void Update()
    {
        if (Input.touchCount != 0)
        {
            var userTouch = Input.GetTouch(0);
            if (userTouch.phase ==  TouchPhase.Began)
            {

            }
            if (userTouch.phase == TouchPhase.Moved)
            {

            }
            if (userTouch.phase == TouchPhase.Ended)
            {

            }
        }
    }

}
