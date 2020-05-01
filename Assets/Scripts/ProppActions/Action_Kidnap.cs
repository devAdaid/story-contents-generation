using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_Kidnap : ProppAction
{
    public const string key = "kidnap";
    public override string ActionName => key;
    public string performChar;
    public string targetChar;

    public override string Description()
    {
        return $"{performChar}이(가) {targetChar}을(를) 납치하였습니다.";
    }
    public override string DescriptionAsNoun()
    {
        return $"{performChar}이(가) {targetChar}을(를) 납치하는 것";
    }

    public override void SetWithArgs(ProppStory story, List<string> arguments)
    {
        base.SetWithArgs(story, arguments);
        performChar = story.FindCharacterName(arguments[0]);
        targetChar = story.FindCharacterName(arguments[1]);
    }

    public override void ShowAction(StoryTellingSystem stSystem)
    {
        stSystem.OnStageCharacter(performChar, targetChar);
    }
}
