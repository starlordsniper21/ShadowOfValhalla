using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class volumesettings : MonoBehaviour
{

    [SerializeField] private AudioMixer mymixer;
    [SerializeField] private Slider musicslider;

    private void Start()
    {
        if (PlayerPrefs.HasKey("musicVolume"))
        {
            LoadVolume();
        }

        else { 
            SetMusicVolume(); 
        }
       
    }

    public void SetMusicVolume()
    {
        float volume = musicslider.value;
        mymixer.SetFloat("Music", Mathf.Log10(volume)*20);
        PlayerPrefs.SetFloat("musicVolume", volume);
    }

    private void LoadVolume()
    {
        musicslider.value = PlayerPrefs.GetFloat("musicVolume");

        SetMusicVolume();
    }
   
}
