using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public AudioSource music;
    public AudioSource sfxFood;
    public AudioSource sfxDeath;
    public AudioClip[] sfxArray;
    // public List<AudioSource> sfxSound = new List<AudioSource>();
    // Start is called before the first frame update
    void Start()
    {
        music.volume = PlayerPrefs.GetFloat("MusicVolume");
        sfxFood.volume = PlayerPrefs.GetFloat("SfxVolume");  
        sfxDeath.volume = PlayerPrefs.GetFloat("SfxVolume");  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    // public AudioSource music;
    // public AudioSource sfx;
    // public Slider musicSlider;
    // public Slider sfxSlider;

    // void Start(){
        // if(PlayerPrefs.HasKey("musicVolume")){
        //     loadVolume();
        // }
        // else{
        //     setMusicVolume();
        // }
    // }
    // void Update(){
    //     music.volume = musicSlider.value;
    // }
    // public void setMusicVolume(){
    //     float volume = musicSlider.value;
    //     PlayerPrefs.SetFloat("musicVolume",volume);
    // }

    // void loadVolume(){
    //     musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
    //     music.volume = musicSlider.value;
    //     setMusicVolume();
    // }
}
