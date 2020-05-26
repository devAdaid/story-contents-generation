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
            string path = Application.persistentDataPath + "/storydb.json";
            if (File.Exists(path))
            {
                string contents = File.ReadAllText(path);
                storyDatabase = JsonUtility.FromJson<StoryDatabase>(contents);
            }
            else
            {
                InitializeWithDefaultData();
            }
            //Debug.Log($"Load Data: {contents}");
        }
        else
        {
            Debug.Log("Already data loaded");
        }
    }

    public static void InitializeWithDefaultData()
    {
        storyDatabase = new StoryDatabase();

        storyDatabase.storyData.Clear();
        var storyData = Resources.LoadAll<TextAsset>("Story");
        foreach (var d in storyData)
        {
            storyDatabase.storyData.Add(JsonUtility.FromJson<ProppStoryData>(d.text));
        }

        storyDatabase.backgroundData.Clear();
        var bgData = Resources.LoadAll<TextAsset>("Background");
        foreach (var d in bgData)
        {
            storyDatabase.backgroundData.Add(JsonUtility.FromJson<ProppBackgroundData>(d.text));
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

    public static void SaveAt(string path)
    {
        string contents = JsonUtility.ToJson(storyDatabase);
        Debug.Log(contents);
        File.WriteAllText(path + "/storydb.json", contents);
    }

    protected static void LoadFunctionData(string path, List<ProppPairFunctionData> target)
    {
        target.Clear();
        var data = Resources.LoadAll<TextAsset>(path);
        foreach (var d in data)
        {
            target.Add(JsonUtility.FromJson<ProppPairFunctionData>(d.text));
        }
    }
}
