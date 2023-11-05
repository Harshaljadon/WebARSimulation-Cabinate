using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;

public class FadeInOutActiveDeactive<T> where T : Component
{
    private List<T> components;

    public FadeInOutActiveDeactive(List<T> components)
    {
        this.components = components;
    }

    public void FadeIn(float duration, UnityEvent onComplete)
    {
        foreach (var component in components)
        {
            if (component is Image)
            {
                var image = component as Image;
                image.gameObject.SetActive(true); // Set active before fading in
                image.DOFade(1f, duration).OnComplete(() => onComplete?.Invoke());
            }
            else if (component is TextMeshProUGUI)
            {
                var textMesh = component as TextMeshProUGUI;
                textMesh.gameObject.SetActive(true); // Set active before fading in
                textMesh.DOFade(1f, duration).OnComplete(() => onComplete?.Invoke());
            }
        }
    }

    public void FadeOut(float duration, UnityEvent onComplete)
    {
        foreach (var component in components)
        {
            if (component is Image)
            {
                var image = component as Image;
                image.DOFade(0f, duration).OnComplete(() =>
                {
                    image.gameObject.SetActive(false); // Set inactive after fading out
                    onComplete?.Invoke();
                });
            }
            else if (component is TextMeshProUGUI)
            {
                var textMesh = component as TextMeshProUGUI;
                textMesh.DOFade(0f, duration).OnComplete(() =>
                {
                    textMesh.gameObject.SetActive(false); // Set inactive after fading out
                    onComplete?.Invoke();
                });
            }
        }
    }
}
