﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryTellerTest : MonoBehaviour
{
    public StoryShowUI storyUI;
    public StorySaveUI saveUI;
    public ProppStoryTeller storyTeller = null;
    public List<int> condition = new List<int>();

    public void RandomStory()
    {
        storyTeller = new ProppStoryTeller();
        storyTeller.MakeRandomStory();
        StoryGameSystem.playStory = storyTeller.story;
        storyUI.SetTextWith(storyTeller.story);
        saveUI.SetStory(storyTeller.story);
    }

    public void CBRStory()
    {
        storyTeller = new ProppStoryTeller();
        storyTeller.MakeCBRStory(condition);
        StoryGameSystem.playStory = storyTeller.story;
        storyUI.SetTextWith(storyTeller.story);
        saveUI.SetStory(storyTeller.story);
    }
}
