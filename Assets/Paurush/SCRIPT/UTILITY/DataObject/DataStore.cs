using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DataStore 
{
    public TextOnScreen[] textOnScreensSteps;
}

[System.Serializable]
public struct TextOnScreen
{
    
    public string instructionJsonKey;
    public string descriptionJsonkey;


}

//public string remedialJsonKey;
//public string hintJsonKey;
//public string infoJsonKey;
//public string precautionJsonKey;