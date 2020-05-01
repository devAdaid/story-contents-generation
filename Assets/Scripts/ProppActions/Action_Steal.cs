using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_Steal : ProppAction
{
    public const string key = "steal";
    public override string ActionName => key;
    public string performChar;
    public string targetChar;
    public string obj;

    public override string Description()
    {
        return $"{performChar}이(가) {targetChar}에게서 {obj}를 빼앗았습니다.";
    }
    public override string DescriptionAsNoun()
    {
        return $"{performChar}이(가) {targetChar}에게서 {obj}를 빼앗은 것";
    }

    public override void SetWithArgs(ProppStory story, List<string> arguments)
    {
        base.SetWithArgs(story, arguments);
        performChar = story.FindCharacterName(arguments[0]);
        targetChar = story.FindCharacterName(arguments[1]);
        obj = story.FindCharacterName(arguments[2]);
    }

    public override void ShowAction(StoryTellingSystem stSystem)
    {
        stSystem.OnStageCharacter(performChar, targetChar);
    }
}
