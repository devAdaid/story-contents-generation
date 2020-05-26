using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConditionUI : MonoBehaviour
{
    public StoryTellerTest cbr;
    public ConditionEntry entryPrefab;
    public Transform parent;
    public List<string> functions;

    void Start()
    {
        var entries = parent.GetComponentsInChildren<ConditionEntry>();

        for(int i = 0; i < entries.Length; i++)
        {
            var entry = entries[i];
            entry.Set(i + 1, functions[i]);
        }

        foreach(var i in cbr.condition)
        {
            entries[i - 1].toggle.isOn = true;
        }
    }
}
