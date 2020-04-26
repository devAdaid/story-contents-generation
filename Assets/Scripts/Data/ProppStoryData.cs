using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu]
public class ProppStoryData : ScriptableObject, IEquatable<ProppStoryData>, IComparable<ProppStoryData>
{
    public List<ProppMoveData> moves = new List<ProppMoveData>();
    public List<ProppCharacter> characters = new List<ProppCharacter>();

    public int FunctionKey
    {
        get
        {
            _functionKey = CalculateFunctionKey();
            return _functionKey;
        }
    }
    [SerializeField]
    private int _functionKey = 0;
    [HideInInspector]
    public int evaluateDistance = 0;

    public ProppStoryData(ProppStory story)
    {
        foreach(var m in story.moves)
        {
            var move = new ProppMoveData(m);
            moves.Add(move);
        }
    }

    public int CalculateFunctionKey()
    {
        int result = 0;
        foreach(var m in moves)
        {
            foreach(var f in m.proppFunctions)
            {
                result |= (1 << f.functionNumber);
            }
        }
        //Debug.Log($"FunctionKey: {result}");
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