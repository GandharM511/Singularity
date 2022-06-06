using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public const string MASTER_KEY = "MasterVolume";

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            Debug.Log("Dont Destroy on Load");
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Debug.Log("Destroy on load");
            Destroy(gameObject);
        }

    }

}
