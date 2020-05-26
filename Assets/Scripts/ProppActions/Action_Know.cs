using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_Know : ProppAction
{
    public const string key = "know";
    public override string ActionName => key;
    public string performChar;
    public string contents;

    public override string Description()
    {
        return $"{performChar}이(가) {contents}을(를) 알게 되었습니다.";
    }
    public override string DescriptionAsNoun()
    {
        return $"{performChar}이(가) {contents}을(를) 알게 되는 것";
    }

    public override void SetWithArgs(ProppStory story, List<string> arguments)
    {
        base.SetWithArgs(story, arguments);
        performChar = story.FindCharacterName(arguments[0]);
        contents = arguments[1];
        if (contents == "villainy")
        {
            contents = story.villainy.villainyAction.DescriptionAsNoun();
        }
    }

    public override void ShowAction(StoryTellingSystem stSystem)
    {
        stSystem.OnStageCharacter(performChar);
        stSystem.AnimateCharacter0("Know");
    }
}
