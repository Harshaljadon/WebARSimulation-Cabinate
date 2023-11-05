using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class FadeInoutScaleUpDownProcessEventOnComplete : MonoBehaviour
{
    bool toggleImageFadeInOutCollection, toggleScaleUpDownImageCollection, toggleTextFadeInOutCollection,toggletextScaleUpDownCollection;
    /// <summary>
    /// Hold collection of text and images for fade in out
    /// </summary>
    public ImageTextCollectionHolder[] TextCollectionHolderData;

    /// <summary>
    /// toggle fade in out individual collection of image
    /// </summary>
    /// <param name="indexCollectionId"></param>
    public void ToggleFadeInOutImages(int indexCollectionId)
    {
        toggleImageFadeInOutCollection = !toggleImageFadeInOutCollection;
        if (toggleImageFadeInOutCollection)
        {
            ImageFadeOutIndiviualCollection(indexCollectionId);
        }
        else
        {
            ImageFadeInIndiviualCollection(indexCollectionId);
        }
    }

    /// <summary>
    /// toggle fade in out individual collection of Text
    /// </summary>
    /// <param name="indexCollectionId"></param>
    public void ToggleFadeInOutText(int indexCollectionId)
    {
        toggleTextFadeInOutCollection = !toggleTextFadeInOutCollection;
        if (toggleTextFadeInOutCollection)
        {
            TextFadeOutIndiviualCollection(indexCollectionId);
        }
        else
        {
            TextFadeInIndiviualCollection(indexCollectionId);
        }
    }

    /// <summary>
    /// toggle Scale up down  individual collection of image
    /// </summary>
    /// <param name="indexCollectionId"></param>
    public void ToggleScaleUpDownImages(int indexCollectionId)
    {
        toggleScaleUpDownImageCollection = !toggleScaleUpDownImageCollection;
        if (toggleScaleUpDownImageCollection)
        {
            ImageScalDownIndiviualCollection(indexCollectionId);
        }
        else
        {
            ImageScalUPIndiviualCollection(indexCollectionId);
        }
    }

    /// <summary>
    /// toggle Scale up down  individual collection of Text
    /// </summary>
    /// <param name="indexCollectionId"></param>
    public void ToggleScaleUpDownText(int indexCollectionId)
    {
        toggletextScaleUpDownCollection = !toggletextScaleUpDownCollection;
        if (toggleScaleUpDownImageCollection)
        {
            TextScaleDownIndiviualCollection(indexCollectionId);
        }
        else
        {
            TextScaleUpIndiviualCollection(indexCollectionId);
        }
    }

    /// <summary>
    /// Button pass id, which fade out only those element index images
    /// </summary>
    /// <param name="collectionElementId">id is for element index number</param>
    void ImageFadeOutIndiviualCollection(int collectionElementId)
    {
        if (TextCollectionHolderData[collectionElementId] == null)
        {
            return;
        }
        UIAnimationManager.Instance.Initialize(TextCollectionHolderData[collectionElementId].imageTextCollection.imagesCollection);
        UIAnimationManager.Instance.CreateImageFadeInOutManagerInstance();
        UIAnimationManager.Instance.ImageFadeOut(TextCollectionHolderData[collectionElementId].imageTextCollection.durationProcessOut, TextCollectionHolderData[collectionElementId].imageTextCollection.callsOnCompleteOut);
        
    }

    /// <summary>
    /// Button pass id, which fade out only those element index text
    /// </summary>
    /// <param name="collectionElementId">id is for element index number</param>
    void TextFadeOutIndiviualCollection(int collectionElementId)
    {
        if (TextCollectionHolderData[collectionElementId] == null)
        {
            return;
        }
        UIAnimationManager.Instance.Initialize( textComponents: TextCollectionHolderData[collectionElementId].imageTextCollection.textCollection);
        UIAnimationManager.Instance.CreateTextFadeInOutManagerInstance();
        UIAnimationManager.Instance.TextFadeOut(TextCollectionHolderData[collectionElementId].imageTextCollection.durationProcessOut, TextCollectionHolderData[collectionElementId].imageTextCollection.callsOnCompleteOut);
    }

    /// <summary>
    /// Button pass id, which fade in only those element index images
    /// </summary>
    /// <param name="collectionElementId">id is for element index number</param>
    void ImageFadeInIndiviualCollection(int collectionElementId)
    {
        if (TextCollectionHolderData[collectionElementId] == null)
        {
            return;
        }
        UIAnimationManager.Instance.Initialize(TextCollectionHolderData[collectionElementId].imageTextCollection.imagesCollection);
        UIAnimationManager.Instance.CreateImageFadeInOutManagerInstance();
        UIAnimationManager.Instance.ImageFadeIn(TextCollectionHolderData[collectionElementId].imageTextCollection.durationProcessIn, TextCollectionHolderData[collectionElementId].imageTextCollection.callsOnCompleteIn);
    }

    /// <summary>
    /// Button pass id, which fade IN only those element index text
    /// </summary>
    /// <param name="collectionElementId">id is for element index number</param>
    void TextFadeInIndiviualCollection(int collectionElementId)
    {
        if (TextCollectionHolderData[collectionElementId] == null)
        {
            return;
        }
        UIAnimationManager.Instance.Initialize(textComponents: TextCollectionHolderData[collectionElementId].imageTextCollection.textCollection);
        UIAnimationManager.Instance.CreateTextFadeInOutManagerInstance();
        UIAnimationManager.Instance.TextFadeIn(TextCollectionHolderData[collectionElementId].imageTextCollection.durationProcessIn, TextCollectionHolderData[collectionElementId].imageTextCollection.callsOnCompleteIn);
    }

    /// <summary>
    /// Button pass id, which scale up in only those element index images
    /// </summary>
    /// <param name="collectionElementId">id is for element index number</param>
    void ImageScalUPIndiviualCollection(int collectionElementId)
    {
        if (TextCollectionHolderData[collectionElementId] == null)
        {
            return;
        }
        UIAnimationManager.Instance.Initialize(TextCollectionHolderData[collectionElementId].imageTextCollection.imagesCollection);
        UIAnimationManager.Instance.CreateImageScaleUPDownManagerInstance();
        UIAnimationManager.Instance.ImageScaleUp(TextCollectionHolderData[collectionElementId].imageTextCollection.durationProcessIn, TextCollectionHolderData[collectionElementId].imageTextCollection.callsOnCompleteIn);
    }

    /// <summary>
    /// Button pass id, which scale up only those element index text
    /// </summary>
    /// <param name="collectionElementId">id is for element index number</param>
    void TextScaleUpIndiviualCollection(int collectionElementId)
    {
        if (TextCollectionHolderData[collectionElementId] == null)
        {
            return;
        }
        UIAnimationManager.Instance.Initialize(textComponents: TextCollectionHolderData[collectionElementId].imageTextCollection.textCollection);
        UIAnimationManager.Instance.CreateTextScaleUpoDownManagerInstance();
        UIAnimationManager.Instance.TextscaleUp(TextCollectionHolderData[collectionElementId].imageTextCollection.durationProcessIn, TextCollectionHolderData[collectionElementId].imageTextCollection.callsOnCompleteIn);
    }

    /// <summary>
    /// Button pass id, which scale down in only those element index images
    /// </summary>
    /// <param name="collectionElementId">id is for element index number</param>
    void ImageScalDownIndiviualCollection(int collectionElementId)
    {
        if (TextCollectionHolderData[collectionElementId] == null)
        {
            return;
        }
        UIAnimationManager.Instance.Initialize(TextCollectionHolderData[collectionElementId].imageTextCollection.imagesCollection);
        UIAnimationManager.Instance.CreateImageScaleUPDownManagerInstance();
        UIAnimationManager.Instance.ImageScaleDown(TextCollectionHolderData[collectionElementId].imageTextCollection.durationProcessOut, TextCollectionHolderData[collectionElementId].imageTextCollection.callsOnCompleteOut);
    }

    /// <summary>
    /// Button pass id, which scale Down only those element index text
    /// </summary>
    /// <param name="collectionElementId">id is for element index number</param>
    void TextScaleDownIndiviualCollection(int collectionElementId)
    {
        if (TextCollectionHolderData[collectionElementId] == null)
        {
            return;
        }
        UIAnimationManager.Instance.Initialize(textComponents: TextCollectionHolderData[collectionElementId].imageTextCollection.textCollection);
        UIAnimationManager.Instance.CreateTextScaleUpoDownManagerInstance();
        UIAnimationManager.Instance.TextscaleDown(TextCollectionHolderData[collectionElementId].imageTextCollection.durationProcessOut, TextCollectionHolderData[collectionElementId].imageTextCollection.callsOnCompleteOut);
    }

}
