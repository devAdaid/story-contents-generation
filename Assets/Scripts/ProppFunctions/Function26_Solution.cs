using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Function26_Solution : ProppFunction
{
    public override int Number => 26;
    public override string Name => "Solution";
    public override string Designation => "N";

    public ProppCharacter performCharacter;
    public ProppCharacter targetCharacter;
    public string solution;

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
        description.TryGetValue("solution", out solution);
    }

    public override string GetString()
    {
        return string.Format(Form, performCharacter.name, targetCharacter.name, solution);
    }
}