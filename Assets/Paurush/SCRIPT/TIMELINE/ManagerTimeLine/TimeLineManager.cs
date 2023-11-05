using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimeLineManager : MonoBehaviour
{
    public int currentStepIndexNumb;
    //public CurrentTimeIndexData currentTimeIndexData;
    public CompaareDataPerformTimeControl[] compaareDataPerformTimeControl;
    public TimeLineCollectionStorage _TimeLineCollectionStorage;
    // Start is called before the first frame update

    private void Start()
    {
        _TimeLineCollectionStorage = FindObjectOfType<TimeLineCollectionStorage>();
    }

    public void CLickDragDropHitGameObject(string targetHitName)
    {
        foreach (var item in compaareDataPerformTimeControl[currentStepIndexNumb].compareName)
        {
            if (item == targetHitName)
            {
                int count = compaareDataPerformTimeControl[currentStepIndexNumb].compareName.Count;
                if (compaareDataPerformTimeControl[currentStepIndexNumb].correctCountName != count)
                {
                    compaareDataPerformTimeControl[currentStepIndexNumb].correctCountName++;

                }
                if (compaareDataPerformTimeControl[currentStepIndexNumb].correctCountName == compaareDataPerformTimeControl[currentStepIndexNumb].compareName.Count)
                {
                    //Debug.Log(targetHitName);
                    _TimeLineCollectionStorage = FindObjectOfType<TimeLineCollectionStorage>();

                    _TimeLineCollectionStorage.StepPerform();
                    // perform action
                }

            }
        }

    }

}

[System.Serializable]
public struct CurrentTimeIndexData
{

    public float valuStartPointStep;
    public float valuePerformTime;
    public bool isPerformed;
    public float valueActionPerformTime;
    public float valuePerformBack;
    public bool isReplayStart;

}

[System.Serializable]
public struct CompaareDataPerformTimeControl
{
    public List<string> compareName;
    public int correctCountName;
    
}
