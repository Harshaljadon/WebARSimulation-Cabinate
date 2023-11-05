using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableDisableComponent : MonoBehaviour
{
    [Tooltip("To toggle the enable disable the perticular component, that component should at top below transform component")]
    public List<MonoBehaviour> toggleEnableFirst;
    [Tooltip("To toggle the enable disable the perticular component, that component should at top below transform component")]
    public List<MonoBehaviour> toggleDisableFirst;

    bool toggleEnableDisable;

    [ContextMenu("Do Something")]
    public void EnableDiableCom()
    {
        toggleEnableDisable = !toggleEnableDisable;
        foreach (var enableItem in toggleEnableFirst)
        {
            enableItem.enabled = toggleEnableDisable;
            //Debug.Log(toggleEnableDisable);
        }
        foreach (var disabelItem in toggleDisableFirst)
        {
            disabelItem.enabled = !toggleEnableDisable;
            //Debug.Log(toggleEnableDisable);

        }
    }
}
