using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryGameSystem : MonoBehaviour
{
    public static ProppStory playStory = null;
    public ProppStoryTeller storyTeller = null;
    public StoryTellingSystem storyTellingSystem;

    private void Start()
    {
        storyTeller = new ProppStoryTeller();
        if (playStory == null)
        {
            RandomStory();
        }
        else
        {
            storyTeller.SetStory(playStory);
        }

        //Debug.Log(storyTeller.story.FindLocationName("Home"));
        storyTellingSystem.SetBackground(storyTeller.story.FindLocationName("Home"));
        TellStory();
        ProgressStory();
    }

    public void RandomStory()
    {
        storyTeller.MakeRandomStory();
    }

    public void CBRStory()
    {
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
