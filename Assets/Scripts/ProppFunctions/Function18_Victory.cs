using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Function18_Victory : ProppFunction
{
    public override int Number => 18;
    public override string Name => "Victory";
    public override string Designation => "I";

    public ProppCharacter performCharacter;
    public ProppCharacter targetCharacter;

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
    }

    public override string GetString()
    {
        return string.Format(Form, performCharacter.name, targetCharacter.name);
    }
}