using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingMenu : MonoBehaviour
{
    public AudioMixer audio;
    Resolution[] resolutions;
    public Dropdown resolutionDropDown;

    private void Start()
    {
        //list of all resolutions
        resolutions = Screen.resolutions;

        resolutionDropDown.ClearOptions(); //removes the text dropdown provided to empty the dropdown

        List<string> options = new List<string>(); //our opions is going to be in this list which is a list of all the resolutions


        int currentResIndex = 0;
        for(int i = 0; i< resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height; //loop through the array of resolutions and add it to the options 
            options.Add(option); //after looping complete we have list of string resolutions in the list

            if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResIndex = i;
            }
        }

        //after looping we add the options list to the addOption method for dropdown
        resolutionDropDown.AddOptions(options);
        resolutionDropDown.value = currentResIndex;
        resolutionDropDown.RefreshShownValue();
    }

    public void SetResolution(int resIndex)
    {
        Resolution resolution = resolutions[resIndex]; //fetches the resolution from the resolution array above
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

    //setVolume adjusts the audioMixer volume called volume
    public void SetVolume(float volume)
    {
        audio.SetFloat("volume", volume);
        //Debug.Log(volume);
    }

    //changes quality based on its index such as low, medium and high
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
        // Debug.Log(QualitySettings.GetQualityLevel());
    }
    public void SetFullScreen(bool isFullScreen)
    {

        Screen.fullScreen = isFullScreen;
    }

}
