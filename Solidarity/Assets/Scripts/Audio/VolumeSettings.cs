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
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider sfxSlider;
    [SerializeField] TextMeshProUGUI masterVolumeText;
    [SerializeField] TextMeshProUGUI musicVolumeText;
    [SerializeField] TextMeshProUGUI sfxVolumeText;    

    public const string MIXER_MASTER = "MasterVolume";
    public const string MIXER_MUSIC = "MusicVolume";
    public const string MIXER_SFX = "SFXVolume";

    void Awake()
    {
        masterSlider.onValueChanged.AddListener(SetMasterVolume);
        musicSlider.onValueChanged.AddListener(SetMusicVolume);
        sfxSlider.onValueChanged.AddListener(SetSFXVolume);
    }

    void Start()
    {
        masterSlider.value = PlayerPrefs.GetFloat(AudioManager.MASTER_KEY, -40.0f);
        musicSlider.value = PlayerPrefs.GetFloat(AudioManager.MUSIC_KEY, -40.0f);
        sfxSlider.value = PlayerPrefs.GetFloat(AudioManager.SFX_KEY, -40.0f);
    }

    void OnDisable()
    {
        PlayerPrefs.SetFloat(AudioManager.MASTER_KEY, masterSlider.value);
        PlayerPrefs.SetFloat(AudioManager.MUSIC_KEY, musicSlider.value);
        PlayerPrefs.SetFloat(AudioManager.SFX_KEY, sfxSlider.value);
    }

    void SetMasterVolume(float value)
    {
        mixer.SetFloat(MIXER_MASTER, value);
        masterVolumeText.text = Mathf.RoundToInt(Mathf.Abs((value / -80 * 100) - 100)) + "%";
    }

    void SetMusicVolume(float value)
    {
        mixer.SetFloat(MIXER_MUSIC, value);
        musicVolumeText.text = Mathf.RoundToInt(Mathf.Abs((value / -80 * 100) - 100)) + "%";
    }

    void SetSFXVolume(float value)
    {
        mixer.SetFloat(MIXER_SFX, value);
        sfxVolumeText.text = Mathf.RoundToInt(Mathf.Abs((value / -80 * 100) - 100)) + "%";
    }

}
