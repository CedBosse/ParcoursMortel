using System;
using UnityEngine;
using UnityEngine.Events;

public class DisableOverTimeComponent : MonoBehaviour
{
    float timeBeforeDisable = 2;
    public Action onDisable;
    float elapsedTime;
    
    void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime > timeBeforeDisable)
        {
            var objectToDisable = gameObject;
            onDisable.Invoke();
            objectToDisable.SetActive(false);
            elapsedTime = 0;
        }
    }
}
