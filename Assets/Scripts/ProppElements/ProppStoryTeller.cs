using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProppStoryTeller
{
    public ProppStory story = null;
    public ProppStoryData storyData = null;
    public RandomStoryGenerator randomStoryGenerator = new RandomStoryGenerator();
    public CBRStoryGenerator cbrStoryGenerator = new CBRStoryGenerator();
    public int currentStoryIndex = 0;
    public int currentActionIndex = 0;
    public bool IsStoryEnd = false;

    public ProppStoryTeller() { }

    public void MakeCBRStory()
    {
        currentStoryIndex = 0;
        currentActionIndex = 0;
        story = cbrStoryGenerator.GenerateStory(out storyData);
        //Debug.Log(JsonUtility.ToJson(new ProppStoryData(story)));
    }

    public void MakeCBRStory(List<int> condition)
    {
        currentStoryIndex = 0;
        currentActionIndex = 0;
        cbrStoryGenerator.SetCondition(condition);
        story = cbrStoryGenerator.GenerateStory(out storyData);
        //Debug.Log(JsonUtility.ToJson(new ProppStoryData(story)));
    }

    public void MakeRandomStory()
    {
        currentStoryIndex = 0;
        currentActionIndex = 0;
        story = randomStoryGenerator.GenerateStory(out storyData);
        //Debug.Log(JsonUtility.ToJson(new ProppStoryData(story)));
    }

    public void SetStory(ProppStory madeStory)
    {
        currentStoryIndex = 0;
        currentActionIndex = 0;
        story = madeStory;
    }

    public void ProgressStory()
    {
        if (story == null) return;
        if (IsStoryEnd) return;

        currentActionIndex += 1;
        ProppFunction currentFuntion = story.functions[currentStoryIndex];
        if (currentActionIndex >= currentFuntion.actions.Count)
        {
            currentActionIndex = 0;
            currentStoryIndex += 1;
        }

        if(currentStoryIndex >= story.functions.Count)
        {
            IsStoryEnd = true;
        }
    }

    public void TellStory()
    {
        if (story == null) return;
        if (IsStoryEnd) return;

        if (currentStoryIndex >= story.functions.Count)
        {
            return;
        }

        ProppFunction currentFuntion = story.functions[currentStoryIndex];
        //Debug.Log($"Function {currentFuntion.Number}");
        foreach (var a in currentFuntion.actions)
        {
            if(a != null)
                Debug.Log($"{a.Description()}");
            //Debug.Log(a.ToString());
        }
    }

    public void TellStory(StoryTellingSystem stSystem)
    {
        if (story == null) return;
        if (IsStoryEnd)
        {
            SceneManager.LoadScene("2_Main");
        }

        if (currentStoryIndex >= story.functions.Count)
        {
            return;
        }
        ProppFunction currentFuntion = story.functions[currentStoryIndex];

        if (currentActionIndex >= currentFuntion.actions.Count)
        {
            return;
        }
        ProppAction currentAction = currentFuntion.actions[currentActionIndex];

        if(currentAction != null)
        {
            stSystem.DefaultSetting();
            currentAction.ShowAction(stSystem);
            currentAction.TellAction(stSystem);
        }
    }
}