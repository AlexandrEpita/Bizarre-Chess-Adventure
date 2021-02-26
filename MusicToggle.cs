using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MusicToggle : MonoBehaviour
{
    public Text ToggleText;
    public AudioSource Audio;
    public void start()
    {
        Audio = GetComponent<AudioSource>();
        
        if (Audio.isPlaying)
            {
                ToggleText.text = "OFF";
            }
        else
            {
                ToggleText.text = "ON";
            }
        
    }
    public void MusicToggles()
    {
        if (Audio.isPlaying)
        {
            Audio.Pause();
            ToggleText.text = "OFF";
        }
        else
        {
            Audio.Play();
            ToggleText.text = "ON";
        }
    }
    void Update()
    {
        
    }

    
    
}
