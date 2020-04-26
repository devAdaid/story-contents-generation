using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Function02_Interdiction : ProppFunction
{
    public override int Number => 2;
    public override string Name => "Interdiction";
    public override string Designation => "γ";

    public ProppCharacter performCharacter;
    public ProppCharacter targetCharacter;
    public string interdiction;

    public override void SetFunctionDescription(ProppStory story, Dictionary<string, string> description)
    {
        base.SetFunctionDescription(story, description);
        string performCharName, targetCharName, interdiction, form;
        if (description.TryGetValue("performCharName", out performCharName))
        {
            performCharacter = story.FindCharacter(performCharName);
        }
        if (description.TryGetValue("targetCharName", out targetCharName))
        {
            targetCharacter = story.FindCharacter(targetCharName);
        }
        if (description.TryGetValue("interdiction", out interdiction))
        {
            this.interdiction = interdiction;
        }
        if (description.TryGetValue("form", out form))
        {
            Form = form;
        }
    }

    public override string GetString()
    {
        return string.Format(Form, performCharacter.name, targetCharacter.name, interdiction);
    }
}