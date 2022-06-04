using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SliderTextToValue : MonoBehaviour
{
    private TextMeshProUGUI textSliderValue;
    public Slider sliderUI;

    void Start() 
    {
        var texts = FindObjectsOfType<TextMeshProUGUI>();
        this.textSliderValue = texts[1];
        Debug.Log(textSliderValue);
    }

    public void ShowSliderValue(float value)
    {
        string message = Mathf.RoundToInt(Mathf.Abs((sliderUI.value / -80 * 100) - 100)) + "%";
        this.textSliderValue.text = message;
    }
}
