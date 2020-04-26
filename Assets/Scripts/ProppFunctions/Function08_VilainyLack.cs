using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Function08_VilainyLack : ProppFunction
{
    public override int Number => 8;
    public override string Name => "VilainyLack";
    public override string Designation => "A";

    public ProppCharacter performCharacter;
    public ProppCharacter targetCharacter;
    public string vilainyOrLack;

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
        description.TryGetValue("vilainyOrLack", out vilainyOrLack);
    }

    public override string GetString()
    {
        return string.Format(Form, performCharacter.name, targetCharacter.name);
    }
}