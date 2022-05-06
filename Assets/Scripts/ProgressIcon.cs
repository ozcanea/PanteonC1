using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressIcon : MonoBehaviour
{
    private Slider progressIcon;
   

    private void Start()
    {
        progressIcon = GetComponent<Slider>();
        ToggleIcon(false);
    }

    public void ToggleIcon(bool val)
    {
        if (val)
        {
            this.gameObject.SetActive(true);
            SetFillAmount(0);
        }
        else
        {
            this.gameObject.SetActive(false);
        }
    }

    public void SetFillAmount(float value)
    {
        progressIcon.value = Mathf.Clamp01(value);
    }
}
