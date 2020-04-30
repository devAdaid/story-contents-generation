using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryTellerTest : MonoBehaviour
{
    public Text storyText;
    public ProppStoryTeller storyTeller = null;
    public List<int> cbrCondition = new List<int>();

    public void RandomStory()
    {
        storyTeller = new ProppStoryTeller();
        storyTeller.MakeRandomStory();
        storyText.text = storyTeller.story.Text;
    }

    public void CBRStory()
    {
        storyTeller = new ProppStoryTeller();
        storyTeller.MakeCBRStory(cbrCondition);
        storyText.text = storyTeller.story.Text;
    }
}
