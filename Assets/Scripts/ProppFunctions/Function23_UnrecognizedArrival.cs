using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Function23_UnrecognizedArrival : ProppFunction
{
    public override int Number => 23;
    public override string Name => "Unrecognized Arrival";
    public override string Designation => "o";

    public ProppCharacter performCharacter;

    public override void SetFunctionDescription(ProppStory story, Dictionary<string, string> description)
    {
        base.SetFunctionDescription(story, description);
        string performCharName, form;
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