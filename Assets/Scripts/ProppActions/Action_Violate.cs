using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_Violate : ProppAction
{
    public const string key = "violate";
    public override string ActionName => key;
    public string violateChar;
    public ProppAction violateAction = null;

    public override string Description()
    {
        return $"그러나 {violateChar}의 말을 어기고 {violateAction.Description()}";
    }
    public override string DescriptionAsNoun()
    {
        return $"{violateChar}의 말을 어기고 {violateAction.Description()}";
    }

    public override void SetWithArgs(ProppStory story, List<string> arguments)
    {
        base.SetWithArgs(story, arguments);
        violateChar = story.FindCharacterName(arguments[0]);
        violateAction = story.interdiction;
    }

    public override void TellAction(StoryTellingSystem stSystem)
    {
        violateAction.TellAction(stSystem);
    }

    public override void ShowAction(StoryTellingSystem stSystem)
    {
       violateAction.ShowAction(stSystem);
    }
}
