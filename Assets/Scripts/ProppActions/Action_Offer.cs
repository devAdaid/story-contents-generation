using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_Offer : ProppAction
{
    public const string key = "offer";
    public override string ActionName => key;
    public string performChar;
    public string targetChar;

    public override string Description()
    {
        return $"{performChar}은(는) 고마워하며 {targetChar}을(를) 도와주겠다고 하였습니다.";
    }
    public override string DescriptionAsNoun()
    {
        return $"{performChar}은(는) 고마워하며 {targetChar}을(를) 도와주겠다고 하였습니다.";
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
