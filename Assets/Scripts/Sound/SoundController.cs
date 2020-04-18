using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    private static SoundController soundController;
    public float Volume
    {
        get
        {
            return volume;
        }
        set
        {
            volume = value;
            fixedPitchSource.volume = value;
        }
    }
    [SerializeField]
    [Range(0, 1)]
    private float volume;
    private AudioSource fixedPitchSource;

    private void Start()
    {
        fixedPitchSource = gameObject.AddComponent<AudioSource>();
        soundController = this;
        Volume = volume;
    }

    public static void PlaySound(AudioClip audioClip, bool stop = false)
    {
        if (audioClip == null)
        {
            return;
        }
        if (stop)
        {
            soundController.fixedPitchSource.Stop();
        }
        soundController.fixedPitchSource.PlayOneShot(audioClip);
    }
}
