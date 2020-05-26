using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryListUI : MonoBehaviour
{
    public StoryDataEntry entryPrefab;
    public Transform contents;
    
    void Start()
    {
        var stories = StoryDatabaseManager.storyDatabase.storyData;
        foreach(var story in stories)
        {
            var entry = Instantiate(entryPrefab, contents);
            entry.SetStoryData(story);
        }
    }
}