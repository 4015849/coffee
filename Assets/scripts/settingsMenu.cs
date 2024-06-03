using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.InputSystem;

public class settingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public InputActionReference MoveRef, FireRef;
    public void SetMasterVolume(float masterVolume)
    {
        audioMixer.SetFloat("masterVolume", masterVolume);
    }

    public void SetMusicVolume(float musicVolume)
    {
        audioMixer.SetFloat("musicVolume", musicVolume);
    }

    public void SetSfxVolume(float sfxVolume)
    {
        audioMixer.SetFloat("sfxVolume", sfxVolume);
    }

    private void OnEnable()
    {
        MoveRef.action.Disable();
        FireRef.action.Disable();
    }

    private void OnDisable()
    {
        MoveRef.action.Enable();
        FireRef.action.Enable();
    }
}
