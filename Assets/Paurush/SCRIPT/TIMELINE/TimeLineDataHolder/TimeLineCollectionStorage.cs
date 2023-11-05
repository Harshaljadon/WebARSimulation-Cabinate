using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;

public class TimeLineCollectionStorage : MonoBehaviour
{
    public int currentStepIndex, performJumpNextStep;
    public TimeStore[] timeStores;
    public PlayerDirectorTimeLineManager playerDirectorTimeLineManager;
    public bool togglePausePlay;
    public event Action nextbackEvent;
    [SerializeField]
    TimeLineManager timeLineManager;
    // Start is called before the first frame update
    void Start()
    {
        //playerDirectorTimeLineManager = FindObjectOfType<PlayerDirectorTimeLineManager>();
        //Debug.Log(playerDirectorTimeLineManager);
        currentStepIndex = 0;
        timeLineManager = FindObjectOfType<TimeLineManager>();
    }



    /// <summary>
    /// Jump on step
    /// </summary>
    /// <param name="forwardBacwardIndication">1,-1,0, indicate, next,back, pause or play</param>
    /// <param name="indexStepNumber">next index step number</param>
    public void ControllStepJumpNextBackPauseplayPerform(int forwardBacwardIndication, int indexStepNumber)
    {
        switch (forwardBacwardIndication)
        {
            case 1:
            case -1:
                nextbackEvent?.Invoke();
                playerDirectorTimeLineManager.startAgain = false;
                timeLineManager.currentStepIndexNumb = indexStepNumber;
                timeLineManager.compaareDataPerformTimeControl[indexStepNumber].correctCountName = 0;
                if (performJumpNextStep == indexStepNumber)
                {
                    timeStores[currentStepIndex].timePerformdata.isPerformed = false;

                }
                if (timeStores[currentStepIndex].timePerformdata.isPerformed )
                {
                    performJumpNextStep = indexStepNumber - 1;
                    timeStores[currentStepIndex].timePerformdata.isPerformed = false;
                    var currentTimelineVariable = timeStores[performJumpNextStep].timePerformdata;
                    var timeLineStepvalue = currentTimelineVariable.valueNextJumpPeformPlayTime;

                    JumpStep(indexStepNumber, timeLineStepvalue);

                }
                else
                {
                    timeStores[currentStepIndex].timePerformdata.isPerformed = false;

                    JumpStep(indexStepNumber);

                }
                //togglePausePlay = false;
                break;
            case 0:
                togglePausePlay =! togglePausePlay;
                PlayPauseProcessControl(togglePausePlay);
                break;
            case 3:
                StepPerform();
                break;
        }
    }

    /// <summary>
    /// next back step jump filter process
    /// </summary>
    /// <param name="indexValue"></param>
    void JumpStep(int indexValue)
    {
        var currentTimelineVariable = timeStores[indexValue].timePerformdata;
        currentStepIndex = indexValue;
        //var timeLineStepvalue = !currentTimelineVariable.isPerformed
        //    ? currentTimelineVariable.valuStartPointStep
        //    : currentTimelineVariable.valuePerformBack;
        var timeLineStepvalue = currentTimelineVariable.valuStartPointStep;
        playerDirectorTimeLineManager.ChangeTimeLineValuePosition(timeLineStepvalue);
        togglePausePlay = false;
    }

    /// <summary>
    /// next back step jump filter process
    /// </summary>
    /// <param name="indexValue"></param>
    void JumpStep(int indexValue, float jumpNextPerformedPlayValue)
    {
        //var currentTimelineVariable = timeStores[indexValue - 1].timePerformdata;
        currentStepIndex = indexValue;
        //var timeLineStepvalue = !currentTimelineVariable.isPerformed
        //    ? currentTimelineVariable.valuStartPointStep
        //    : currentTimelineVariable.valuePerformBack;
        //var timeLineStepvalue = currentTimelineVariable.valueNextJumpPeformPlayTime;
        playerDirectorTimeLineManager.ChangeTimeLineValuePosition(jumpNextPerformedPlayValue);
        togglePausePlay = false;
    }

    /// <summary>
    /// Perform timeline animation when user perform some action like click button, drag drop, etc
    /// </summary>
    public void StepPerform()
    {
        togglePausePlay = !togglePausePlay;
        var currentTimelineVariable = timeStores[currentStepIndex].timePerformdata;
        var timeLinePerformValue = currentTimelineVariable.valueActionPerformTime;
        timeStores[currentStepIndex].timePerformdata.isPerformed = true;
        //playerDirectorTimeLineManager.ChangeTimeLineValuePosition(timeLinePerformValue);
        playerDirectorTimeLineManager.ControlPausePlayReverseSpeed(2, currentTimelineVariable.valuePerformBack, timeLinePerformValue, currentTimelineVariable.isPerformed);
    }


    void PlayPauseProcessControl(bool toggle)
    {
        var currentTimelineVariable = timeStores[currentStepIndex].timePerformdata;
        if (toggle)
        {
            // play and replay
            playerDirectorTimeLineManager.ControlPausePlayReverseSpeed(1, currentTimelineVariable.valuePerformBack, currentTimelineVariable.valuePerformTime, currentTimelineVariable.isPerformed);
        }
        else
        {
            // pause
            //Debug.Log("pause");
            playerDirectorTimeLineManager.ControlPausePlayReverseSpeed(0, currentTimelineVariable.valuePerformBack, currentTimelineVariable.valuePerformTime, currentTimelineVariable.isPerformed);

        }
    }

    
}
