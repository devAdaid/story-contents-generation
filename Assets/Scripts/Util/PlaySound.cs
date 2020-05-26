using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySound : MonoBehaviour
{
    public void Play(string soundName)
    {
        SoundManager.Instance.PlaySfxOneShot(soundName);
    }
}
