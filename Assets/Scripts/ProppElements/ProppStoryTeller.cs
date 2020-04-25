using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProppStoryTeller
{
    public ProppStory story = null;
    public RandomStoryGenerator randomStoryGenerator = new RandomStoryGenerator();
    public CBRStoryGenerator cbrStoryGenerator = new CBRStoryGenerator();
    public ProppFunctionContainer currentFunction = null;
    private bool _isStoryEnd = false;

    public ProppStoryTeller() { }

    public void MakeCBRStory(List<int> condition)
    {
        cbrStoryGenerator.SetCondition(condition);
        story = cbrStoryGenerator.GenerateStory();
        Debug.Log(JsonUtility.ToJson(new ProppStoryData(story)));
    }

    public void MakeRandomStory()
    {
        story = randomStoryGenerator.GenerateStory();
        Debug.Log(JsonUtility.ToJson(new ProppStoryData(story)));
    }

    public void ProgressStory()
    {
        if (story == null) return;
        if (_isStoryEnd) return;

        if(currentFunction == null)
        {
            currentFunction = story.firstFunction;
        }
        else
        {
            currentFunction = currentFunction.nextFunction;
        }
        TellStory();
    }

    public void TellStory()
    {
        if (currentFunction == null)
        {
            Debug.Log("Story End");
            _isStoryEnd = true;
            return;
        }

        Debug.Log($"Move{currentFunction.MoveNumber}_{currentFunction.containFunction.Name}");
    }
}