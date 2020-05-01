using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryGameSystem : MonoBehaviour
{
    public ProppStoryTeller storyTeller = null;
    public StoryTellingSystem storyTellingSystem;

    private void Start()
    {
        RandomStory();
        Debug.Log(storyTeller.story.FindLocationName("Home"));
        storyTellingSystem.SetBackground(storyTeller.story.FindLocationName("Home"));
        TellStory();
        ProgressStory();
    }

    public void RandomStory()
    {
        storyTeller = new ProppStoryTeller();
        storyTeller.MakeRandomStory();
    }

    public void CBRStory()
    {
        storyTeller = new ProppStoryTeller();
        storyTeller.MakeCBRStory();
    }

    public void TellStory()
    {
        storyTeller.TellStory(storyTellingSystem);
    }

    public void ProgressStory()
    {
        storyTeller.ProgressStory();
    }
}
