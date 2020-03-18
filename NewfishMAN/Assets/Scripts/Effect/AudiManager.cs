using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudiManager : MonoBehaviour
{

    private static AudiManager _instance;
    public static AudiManager Instance
    {
        get
        {
            return _instance;
        }
    }

    private bool isMute = false;//音スイッチoff

    public AudioSource bgmAudioSource; //bgmやアラームなど
    public AudioClip seaWave;

    public AudioClip goldClip;
    public AudioClip rewardClip;
    public AudioClip fireClip;
    public AudioClip changeClip;
    public AudioClip lvUpClip;



    void Awake()
    {
        _instance = this;
    }

    public void SwitchMuteState()//音スイッチ
    {
        isMute = !isMute;
        if (isMute)
        {
            bgmAudioSource.Pause();

        }
        else
        {
            bgmAudioSource.Play();
        }
        
    }
    public void PlayEffectSound(AudioClip clip)
    {
        if (!isMute)
        AudioSource.PlayClipAtPoint(clip, Vector3.zero);
    }


}