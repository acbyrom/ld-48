using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public GameObject dataHolder;

    public void SetVolume (float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }

    public void SetSensitivity(float sensitivity)
    {
        dataHolder.GetComponent<PersistentData>().sensitivityMultiplier = sensitivity;
    }
}
