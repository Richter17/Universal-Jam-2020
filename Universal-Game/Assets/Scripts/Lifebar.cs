using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

//[ExecuteInEditMode]
public class Lifebar : MonoBehaviour
{
    public TextMeshProUGUI precentageTxt;
    public Image fillImg;
    public Gradient color;

    //[Range(0,1)]
    //public float value;

    public void SetValue(float val)
    {
        fillImg.fillAmount = val;
        int valInt = (int)(val * 100f);
        precentageTxt.text = valInt.ToString() + "%";
        fillImg.color = color.Evaluate(val);
    }

    //private void Update()
    //{
    //    SetValue(value);
    //}
}
