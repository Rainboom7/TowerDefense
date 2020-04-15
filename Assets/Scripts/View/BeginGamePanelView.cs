using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeginGamePanelView : MonoBehaviour
  
{
    [HideInInspector]
    public event Action ShowHudEvent;

    private void OnEnable()
    {
        gameObject.SetActive(true);
    }

    public void BeginGame() {
        ShowHudEvent?.Invoke();
        gameObject.SetActive(false);
      
    }
}
