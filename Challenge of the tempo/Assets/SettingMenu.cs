using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingMenu : MonoBehaviour
{
    public AudioMixer audio;
    public void SetVolume(float volume)
    {
        audio.SetFloat("volume", volume);
        //Debug.Log(volume);
    }
}
