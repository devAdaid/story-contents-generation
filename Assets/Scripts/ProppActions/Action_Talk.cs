using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_Talk : ProppAction
{
    public const string key = "talk";
    public override string ActionName => key;
    public string performChar;
    public string targetChar;
    public string contents;

    public override string Description()
    {
        return $"{performChar}이 {targetChar}에게 {contents} 말했습니다.";
    }
    public override string DescriptionAsNoun()
    {
        return $"{performChar}이 {targetChar}에게 {contents}라고 말하는 것";
    }

    public override void SetWithArgs(ProppStory story, List<string> arguments)
    {
        base.SetWithArgs(story, arguments);
        performChar = story.FindCharacterName(arguments[0]);
        targetChar = story.FindCharacterName(arguments[1]);
        contents = arguments[2];
        if (contents == "interdiction")
        {
            contents = story.interdiction.DescriptionAsNoun();
            contents += "을 금지한다고"
;       }
    }
}
