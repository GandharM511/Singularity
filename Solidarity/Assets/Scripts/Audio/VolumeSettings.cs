using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class VolumeSettings : MonoBehaviour
{
    [SerializeField] AudioMixer mixer;
    [SerializeField] Slider masterSlider;
    [SerializeField] TextMeshProUGUI masterVolumeText;  

    public const string MIXER_MASTER = "masterVolume";


    void Awake()
    {
        Debug.Log("awake");
        masterSlider.onValueChanged.AddListener(SetMasterVolume);
        masterSlider.value = PlayerPrefs.GetFloat(AudioManager.MASTER_KEY, -40.0f);
        masterVolumeText.text = Mathf.RoundToInt(Mathf.Abs((masterSlider.value / -80 * 100) - 100)) + "%";
    }

    void Start()
    {
        Debug.Log("start");
        masterSlider.value = PlayerPrefs.GetFloat(AudioManager.MASTER_KEY, -40.0f);
        masterVolumeText.text = Mathf.RoundToInt(Mathf.Abs((masterSlider.value / -80 * 100) - 100)) + "%";
    }

    void OnDisable()
    { 
        Debug.Log("Change Scene");
        PlayerPrefs.Save();
    }

    void SetMasterVolume(float value)
    {
        mixer.SetFloat(MIXER_MASTER, value);
        masterVolumeText.text = Mathf.RoundToInt(Mathf.Abs((value / -80 * 100) - 100)) + "%";
        PlayerPrefs.SetFloat(AudioManager.MASTER_KEY, masterSlider.value);
        Debug.Log(value);
    }
    
}
