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

    public const string MIXER_MASTER = "MasterVolume";

    void Awake()
    {
        masterSlider.onValueChanged.AddListener(SetMasterVolume);
    }

    void Start()
    {
        masterSlider.value = PlayerPrefs.GetFloat(AudioManager.MASTER_KEY, -40.0f);
    }

    void OnDisable()
    { 
        PlayerPrefs.Save();
    }

    void Update()
    {
        Debug.Log("VolumeSettings On Update");
        Debug.Log(PlayerPrefs.GetFloat(AudioManager.MASTER_KEY, 69));        
    }

    void SetMasterVolume(float value)
    {
        mixer.SetFloat(MIXER_MASTER, value);
        masterVolumeText.text = Mathf.RoundToInt(Mathf.Abs((value / -80 * 100) - 100)) + "%";
        PlayerPrefs.SetFloat(AudioManager.MASTER_KEY, masterSlider.value);
    }
}
