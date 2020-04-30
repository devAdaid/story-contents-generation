﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_Ask : ProppAction
{
    public const string key = "ask";
    public override string ActionName => key;
    public string performChar;
    public string targetChar;

    public override string Description()
    {
        return $"{performChar}이(가) {targetChar}에게 부탁했습니다.";
    }
    public override string DescriptionAsNoun()
    {
        return $"{performChar}이(가) {targetChar}에게 부탁하는 것";
    }

    public override void SetWithArgs(ProppStory story, List<string> arguments)
    {
        base.SetWithArgs(story, arguments);
        performChar = story.FindCharacterName(arguments[0]);
        targetChar = story.FindCharacterName(arguments[1]);
    }
}
