using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BGMControl : MonoBehaviour
{
    public AudioSource music;
    public AudioSource sfxFood;
    public AudioSource sfxDeath;
    public AudioClip[] sfxArray;
    public Slider musicVolume;
    public Slider sfxVolume;

    void Start()
    {
        musicVolume.value = PlayerPrefs.GetFloat("MusicVolume");
        sfxVolume.value = PlayerPrefs.GetFloat("SfxVolume");

        Debug.Log(PlayerPrefs.GetFloat("SfxVolume"));
    }

    void Update()
    {
        music.volume = musicVolume.value;
        sfxFood.volume = sfxVolume.value;
        sfxDeath.volume = sfxVolume.value;
    }

    public void MusicPrefs()
    {
        music.volume = musicVolume.value;
        PlayerPrefs.SetFloat("MusicVolume",music.volume);
    }

    public void SfxPrefs(){
        sfxFood.volume = sfxVolume.value;
        sfxDeath.volume = sfxVolume.value;
        PlayerPrefs.SetFloat("SfxVolume",sfxFood.volume);
    }
    
}
