using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsController : MonoBehaviour
{
    const string MUSIC_VOLUME_KEY = "music volume";
    const string SOUND_VOLUME_KEY = "sound";

    const float MIN_MUSIC_VOLUME = 0f;
    const float MAX_MUSIC_VOLUME = 1f;
    float currentMusicVolume;

    const float MIN_SOUND_VOLUME = 0f;
    const float MAX_SOUND_VOLUME = 1f;
    float currentSoundVolume;

    public static void SetMusicVolume(float volume)
    {
        if(volume >= MIN_MUSIC_VOLUME && volume <= MAX_MUSIC_VOLUME)
        {
            Debug.Log("Music volume is" + volume);
            PlayerPrefs.SetFloat(MUSIC_VOLUME_KEY, volume);
        }
        else
        {
            Debug.LogError("Music volume out of bounds");
        }
    }

    public static float GetMusicVolume()
    {
        return PlayerPrefs.GetFloat(MUSIC_VOLUME_KEY);
    }

    public static void SetSoundVolume(float volume)
    {
        if(volume >= MIN_SOUND_VOLUME && volume <= MAX_SOUND_VOLUME)
        {
            Debug.Log("Sound volume is" + volume);
            PlayerPrefs.SetFloat(SOUND_VOLUME_KEY, volume);
        }
        else
        {
            Debug.LogError("Sound volume out of bounds");
        }
    }

    public static float GetSoundVolume()
    {
        return PlayerPrefs.GetFloat(SOUND_VOLUME_KEY);
    }
}
