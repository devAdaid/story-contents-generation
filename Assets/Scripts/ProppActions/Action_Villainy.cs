using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_Villainy : ProppAction
{
    public const string key = "villainy";
    public override string ActionName => key;
    public ProppAction liquidationAction = null;

    public override string Description()
    {
        return liquidationAction.Description();
    }
    public override string DescriptionAsNoun()
    {
        return liquidationAction.DescriptionAsNoun();
    }

    public override void SetWithArgs(ProppStory story, List<string> arguments)
    {
        base.SetWithArgs(story, arguments);
        liquidationAction = story.villainy.villainyAction;
    }
}
