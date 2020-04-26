using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Function28_Exposure : ProppFunction
{
    public override int Number => 28;
    public override string Name => "Exposure";
    public override string Designation => "Ex";

    public ProppCharacter targetCharacter;

    public override void SetFunctionDescription(ProppStory story, Dictionary<string, string> description)
    {
        base.SetFunctionDescription(story, description);
        string targetCharName, form;
        if (description.TryGetValue("targetCharName", out targetCharName))
        {
            targetCharacter = story.FindCharacter(targetCharName);
        }
        if (description.TryGetValue("form", out form))
        {
            Form = form;
        }
    }

    public override string GetString()
    {
        return string.Format(Form, targetCharacter.name);
    }
}