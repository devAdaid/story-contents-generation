using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_Dispatch : ProppAction
{
    public const string key = "dispatch";
    public override string ActionName => key;
    public string performChar;
    public string targetChar;
    public ProppAction liquidationAction;

    public override string Description()
    {
        return $"{performChar}이(가) {targetChar}에게 {liquidationAction.DescriptionAsNoun()}을 명하며 파견하였습니다.";
    }
    public override string DescriptionAsNoun()
    {
        return $"{performChar}이(가) {targetChar}에게 {liquidationAction.DescriptionAsNoun()}을 명하며 파견한 것";
    }

    public override void SetWithArgs(ProppStory story, List<string> arguments)
    {
        base.SetWithArgs(story, arguments);
        performChar = story.FindCharacterName(arguments[0]);
        targetChar = story.FindCharacterName(arguments[1]);
        liquidationAction = story.villainy.liquidationAction;
    }
}
