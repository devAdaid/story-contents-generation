using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : PersistentSingleton<SoundManager>
{
    private Dictionary<string, AudioClip> _soundClips = new Dictionary<string, AudioClip>();

    public bool IsBgmMute
    {
        get
        {
            _isBgmMute = PlayerPrefs.GetInt("BgmMute", 0) > 0;
            return _isBgmMute;
        }
        set
        {
            _isBgmMute = value;
            PlayerPrefs.SetInt("BgmMute", _isBgmMute ? 1 : 0);
        }
    }
    public bool IsSfxMute
    {
        get
        {
            _isSfxMute = PlayerPrefs.GetInt("SfxMute", 0) > 0;
            return _isSfxMute;
        }
        set
        {
            _isSfxMute = value;
            PlayerPrefs.SetInt("SfxMute", _isSfxMute ? 1 : 0);
        }
    }
    public AudioSource bgmSource;
    public AudioSource sfxSource;

    private bool _isBgmMute = false;
    private bool _isSfxMute = false;

    protected override void Awake()
    {
        base.Awake();

        if (sfxSource == null)
        {
            sfxSource = gameObject.GetComponent<AudioSource>();
        }

        AudioClip[] clips = Resources.LoadAll<AudioClip>("Sounds");
        foreach (AudioClip c in clips)
        {
            _soundClips.Add(c.name, c);
        }

        sfxSource.mute = IsSfxMute;
        bgmSource.mute = IsBgmMute;
    }

    public void StopBgm()
    {
        bgmSource.Stop();
    }

    public void PlayBgm(string clipName)
    {
        bgmSource.clip = _soundClips[clipName];
        bgmSource.Play();
    }

    public void StopSfx()
    {
        sfxSource.Stop();
    }

    public void PlaySfx(string clipName)
    {
        if (_soundClips.ContainsKey(clipName))
        {
            sfxSource.clip = _soundClips[clipName];
            sfxSource.Play();
        }
        else
        {
            //Debug.Log("[MissisngSfx] No SoundFile: '" + clipName+"'");
        }
    }

    public void PlaySfxOneShot(string clipName)
    {
        if (_soundClips.ContainsKey(clipName))
        {
            sfxSource.PlayOneShot(_soundClips[clipName]);
        }
        else
        {
            //Debug.Log("[MissisngSfx] No SoundFile: '" + clipName + "'");
        }
    }

    public void PlaySfx(AudioClip clip)
    {
        sfxSource.clip = clip;
        sfxSource.Play();
    }
}