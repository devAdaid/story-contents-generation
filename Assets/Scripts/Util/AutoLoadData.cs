using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoLoadData : MonoBehaviour
{
    void Awake()
    {
        StoryDatabaseManager.LoadData();
    }
}