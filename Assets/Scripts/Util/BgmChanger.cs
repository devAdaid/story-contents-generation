using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgmChanger : MonoBehaviour
{
    public string bgmName;

    void Start()
    {
        SoundManager.Instance.PlayBgm(bgmName);
    }
}
