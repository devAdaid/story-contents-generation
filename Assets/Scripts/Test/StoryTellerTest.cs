using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryTellerTest : MonoBehaviour
{
    public ProppStoryTeller storyTeller = null;
    public List<int> cbrCondition = new List<int>();

    public void RandomStory()
    {
        if (storyTeller == null || storyTeller.story.functions.Count < 1)
        {
            storyTeller = new ProppStoryTeller();
            storyTeller.MakeRandomStory();
        }
        storyTeller.TellStory();
        storyTeller.ProgressStory();
    }

    public void CBRStory()
    {
        if (storyTeller == null || storyTeller.story.functions.Count < 1)
        {
            storyTeller = new ProppStoryTeller();
            storyTeller.MakeCBRStory(cbrCondition);
        }
        while (!storyTeller.IsStoryEnd)
        {
            storyTeller.TellStory();
            storyTeller.ProgressStory();
        }
    }
}
