using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
[System.Serializable]
public class ProppStoryData : ScriptableObject, IEquatable<ProppStoryData>, IComparable<ProppStoryData>
{
    public ProppActionData interdiction;
    public ProppVillainyData villainy = new ProppVillainyData();
    public List<ProppFunctionData> functions = new List<ProppFunctionData>();
    public ProppCharacterData characters;
    public ProppLocationData locations;
    //public List<ProppCharacter> characters = new List<ProppCharacter>();

    public int FunctionKey
    {
        get
        {
            _functionKey = CalculatePlotKey();
            return _functionKey;
        }
    }
    private int _functionKey = 0;
    [HideInInspector]
    public int evaluateDistance = 0;

    public ProppStoryData() { }

    public ProppStoryData(ProppStoryDataContainer data)
    {
        interdiction = data.interdiction;
        villainy = data.villainy;
        functions = data.functions;
        characters = data.characters;
        locations = data.locations;
    }

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

    public ProppFunctionData FindFunction(int functionNum)
    {
        foreach(var f in functions)
        {
            if(f.functionNumber == functionNum)
            {
                return f;
            }
        }
        return null;
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

public class ProppStoryDataContainer
{
    public ProppActionData interdiction;
    public ProppVillainyData villainy = new ProppVillainyData();
    public List<ProppFunctionData> functions = new List<ProppFunctionData>();
    public ProppCharacterData characters;
    public ProppLocationData locations;

    public ProppStoryDataContainer(ProppStoryData data)
    {
        interdiction = data.interdiction;
        villainy = data.villainy;
        functions = data.functions;
        characters = data.characters;
        locations = data.locations;
    }
}