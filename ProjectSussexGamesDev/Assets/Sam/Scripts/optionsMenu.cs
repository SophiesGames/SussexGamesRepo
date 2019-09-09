using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class optionsMenu : MonoBehaviour
{
    public AudioMixer musicMixer;
    public AudioMixer soundEffectMixer;

    public void SetMusicVolume (float volume)
    {
        musicMixer.SetFloat("musicVolume", volume);
        Debug.Log(volume);
    }

    public void SetSoundEffectVolume (float volume)
    {
        soundEffectMixer.SetFloat("soundEffectVolume", volume);
        Debug.Log(volume);
    }
}
