using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class ClickTriggerRespone : MonoBehaviour, UserTouchResponseAction
{
    [Tooltip("Each name should be different, eg right1, right2, wron1, wrong2")]
    public string targetName;
    public UnityEvent performActionEvent;
    public bool clicked;
    public string remedialKey;
    ExamineManager examineManager;
    public GameObject onIcon;
    [SerializeField]
    TimeLineManager timeLineManager;
    private void OnEnable()
    {
        clicked = false;
        timeLineManager = FindObjectOfType<TimeLineManager>();

    }

    private void OnMouseDown()
    {
        if (remedialKey != string.Empty)
        {
            examineManager = FindObjectOfType<ExamineManager>();
            examineManager.CallRemedial(remedialKey);
        }
        if (clicked)
        {
            return;
        }
        // Create a ray from the camera to the mouse pointer
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        RaycastHit hits ;

        if (Physics.Raycast(ray, out hits,800))
        {
            timeLineManager.CLickDragDropHitGameObject(targetName);
            performActionEvent?.Invoke();
        }
        clicked = true;
        if (onIcon != null)
        {

        onIcon.SetActive(true);
        }
    }

    public void TouchedTriggerRespones()
    {
        timeLineManager.CLickDragDropHitGameObject(targetName);
        performActionEvent?.Invoke();
        clicked = true;
        if (onIcon != null)
        {

            onIcon.SetActive(true);
        }
    }

}


