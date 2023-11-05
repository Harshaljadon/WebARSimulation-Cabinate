using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

[System.Serializable]
public class ImageTextCollectionHolder 
{
    public ImageTextCollection imageTextCollection;

}

[System.Serializable]
public struct ImageTextCollection
{
    public List<Image> imagesCollection;
    public List<TextMeshProUGUI> textCollection;
    public float durationProcessIn;
    public float durationProcessOut;
    public UnityEvent callsOnCompleteIn;
    public UnityEvent callsOnCompleteOut;
}
