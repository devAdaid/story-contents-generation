using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_Disappear : ProppAction
{
    public const string key = "disappear";
    public override string ActionName => key;
    public string performChar;

    public override string Description()
    {
        return $"{performChar}이(가) 사라졌습니다.";
    }
    public override string DescriptionAsNoun()
    {
        return $"{performChar}이(가) 사라지는 것";
    }

    public override void SetWithArgs(ProppStory story, List<string> arguments)
    {
        base.SetWithArgs(story, arguments);
        performChar = story.FindCharacterName(arguments[0]);
    }
}
