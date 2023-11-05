using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableDisableCollider : MonoBehaviour
{
    //[SerializeField]
    //bool toggleEnableDisableCollider;

    [SerializeField]
    Collider[] enableCollider;

    [SerializeField]
    Collider[] disableCollider;

    [SerializeField]
    Collider[] toggleCollider;

    public void EnableCollider()
    {
        foreach (var enableColiderItem in enableCollider)
        {
            enableColiderItem.enabled = true;
        }
    }

    public void DisableCollider()
    {
        foreach (var disableColiderItem in disableCollider)
        {
            disableColiderItem.enabled = false;
        }
    }

    public void ToggleEnableDisableCollider()
    {
        //toggleEnableDisableCollider = !toggleEnableDisableCollider;

        foreach (var item in toggleCollider)
        {
            //Debug.Log(item.enabled);
            item.enabled = !item.enabled;
            //Debug.Log(item.enabled);
        }

    }
}
