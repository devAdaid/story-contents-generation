using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu]
public class ProppStoryData : ScriptableObject, IEquatable<ProppStoryData>, IComparable<ProppStoryData>
{
    public ProppActionData interdiction;
    public ProppVillainyData villainy;
    public List<ProppFunctionData> functions = new List<ProppFunctionData>();
    public ProppCharacterData characters;
    //public List<ProppCharacter> characters = new List<ProppCharacter>();

    public int FunctionKey
    {
        get
        {
            _functionKey = CalculatePlotKey();
            return _functionKey;
        }
    }
    [SerializeField]
    private int _functionKey = 0;
    [HideInInspector]
    public int evaluateDistance = 0;

    public ProppStoryData(ProppStory story)
    {
        interdiction = new ProppActionData(story.interdiction);
        villainy = new ProppVillainyData(story.villainy);
        foreach(var f in story.functions)
        {
            functions.Add(new ProppFunctionData(f));
        }
        characters = story.characters;
    }

    public int CalculatePlotKey()
    {
        int result = 0;
        foreach (var f in functions)
        {
            result |= (1 << f.functionNumber);
        }
        return result;
    }

    public bool Equals(ProppStoryData other)
    {
        if (other == null) return false;
        return (this.evaluateDistance.Equals(other.evaluateDistance));
    }

    public int CompareTo(ProppStoryData comparePart)
    {
        if (comparePart == null)
            return 1;

        else
            return this.evaluateDistance.CompareTo(comparePart.evaluateDistance);
    }
}