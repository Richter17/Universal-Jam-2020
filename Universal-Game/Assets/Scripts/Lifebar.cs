﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Lifebar : MonoBehaviour
{
    public TextMeshProUGUI precentageTxt;
    public Image fillImg;

    [Range(0,1)]
    public float Value;

    public void SetValue(float val)
    {
        fillImg.fillAmount = val;
        int valInt = (int)(val * 100f);
        precentageTxt.text = valInt.ToString() + "%";
    }

    private void Update()
    {
        SetValue(Value);
    }

}