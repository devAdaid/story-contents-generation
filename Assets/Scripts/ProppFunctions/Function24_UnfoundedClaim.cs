using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Function24_UnfoundedClaim : ProppFunction
{
    public override int Number => 24;
    public override string Name => "Unfounded Claim";
    public override string Designation => "L";

    public ProppCharacter performCharacter;
    public string claim;

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
        description.TryGetValue("claim", out claim);
    }

    public override string GetString()
    {
        return string.Format(Form, performCharacter.name, claim);
    }
}