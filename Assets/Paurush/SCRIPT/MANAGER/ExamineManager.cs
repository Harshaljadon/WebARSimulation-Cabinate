using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.IO;
using System;

public class ExamineManager : MonoBehaviour
{
    public TextAsset jsonFile;
    public DataStore dataStore;
    public TextMeshProUGUI instruction, description,remedial;
    public GameObject remedialPanel;
    public int currentStepIndextextJson;
    private JObject jsonData;
    public TimeLineCollectionStorage timeLineCollectionStorage;

    [SerializeField]
    TimeLineManager timeLineManager;
    //private SimulationData simulationData; // Store parsed JSON data
    private void Awake()
    {
        // Load and parse the JSON data from the TextAsset
        if (jsonFile != null)
        {
            string jsonText = jsonFile.text;
            // Parse JSON into a JObject
            jsonData = JObject.Parse(jsonText);
            //simulationData = JsonUtility.FromJson<SimulationData>(jsonText);
        }
    }

    private void Start()
    {
        timeLineManager = FindObjectOfType<TimeLineManager>();

        timeLineCollectionStorage = FindObjectOfType<TimeLineCollectionStorage>();
        timeLineCollectionStorage.nextbackEvent += TimeLineCollectionStorage_nextbackEvent;

    }

    private void TimeLineCollectionStorage_nextbackEvent()
    {
        remedialPanel.SetActive(false);
    }

    public void CallRemedial(string remedialKey)
    {
        DisPlayTextOnScreen(3, remedialKey);
    }


    public void DisPlayTextOnScreen(int id, string jsonkey = null)
    {
        currentStepIndextextJson = timeLineManager.currentStepIndexNumb;
        switch (id)
        {
            case 1:
                // instruction
                var keyIns = dataStore.textOnScreensSteps[currentStepIndextextJson].instructionJsonKey;
                instruction.text = GetValue<string>(keyIns);
                remedialPanel.SetActive(false);

                break;
            case 2:
                // description
                // Use simulationData.des_1 for description text
                remedialPanel.SetActive(false);
                var keyDes = dataStore.textOnScreensSteps[currentStepIndextextJson].descriptionJsonkey;
                description.text = GetValue<string>(keyDes);
                break;
            case 3:
                // remedial
                remedialPanel.SetActive(true);
                remedial.text = GetValue<string>(jsonkey);

                break;
            case 4:
                // hint
                break;
            case 5:
                // precaution
                break;
            case 6:
                // info
                break;
            default:
                Debug.Log("1- instrcution, 2- description, 3 - remedial, 4 - hint, 5- precaution, 6 - info");
                break;
        }
    }


    private T GetValue<T>(string key)
    {
        if (jsonData.ContainsKey(key))
        {
            JToken value = jsonData[key];

            if (value.Type == JTokenType.String)
            {
                // Check if T is a string type, and if so, return the string value directly.
                if (typeof(T) == typeof(string))
                {
                    return (T)(object)value.ToString();
                }
                else
                {
                    // Attempt to convert the string to the desired type (e.g., int, float).
                    try
                    {
                        return (T)Convert.ChangeType(value.ToString(), typeof(T));
                    }
                    catch (InvalidCastException)
                    {
                        Debug.LogError($"Failed to convert value for key '{key}' to type {typeof(T)}.");
                    }
                }
            }
            else if (value.Type == JTokenType.Integer && typeof(T) == typeof(int))
            {
                return value.ToObject<T>();
            }
            // Add more data type checks and conversions as needed for other value types.
        }

        Debug.LogWarning($"Key '{key}' not found in the JSON data or type mismatch.");
        return default(T); // Return a default value for the requested type.
    }


}

//[System.Serializable]
//public class SimulationData
//{
//    public string inst_1;
//    public string des_1;
//    public string rem_1;
//}