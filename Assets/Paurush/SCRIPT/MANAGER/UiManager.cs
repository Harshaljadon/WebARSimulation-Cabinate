using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class UiManager : MonoBehaviour
{
    [SerializeField] int totalStepNumber;
    [SerializeField] int currentStepupdate;
    [SerializeField] TextMeshProUGUI steptextUi;
    [SerializeField] TextMeshProUGUI playPausetextUi;

    TimeLineCollectionStorage timeLineCollectionStorage;

    [SerializeField] Button nextStepButton, backStepButton, pauseStepBackButton, arButton, simulationButton;

    bool togglePlayPausetext;
    /// <summary>
    /// Update text Ui of step, 
    /// </summary>
    /// <param name="currentStepNumber">when next or back buttone pressed event call to update current step text</param>
    void TextUiStepUpdate(int currentStepNumber)
    {
        steptextUi.text = currentStepNumber.ToString() + " / " + totalStepNumber.ToString();
    }

    private void Start()
    {
        timeLineCollectionStorage = FindObjectOfType<TimeLineCollectionStorage>();
        Init_Ui();

    }

    void Init_Ui()
    {
        playPausetextUi.text = ">";
        currentStepupdate = 1;
        totalStepNumber = timeLineCollectionStorage.timeStores.Length;
        steptextUi.text = currentStepupdate + " / " + totalStepNumber.ToString();
        nextStepButton.onClick.AddListener(()=>{ NextStepjump(); });
        backStepButton.onClick.AddListener(()=>{ BackStepJump(); });
        pauseStepBackButton.onClick.AddListener(()=>{ ResumeStepPlay(); });
        arButton?.onClick.AddListener(()=>{ JumpToArScene(); });
        simulationButton?.onClick.AddListener(()=>{ JumptoSimulation(); });

    }

    void JumpToArScene()
    {
        ManageScene.Instance.ArScene();
    }

    void JumptoSimulation()
    {

        ManageScene.Instance.SimulationScene();
    }
    void NextStepjump()
    {
        CurrentStepUpdatenumber(1);
    }

    void BackStepJump()
    {

        CurrentStepUpdatenumber(-1);
    }

    void ResumeStepPlay()
    {
        ChangePlayPauseText();
        CurrentStepUpdatenumber(0);
    }

    public void ActivityPerform()
    {
        CurrentStepUpdatenumber(3);

    }

    void ChangePlayPauseText()
    {
        togglePlayPausetext = !togglePlayPausetext;
        if (togglePlayPausetext)
        {
            playPausetextUi.text = "ll";
        }
        else
        {
            playPausetextUi.text = ">";
        }
    }

    public void PlayTextUi()
    {

        togglePlayPausetext = false;
        playPausetextUi.text = ">";
    }

    void CurrentStepUpdatenumber(int value)
    {
        switch (value)
        {
            case 1:
                if (currentStepupdate < totalStepNumber)
                {
                    currentStepupdate += value;
                    TextUiStepUpdate(currentStepupdate);
                    timeLineCollectionStorage.ControllStepJumpNextBackPauseplayPerform(value,currentStepupdate - 1);
                    PlayTextUi();
                    Debug.Log("next call");
                }
                break;
            case -1:

                if (currentStepupdate > 1)
                {
                    currentStepupdate += value;
                    TextUiStepUpdate(currentStepupdate);
                    timeLineCollectionStorage.ControllStepJumpNextBackPauseplayPerform(value,currentStepupdate - 1);
                    PlayTextUi();
                    
                    //Debug.Log("back call");


                }
                break;
            case 0:
                // pause
                    timeLineCollectionStorage.ControllStepJumpNextBackPauseplayPerform(value,currentStepupdate - 1);
                break;
            case 3:
                //currentStepupdate += value;
                //TextUiStepUpdate(currentStepupdate);
                timeLineCollectionStorage.ControllStepJumpNextBackPauseplayPerform(value,currentStepupdate - 1);
                    //PlayTextUi();
                break;
        }
    }
}
