using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource popEffect;
    public AudioSource soundtrack;
    public AudioSource winEffect;
    public AudioSource loseEffect;


    public void PlayWinAudio()
    {
        soundtrack.Stop();
        winEffect.volume = .2f;
        winEffect.PlayOneShot(winEffect.clip);
    }

    public void PlayFailAudio()
    {
        loseEffect.volume = .2f;
        loseEffect.PlayOneShot(loseEffect.clip);
        soundtrack.Stop();

    }

    public void RestartSoundtrack()
    {
        soundtrack.Stop();
        soundtrack.Play();
    }
}
