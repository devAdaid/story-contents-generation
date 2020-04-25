using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryTellerTest : MonoBehaviour
{
    public ProppStoryTeller storyTeller = null;
    public List<int> cbrCondition = new List<int>();

    public void RandomStory()
    {
        if (storyTeller == null || storyTeller.story.moves.Count < 1)
        {
            storyTeller = new ProppStoryTeller();
            storyTeller.MakeRandomStory();
        }
        storyTeller.ProgressStory();
    }

    public void CBRStory()
    {
        if (storyTeller == null || storyTeller.story.moves.Count < 1)
        {
            storyTeller = new ProppStoryTeller();
            storyTeller.MakeCBRStory(cbrCondition);
        }
        storyTeller.ProgressStory();
    }
}
