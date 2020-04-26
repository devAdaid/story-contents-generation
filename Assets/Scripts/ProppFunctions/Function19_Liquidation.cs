using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Function19_Liquidation : ProppFunction
{
    public override int Number => 19;
    public override string Name => "Liquidation";
    public override string Designation => "K";

    public ProppCharacter performCharacter;
    public string vilainyOrLack;

    public override void SetFunctionDescription(ProppStory story, Dictionary<string, string> description)
    {
        base.SetFunctionDescription(story, description);
        string performCharName, targetCharName, form;
        if (description.TryGetValue("performCharName", out performCharName))
        {
            performCharacter = story.FindCharacter(performCharName);
        }
        if (description.TryGetValue("form", out form))
        {
            Form = form;
        }
        description.TryGetValue("vilainyOrLack", out vilainyOrLack);
    }

    public override string GetString()
    {
        return string.Format(Form, performCharacter.name, vilainyOrLack);
    }
}