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

    public const string MASTER_KEY = "MasterVolume";

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
        mixer.SetFloat(VolumeSettings.MIXER_MASTER, masterVolume);
    }
}
