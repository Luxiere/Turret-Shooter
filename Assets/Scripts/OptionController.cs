using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionController : MonoBehaviour
{
    [SerializeField] Slider musicSlider;
    [SerializeField] Slider soundSlider;

    float savedMusicVolume;
    float savedSoundVolume;

    private void Start()
    {
        musicSlider.value = PlayerPrefsController.GetMusicVolume();
        soundSlider.value = PlayerPrefsController.GetSoundVolume();
    }

    public void CacheVolume()
    {
        savedMusicVolume = PlayerPrefsController.GetMusicVolume();
        savedSoundVolume = PlayerPrefsController.GetSoundVolume();
    }

    public void Save()
    {
        PlayerPrefsController.SetMusicVolume(musicSlider.value);
        PlayerPrefsController.SetSoundVolume(soundSlider.value);
    }

    public void Cancel()
    {
        PlayerPrefsController.SetMusicVolume(savedMusicVolume);
        PlayerPrefsController.SetSoundVolume(savedSoundVolume);
    }
}
