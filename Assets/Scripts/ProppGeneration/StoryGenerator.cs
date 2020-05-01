using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class StoryGenerator
{
    protected List<ProppStoryData> _storyData = new List<ProppStoryData>();
    protected List<ProppPairFunctionData> _interdictionPairs = new List<ProppPairFunctionData>();
    protected List<ProppPairFunctionData> _villainyPairs = new List<ProppPairFunctionData>();
    protected List<ProppPairFunctionData> _complicationPairs = new List<ProppPairFunctionData>();
    protected List<ProppPairFunctionData> _donorPairs = new List<ProppPairFunctionData>();
    protected List<ProppPairFunctionData> _agentPairs = new List<ProppPairFunctionData>();
    protected List<ProppPairFunctionData> _strugglePairs = new List<ProppPairFunctionData>();
    protected List<ProppPairFunctionData> _pursuePairs = new List<ProppPairFunctionData>();
    protected List<ProppPairFunctionData> _endPairs = new List<ProppPairFunctionData>();
    protected List<ProppBackgroundData> _backgrounds = new List<ProppBackgroundData>();

    public abstract ProppStory GenerateStory(out ProppStoryData storyData);

    protected void LoadStoryData()
    {
        _storyData = StoryDatabaseManager.storyDatabase.storyData;
        /*
        _storyData.Clear();
        var data = Resources.LoadAll<ProppStoryData>("Story");
        foreach (var d in data)
        {
            _storyData.Add(ScriptableObject.Instantiate(d));
        }
        */
    }

    protected void LoadPairData()
    {
        _interdictionPairs = StoryDatabaseManager.storyDatabase.interdictionPairs;
        _villainyPairs = StoryDatabaseManager.storyDatabase.villainyPairs;
        _complicationPairs = StoryDatabaseManager.storyDatabase.complicationPairs;
        _donorPairs = StoryDatabaseManager.storyDatabase.donorPairs;
        _agentPairs = StoryDatabaseManager.storyDatabase.agentPairs;
        _strugglePairs = StoryDatabaseManager.storyDatabase.strugglePairs;
        _pursuePairs = StoryDatabaseManager.storyDatabase.pursuePairs;
        _endPairs = StoryDatabaseManager.storyDatabase.endPairs;
        /*
        LoadFunctionData("Pair/Interdiction", _interdictionPairs);
        LoadFunctionData("Pair/Villainy", _villainyPairs);
        LoadFunctionData("Pair/Complication", _complicationPairs);
        LoadFunctionData("Pair/Donor", _donorPairs);
        LoadFunctionData("Pair/Agent", _agentPairs);
        LoadFunctionData("Pair/Struggle", _strugglePairs);
        LoadFunctionData("Pair/Pursue", _pursuePairs);
        LoadFunctionData("Pair/End", _endPairs);
        */
    }

    protected void LoadBackgroundData()
    {
        _backgrounds = StoryDatabaseManager.storyDatabase.backgroundData;
        /*
        _backgrounds.Clear();
        var data = Resources.LoadAll<ProppBackgroundData>("Background");
        foreach (var d in data)
        {
            _backgrounds.Add(ScriptableObject.Instantiate(d));
        }
        */
    }

    protected void LoadFunctionData(string path, List<ProppPairFunctionData> target)
    {
        /*
        target.Clear();
        var data = Resources.LoadAll<ProppPairFunctionData>(path);
        foreach (var d in data)
        {
            target.Add(ScriptableObject.Instantiate(d));
        }
        */
    }

    protected void ReplaceActionData(ref ProppActionData targetAction, ProppActionData newAction)
    {
        targetAction = newAction;
    }

    protected void ReplaceActionData(ref ProppActionData targetAction, string newActionName, params string[] args)
    {
        targetAction = new ProppActionData(newActionName, args.ToList());
    }

    protected ProppPairFunctionData GetRandomPairFunction(List<ProppPairFunctionData> pairs, int key = -1)
    {
        while (pairs.Count > 0)
        {
            int rand = Random.Range(0, pairs.Count);
            var result = pairs[rand];
            if(key < 0 || EvaluateDistance(result.functionData.Count, result.CalculateFunctionKey(), key) == 0)
            {
                return pairs[rand];
            }
            pairs.RemoveAt(rand);
        }
        return null;
    }

    protected ProppBackgroundData GetRandomBackgroundData(int key = 0)
    {
        if (_backgrounds.Count > 0)
        {
            int rand = Random.Range(0, _backgrounds.Count);
            return _backgrounds[rand];
        }
        return null;
    }

    protected void ReplaceFunction(ProppFunction targetFunction, ProppFunction newFunction)
    {
        targetFunction = newFunction;
    }

    protected void RenameBackground(ProppStoryData storyData)
    {
        var bg = GetRandomBackgroundData();
        storyData.characters = bg.characterData;
        storyData.locations = bg.locationData;
    }

    public int EvaluateDistance(int count, int targetKey, int otherStoryFunctionKey)
    {
        int evaluate = count - NumberOfSetBits(targetKey & otherStoryFunctionKey);
        return evaluate;
    }

    public int NumberOfSetBits(int i)
    {
        i = i - ((i >> 1) & 0x55555555);
        i = (i & 0x33333333) + ((i >> 2) & 0x33333333);
        return (((i + (i >> 4)) & 0x0F0F0F0F) * 0x01010101) >> 24;
    }

    protected void ModifyWithPairFunction(ProppStoryData storyData, ProppPairFunctionData pair)
    {
        foreach (var f in pair.functionData)
        {
            var targetFunc = storyData.FindFunction(f.functionNumber);
            if (targetFunc != null)
            {
                targetFunc.ReplaceWith(f);
            }
        }
    }
}