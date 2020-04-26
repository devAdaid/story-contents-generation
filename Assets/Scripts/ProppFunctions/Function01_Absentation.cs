using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Function01_Absentation : ProppFunction
{
    public override int Number => 1;
    public override string Name => "Absentation";
    public override string Designation => "β";

    public ProppCharacter absentedCharacter;

    public override void SetFunctionDescription(ProppStory story, Dictionary<string, string> description)
    {
        base.SetFunctionDescription(story, description);
        string absentedCharName, form;
        if(description.TryGetValue("targetCharName", out absentedCharName))
        {
            absentedCharacter = story.FindCharacter(absentedCharName);
        }
        if (description.TryGetValue("form", out form))
        {
            Form = form;
        }
    }

    public override string GetString()
    {
        return string.Format(Form, absentedCharacter.name);
    }
}