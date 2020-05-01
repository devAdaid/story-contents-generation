using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_Move : ProppAction
{
    public const string key = "move";
    public override string ActionName => key;
    public string performChar;
    public string targetLocation;

    public override string Description()
    {
        return $"{performChar}이(가) {targetLocation}(으)로 갔습니다.";
    }
    public override string DescriptionAsNoun()
    {
        return $"{performChar}이(가) {targetLocation}(으)로 가는 것";
    }

    public override void SetWithArgs(ProppStory story, List<string> arguments)
    {
        base.SetWithArgs(story, arguments);
        performChar = story.FindCharacterName(arguments[0]);
        targetLocation = story.FindLocationName(arguments[1]);
    }

    public override void ShowAction(StoryTellingSystem stSystem)
    {
        stSystem.OnStageCharacter(performChar);
        stSystem.SetBackground(targetLocation);
    }
}
