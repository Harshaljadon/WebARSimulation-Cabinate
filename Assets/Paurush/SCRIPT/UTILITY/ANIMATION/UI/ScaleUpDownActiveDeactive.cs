using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;

public class ScaleUpDownActiveDeactive<T> where T : Component
{
    private List<T> components;

    public ScaleUpDownActiveDeactive(List<T> components)
    {
        this.components = components;
    }

    public void ScaleUp(float duration, UnityEvent onComplete)
    {
        foreach (var component in components)
        {
            component.transform.localScale = Vector3.zero; // Set scale to zero before scaling up
            component.gameObject.SetActive(true); // Set active before scaling up
            component.transform.DOScale(Vector3.one, duration).OnComplete(() => onComplete?.Invoke());
        }
    }

    public void ScaleDown(float duration, UnityEvent onComplete)
    {
        foreach (var component in components)
        {
            component.transform.DOScale(Vector3.zero, duration).OnComplete(() =>
            {
                component.gameObject.SetActive(false); // Set inactive after scaling down
                onComplete?.Invoke();
            });
        }
    }
}
