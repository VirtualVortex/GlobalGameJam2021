using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Settings : MonoBehaviour
{
    Resolution[] resolutions;

    public Dropdown resolutionDropdown;

    public AudioMixer audioMixer;

    public Slider SFXSLIDER;

    public Slider MusicSlider;

    public AudioMixer audioMixerMusic;



    void Start()
    {
        int CurrentResolutionIndex = 0;
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        for (int i = 0; i < resolutions.Length; i++)
        {
            string Option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(Option);

            if (resolutions[i].width == Screen.width &&
                resolutions[i].height == Screen.height)
            {
                CurrentResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = CurrentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        SFXSLIDER.value = PlayerPrefs.GetFloat("Volume", 1f);

        audioMixer.SetFloat("Volume", Mathf.Log10(SFXSLIDER.value) * 20);

        MusicSlider.value = PlayerPrefs.GetFloat("VolumeMusic", 1f);

        audioMixerMusic.SetFloat("VolumeMusic", Mathf.Log10(SFXSLIDER.value) * 20);
    }

    public void SetVolume(float volume)
    {
        PlayerPrefs.SetFloat("Volume", volume);
        audioMixer.SetFloat("Volume", Mathf.Log10(volume) * 20);
    }

    public void SetVolumeMusic(float volumeMusic)
    {
        PlayerPrefs.SetFloat("VolumeMusic", volumeMusic);
        audioMixerMusic.SetFloat("volumeMusic", Mathf.Log10(volumeMusic) * 20);
    }


    public void SetResolution(int resolutionsIndex)
    {
        Resolution resolution = resolutions[resolutionsIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }

}
