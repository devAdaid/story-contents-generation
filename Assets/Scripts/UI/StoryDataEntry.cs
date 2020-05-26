using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StoryDataEntry : MonoBehaviour
{
    public Text idText;
    public Text nameText;
    private ProppStoryData _storyData = null;

    public void SetStoryData(ProppStoryData data)
    {
        _storyData = data;
        idText.text = $"왕국 {data.id}년";
        nameText.text = data.name;
    }

    public void Play()
    {
        StoryGameSystem.playStory = new ProppStory(_storyData);
        SceneManager.LoadScene("3_Novel");
    }
}
