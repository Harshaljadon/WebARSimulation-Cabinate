using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Events;

public class UIAnimationManager : Singleton<UIAnimationManager>
{
    List<Image> imagesToManage;
    List<TextMeshProUGUI> textsToManage;
    // Add more lists for other types of components as needed.

    private ScaleUpDownActiveDeactive<Image> imageScaleManager;
    private ScaleUpDownActiveDeactive<TextMeshProUGUI> textManager;
    private FadeInOutActiveDeactive<Image> fadeInOutActiveDeactiveImage;
    private FadeInOutActiveDeactive<TextMeshProUGUI> fadeInOutActiveDeactiveText;
    // Add more managers for other types of components as needed.


    public void Initialize(List<Image> imageComponents = null, List<TextMeshProUGUI> textComponents = null)
    {

        // Use the provided component collections if they are not null, otherwise, use the defaults.
        imagesToManage = imageComponents ?? imagesToManage;
        textsToManage = textComponents ?? textsToManage;
    }

    /// <summary>
    /// Create an instance of the Image manager to scale down up.
    /// </summary>
    public void CreateImageScaleUPDownManagerInstance()
    {
        imageScaleManager = new ScaleUpDownActiveDeactive<Image>(imagesToManage);
    }

    public void ImageScaleDown(float duration, UnityEvent unityEvent )
    {
        imageScaleManager.ScaleDown(duration, unityEvent);
    }

    public void ImageScaleUp(float duration, UnityEvent unityEvent )
    {
        imageScaleManager.ScaleUp(duration, unityEvent);

    }

    /// <summary>
    /// Create an instance of the TextMeshProUGUI manager to scale down up.
    /// </summary>
    public void CreateTextScaleUpoDownManagerInstance()
    {
        textManager = new ScaleUpDownActiveDeactive<TextMeshProUGUI>(textsToManage);
    }

    public void TextscaleUp(float duration, UnityEvent unityEvent )
    {
        textManager.ScaleUp(duration, unityEvent);
    }

    public void TextscaleDown(float duration, UnityEvent unityEvent )
    {
        textManager.ScaleDown(duration, unityEvent);
    }

    /// <summary>
    /// Create an instance of the Image manager to fade in out
    /// </summary>
    public void CreateImageFadeInOutManagerInstance()
    {
        fadeInOutActiveDeactiveImage = new FadeInOutActiveDeactive<Image>(imagesToManage);
    }

    public void ImageFadeOut(float duration, UnityEvent unityEvent )
    {
        fadeInOutActiveDeactiveImage.FadeOut(duration, unityEvent);
    }


    public void ImageFadeIn(float duration, UnityEvent unityEvent )
    {
        fadeInOutActiveDeactiveImage.FadeIn(duration, unityEvent);
    }
    /// <summary>
    /// Create an instance of the TextMeshProUGUI manager to fade in out
    /// </summary>
    public void CreateTextFadeInOutManagerInstance()
    {
        fadeInOutActiveDeactiveText = new FadeInOutActiveDeactive<TextMeshProUGUI>(textsToManage);
    }

    public void TextFadeIn(float duration, UnityEvent unityEvent )
    {
        fadeInOutActiveDeactiveText.FadeIn(duration, unityEvent);
    }

    public void TextFadeOut(float duration, UnityEvent unityEvent )
    {
        fadeInOutActiveDeactiveText.FadeOut(duration, unityEvent);
    }
    // Add methods to control component animations and activation as needed.
}
