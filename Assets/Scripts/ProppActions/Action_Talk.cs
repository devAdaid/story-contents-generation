﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_Talk : ProppAction
{
    public const string _key = "talk";
    public ProppCharacter performChar;
    public ProppCharacter targetChar;
    public string contents;

    public override string Description(bool isPositive = true)
    {
        return string.Empty;
    }
    public override string DescriptionAsNoun(bool isPositive = true)
    {
        return string.Empty;
    }

    public override void SetWithArgs(List<string> arguments)
    {
        base.SetWithArgs(arguments);
    }
}
