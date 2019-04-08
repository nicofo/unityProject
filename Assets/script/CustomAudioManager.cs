using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class CustomAudioManager : MonoBehaviour
{
    AudioSource audioSourceFx;
    AudioSource audioSourceMusic;
    AudioSource audioSourceMusicLowerPass;
    public AudioMixerSnapshot mainSnap;
    public AudioMixerSnapshot lowerPassSnap;
    bool fxTurn;

    void Start()
    {
        fxTurn = true;
        audioSourceFx = GetComponents<AudioSource>()[0];
        audioSourceMusic = GetComponents<AudioSource>()[1];
        audioSourceMusicLowerPass = GetComponents<AudioSource>()[2];
    }

    public void PlayFx(AudioClip clip)
    {
        audioSourceFx.PlayOneShot(clip);
    }

    public void PlayFx(AudioClip clip, float volume)
    {
        audioSourceFx.PlayOneShot(clip, volume);
        
    }

    public void PlaySong(AudioClip clip, float volume)
    {
        audioSourceMusic.clip = clip;
        audioSourceMusic.volume = volume;
        audioSourceMusicLowerPass.clip = clip;
        audioSourceMusicLowerPass.volume = volume;
        audioSourceMusic.Play();
        audioSourceMusicLowerPass.Play();
    }

    public void LowerPass(bool activate)
    {
        if (activate)
        {
            lowerPassSnap.TransitionTo(0.2f);
        } else
        {
            mainSnap.TransitionTo(0.2f);
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
