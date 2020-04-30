using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProppStoryTeller
{
    public ProppStory story = null;
    public RandomStoryGenerator randomStoryGenerator = new RandomStoryGenerator();
    public CBRStoryGenerator cbrStoryGenerator = new CBRStoryGenerator();
    public int currentStoryIndex = 0;
    public bool IsStoryEnd = false;

    public ProppStoryTeller() { }

    public void MakeCBRStory(List<int> condition)
    {
        currentStoryIndex = 0;
        cbrStoryGenerator.SetCondition(condition);
        story = cbrStoryGenerator.GenerateStory();
        //Debug.Log(JsonUtility.ToJson(new ProppStoryData(story)));
    }

    public void MakeRandomStory()
    {
        currentStoryIndex = 0;
        story = randomStoryGenerator.GenerateStory();
        Debug.Log(JsonUtility.ToJson(new ProppStoryData(story)));
    }

    public void ProgressStory()
    {
        if (story == null) return;
        if (IsStoryEnd) return;

        currentStoryIndex += 1;
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
        foreach(var a in currentFuntion.actions)
        {
            if(a != null)
                Debug.Log(a.Description());
            //Debug.Log(a.ToString());
        }
    }
}