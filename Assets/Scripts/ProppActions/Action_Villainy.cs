using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_Villainy : ProppAction
{
    public const string key = "villainy";
    public override string ActionName => key;
    public ProppAction villainyAction = null;

    public override string Description()
    {
        return villainyAction.Description();
    }
    public override string DescriptionAsNoun()
    {
        return villainyAction.DescriptionAsNoun();
    }

    public override void SetWithArgs(ProppStory story, List<string> arguments)
    {
        base.SetWithArgs(story, arguments);
        villainyAction = story.villainy.villainyAction;
    }

    public override void TellAction(StoryTellingSystem stSystem)
    {
        villainyAction.TellAction(stSystem);
    }

    public override void ShowAction(StoryTellingSystem stSystem)
    {
        villainyAction.ShowAction(stSystem);
    }
}
