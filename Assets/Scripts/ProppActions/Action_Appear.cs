using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_Appear : ProppAction
{
    public const string _key = "appear";
    public ProppCharacter performChar;
    public ProppCharacter targetChar;

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
