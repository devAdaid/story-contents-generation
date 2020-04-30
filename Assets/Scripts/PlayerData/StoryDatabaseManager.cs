using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class StoryDatabaseManager : MonoBehaviour
{
    public static StoryDatabase storyDatabase = null;

    public static void LoadData()
    {
        if(storyDatabase == null)
        {
            string contents = File.ReadAllText(Application.persistentDataPath + "/storydb.json");
            Debug.Log($"Load Data: {contents}");
            storyDatabase = JsonUtility.FromJson<StoryDatabase>(contents);
        }
    }

    public static void Initialize()
    {
        storyDatabase = new StoryDatabase();

        storyDatabase.storyData.Clear();
        var data = Resources.LoadAll<ProppStoryData>("Story");
        foreach (var d in data)
        {
            storyDatabase.storyData.Add(ScriptableObject.Instantiate(d));
        }

        storyDatabase.backgroundData.Clear();
        var data2 = Resources.LoadAll<ProppBackgroundData>("Background");
        foreach (var d in data2)
        {
            storyDatabase.backgroundData.Add(ScriptableObject.Instantiate(d));
        }

        LoadFunctionData("Pair/Interdiction", storyDatabase.interdictionPairs);
        LoadFunctionData("Pair/Villainy", storyDatabase.villainyPairs);
        LoadFunctionData("Pair/Complication", storyDatabase.complicationPairs);
        LoadFunctionData("Pair/Donor", storyDatabase.donorPairs);
        LoadFunctionData("Pair/Agent", storyDatabase.agentPairs);
        LoadFunctionData("Pair/Struggle", storyDatabase.strugglePairs);
        LoadFunctionData("Pair/Pursue", storyDatabase.pursuePairs);
        LoadFunctionData("Pair/End", storyDatabase.endPairs);
        SaveData();
    }

    public static void AddStory(ProppStoryData story)
    {
        storyDatabase.storyData.Add(story);
        SaveData();
    }

    public static void AddBg(ProppBackgroundData bg)
    {
        storyDatabase.backgroundData.Add(bg);
        SaveData();
    }

    public static void AddFunc(string key, ProppPairFunctionData functionData)
    {
        storyDatabase.AddFunc(key, functionData);
        SaveData();
    }

    public static void SaveData()
    {
        string contents = JsonUtility.ToJson(storyDatabase);
        Debug.Log(contents);
        File.WriteAllText(Application.persistentDataPath + "/storydb.json", contents);
    }

    protected static void LoadFunctionData(string path, List<ProppPairFunctionData> target)
    {
        target.Clear();
        var data = Resources.LoadAll<ProppPairFunctionData>(path);
        foreach (var d in data)
        {
            target.Add(ScriptableObject.Instantiate(d));
        }
    }
}
