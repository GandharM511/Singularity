using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    [SerializeField] AudioMixer mixer;
    [SerializeField] Slider masterSlider;
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider sfxSlider;

    public const string MASTER_KEY = "masterVolume";
    public const string MUSIC_KEY = "musicVolume";
    public const string SFX_KEY = "sfxVolume";

    void Awake()
    {
        if (instance == null)
        {
            instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        LoadVolume();
    }

    void LoadVolume() // Volume saved in VolumeSettings.cs
    {
        float masterVolume = PlayerPrefs.GetFloat(MASTER_KEY, -40.0f);
        float musicVolume = PlayerPrefs.GetFloat(MUSIC_KEY, -40.0f);
        float sfxVolume = PlayerPrefs.GetFloat(SFX_KEY, -40.0f);
        mixer.SetFloat(VolumeSettings.MIXER_MASTER, masterVolume);
        mixer.SetFloat(VolumeSettings.MIXER_MUSIC, musicVolume);
        mixer.SetFloat(VolumeSettings.MIXER_SFX, sfxVolume);
    }
}
