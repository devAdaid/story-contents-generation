using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProppStoryTeller
{
    public ProppStory story = null;
    public StoryGenerator storyGenerator = new StoryGenerator();
    public ProppFunctionContainer currentFunction = null;
    private bool _isStoryEnd = false;

    public void MakeStory()
    {
        story = storyGenerator.GenerateStory();
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