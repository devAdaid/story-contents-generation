using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Action_Move : ProppAction
{
    public const string _key = "move";
    public ProppCharacter performChar;
    public ProppLocation loocation;

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
