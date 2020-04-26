using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Function14_MagicalAgent : ProppFunction
{
    public override int Number => 14;
    public override string Name => "Provision or receipt of magical agent";
    public override string Designation => "F";

    public ProppCharacter performCharacter;
    public ProppCharacter magicalAgent;

    public override void SetFunctionDescription(ProppStory story, Dictionary<string, string> description)
    {
        base.SetFunctionDescription(story, description);
        string performCharName, magicalAgentName, form;
        if (description.TryGetValue("performCharName", out performCharName))
        {
            performCharacter = story.FindCharacter(performCharName);
        }
        if (description.TryGetValue("targetCharName", out magicalAgentName))
        {
            magicalAgent = story.FindCharacter(magicalAgentName);
        }
        if (description.TryGetValue("form", out form))
        {
            Form = form;
        }
    }

    public override string GetString()
    {
        return string.Format(Form, performCharacter.name, magicalAgent.name);
    }
}