using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro.Examples;

public class TouchResponseManager : Singleton<TouchResponseManager>
{
    public CameraController cameraController;

    private void Start()
    {
        cameraController = Camera.main.GetComponent<CameraController>();
    }

    [SerializeField]
    bool cameraRotRestrict;
    [SerializeField]
    bool inArMode;

    public bool ArMode
    {
        get
        {
            return inArMode;
        }
        set
        {
            inArMode = value;
            UpdateCameraRef();
        }
    }

    void UpdateCameraRef()
    {
        if (ArMode)
        {

        }
        else
        {
            cameraController = Camera.main.GetComponent<CameraController>();

        }
    }

    public bool CameraRotRestrict
    {
        get
        {
            return cameraRotRestrict;
        }
        set
        {
            cameraRotRestrict = value;
            EnableDisableCameraContol();
        }
    }

    void EnableDisableCameraContol()
    {
        if (ArMode)
        {

        }
        else
        {
            if (cameraController != null)
            {

        cameraController.enabled = cameraRotRestrict;
            }

        }
    }


    private void Update()
    {
        if (!inArMode)
        {
            
        }

        if (Input.touchCount != 0)
        {
            var firstTouch = Input.GetTouch(0);
            if (firstTouch.phase == TouchPhase.Began)
            {
                Ray ray = Camera.main.ScreenPointToRay(firstTouch.position);
                RaycastHit hits;
                if (Physics.Raycast(ray, out hits, 800))
                {
            //Debug.Log(hits.transform.gameObject.name);
                    //ClickTriggerRespone triggeredObject = hits.transform.GetComponent<ClickTriggerRespone>();
                    var triggeredObjec = hits.transform.GetComponent<UserTouchResponseAction>();
            //Debug.Log(triggeredObjec);
                    //triggeredObject?.TouchedTriggerRespones();
                    triggeredObjec?.TouchedTriggerRespones();
                    //timeLineManager.CLickDragDropHitGameObject(targetName);
                    //performActionEvent?.Invoke();
                }
            }
        }

    }
}
