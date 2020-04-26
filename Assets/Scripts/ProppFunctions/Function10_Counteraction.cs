using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Function10_Counteraction : ProppFunction
{
    public override int Number => 10;
    public override string Name => "Beginning Counteraction";
    public override string Designation => "C";

    public ProppCharacter performCharacter;

    public override void SetFunctionDescription(ProppStory story, Dictionary<string, string> description)
    {
        base.SetFunctionDescription(story, description);
        string performCharName,form;
        if (description.TryGetValue("performCharName", out performCharName))
        {
            performCharacter = story.FindCharacter(performCharName);
        }
        if (description.TryGetValue("form", out form))
        {
            Form = form;
        }
    }

    public override string GetString()
    {
        return string.Format(Form, performCharacter.name);
    }
}