using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StorySaveUI : MonoBehaviour
{
    private ProppStory _story = null;
    public Text storyText;
    public Button saveBtn;
    public int id = 0;
    public string myName = string.Empty;

    public void SetUI()
    {
        storyText.text = _story.Text;
        SetSaveButton();
    }

    public void SetID(string str)
    {
        var success = int.TryParse(str, out id);
        if(!success)
        {
            id = 0;
        }
        SetSaveButton();
    }

    public void SetName(string str)
    {
        myName = str;
        SetSaveButton();
    }

    private void SetSaveButton()
    {
        saveBtn.interactable = (id > 0) && (!string.IsNullOrEmpty(myName));
    }

    public void SetStory(ProppStory story)
    {
        _story = story;
    }

    public void SaveStory()
    {
        StoryDatabaseManager.AddStory(new ProppStoryData(_story, id, myName));
    }
}
