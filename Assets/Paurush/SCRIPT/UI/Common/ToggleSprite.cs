using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ToggleSprite : MonoBehaviour
{
    public GameObject firstSprite,secondSprite;
    bool spritetoggleBool;
    Button swapSprite;


    private void Start()
    {
        var swapSprite = this.transform.GetComponent<Button>();
        if (swapSprite == null)
        {
            return;
        }
        secondSprite.gameObject.SetActive(false);
        swapSprite.onClick.AddListener(() => { SwapSptiteToggle(); });
    }

    void SwapSptiteToggle()
    {
        spritetoggleBool = !spritetoggleBool;
        if (spritetoggleBool)
        {
            secondSprite.gameObject.SetActive(true);
            firstSprite.gameObject.SetActive(false);

        }
        else
        {
            secondSprite.gameObject.SetActive(false);
            firstSprite.gameObject.SetActive(true);
        }
    }
}
