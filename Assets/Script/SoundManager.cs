using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : Singleton<SoundManager>
{
    Dictionary<string, AudioClip> audioClips = new Dictionary<string, AudioClip>();
    AudioSource audioSrc;

    // Start is called before the first frame update
    void Start()
    {
        audioClips.Add("AmmoPickupSFX", Resources.Load<AudioClip>("AmmoPickupSFX"));
        audioClips.Add("WallDestroySFX", Resources.Load<AudioClip>("WallDestroySFX"));
        audioClips.Add("HealthPickupSFX", Resources.Load<AudioClip>("HealthPickupSFX"));
        audioClips.Add("ButtonSFX", Resources.Load<AudioClip>("ButtonSFX"));
        audioClips.Add("HitSFX", Resources.Load<AudioClip>("HitSFX"));

        audioSrc = GetComponent<AudioSource>();
    }

    public void PlaySFX(string clipName, float volumeScale = 1.0f)
    {
        if(audioClips.ContainsKey(clipName))
        {
            audioSrc.PlayOneShot(audioClips[clipName], volumeScale);
        }
        else
        {
            Debug.LogError("SoundManager: Doesn't have " + clipName);
        }
    }
}
