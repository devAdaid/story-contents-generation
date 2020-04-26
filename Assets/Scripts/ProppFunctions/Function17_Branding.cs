using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Function17_Branding : ProppFunction
{
    public override int Number => 17;
    public override string Name => "Branding";
    public override string Designation => "J";
    
    public ProppCharacter targetCharacter;
    public string brand;

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
        description.TryGetValue("brand", out brand);
    }

    public override string GetString()
    {
        return string.Format(Form, targetCharacter.name, brand);
    }
}