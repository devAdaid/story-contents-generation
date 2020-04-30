using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryDatabase
{
    public List<ProppStoryData> storyData = new List<ProppStoryData>();
    public List<ProppBackgroundData> backgroundData = new List<ProppBackgroundData>();
    public List<ProppPairFunctionData> interdictionPairs = new List<ProppPairFunctionData>();
    public List<ProppPairFunctionData> villainyPairs = new List<ProppPairFunctionData>();
    public List<ProppPairFunctionData> complicationPairs = new List<ProppPairFunctionData>();
    public List<ProppPairFunctionData> donorPairs = new List<ProppPairFunctionData>();
    public List<ProppPairFunctionData> agentPairs = new List<ProppPairFunctionData>();
    public List<ProppPairFunctionData> strugglePairs = new List<ProppPairFunctionData>();
    public List<ProppPairFunctionData> pursuePairs = new List<ProppPairFunctionData>();
    public List<ProppPairFunctionData> endPairs = new List<ProppPairFunctionData>();

    private Dictionary<string, List<ProppPairFunctionData>> _funcDict = new Dictionary<string, List<ProppPairFunctionData>>();

    public StoryDatabase()
    {
        _funcDict.Add("interdict", interdictionPairs);
        _funcDict.Add("villainy", villainyPairs);
        _funcDict.Add("complication", complicationPairs);
        _funcDict.Add("donor", donorPairs);
        _funcDict.Add("agent", agentPairs);
        _funcDict.Add("struggle", strugglePairs);
        _funcDict.Add("pursue", pursuePairs);
    }

    public void AddFunc(string key, ProppPairFunctionData functionData)
    {
        _funcDict[key].Add(functionData);
    }
}