using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_Determine : ProppAction
{
    public const string key = "determine";
    public override string ActionName => key;
    public ProppAction liquidationAction = null;

    public override string Description()
    {
        return $"{liquidationAction.DescriptionAsNoun()}을(를) 결심하였습니다.";
    }
    public override string DescriptionAsNoun()
    {
        return $"{liquidationAction.DescriptionAsNoun()}을(를) 결심하는 것";
    }

    public override void SetWithArgs(ProppStory story, List<string> arguments)
    {
        base.SetWithArgs(story, arguments);
        liquidationAction = story.villainy.liquidationAction;
    }
}
