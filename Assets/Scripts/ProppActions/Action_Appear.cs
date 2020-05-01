using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_Appear : ProppAction
{
    public const string key = "appear";
    public override string ActionName => key;
    public string performChar;

    public override string Description()
    {
        return $"{performChar}이(가) 나타났습니다.";
    }
    public override string DescriptionAsNoun()
    {
        return $"{performChar}이(가) 나타나는 것";
    }

    public override void SetWithArgs(ProppStory story, List<string> arguments)
    {
        base.SetWithArgs(story, arguments);
        performChar = story.FindCharacterName(arguments[0]);
    }


    public override void ShowAction(StoryTellingSystem stSystem)
    {
        stSystem.OnStageCharacter(performChar);
    }
}
