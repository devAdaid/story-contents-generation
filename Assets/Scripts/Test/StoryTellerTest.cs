using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryTellerTest : MonoBehaviour
{
    public ProppStoryTeller storyTeller = null;

    public void OnClick()
    {
        if(storyTeller == null)
        {
            storyTeller = new ProppStoryTeller();
            storyTeller.MakeStory();
        }
        storyTeller.ProgressStory();
    }
}
