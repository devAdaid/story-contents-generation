using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryShowUI : MonoBehaviour
{
    public Text storyText;
    public Button playButton;
    public Button saveButton;

    void Start()
    {
        SetTextWith(StoryGameSystem.playStory);
    }

    public void SetTextWith(ProppStory story)
    {
        if(story != null)
        {
            storyText.text = story.Text;
            playButton.interactable = true;
            saveButton.interactable = true;
        }
        else
        {
            storyText.text = "새로운 이야기를 생성해주세요.";
            playButton.interactable = false;
            saveButton.interactable = false;
        }
    }
}
