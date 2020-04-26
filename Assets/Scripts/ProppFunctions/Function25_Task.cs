using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Function25_Task : ProppFunction
{
    public override int Number => 25;
    public override string Name => "Difficult Task";
    public override string Designation => "M";

    public ProppCharacter performCharacter;
    public ProppCharacter targetCharacter;
    public string task;

    public override void SetFunctionDescription(ProppStory story, Dictionary<string, string> description)
    {
        base.SetFunctionDescription(story, description);
        string performCharName, targetCharName, form;
        if (description.TryGetValue("performCharName", out performCharName))
        {
            performCharacter = story.FindCharacter(performCharName);
        }
        if (description.TryGetValue("targetCharName", out targetCharName))
        {
            targetCharacter = story.FindCharacter(targetCharName);
        }
        if (description.TryGetValue("form", out form))
        {
            Form = form;
        }
        description.TryGetValue("task", out task);
    }

    public override string GetString()
    {
        return string.Format(Form, performCharacter.name, targetCharacter.name, task);
    }
}