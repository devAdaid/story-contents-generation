using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProppAction
{
    public virtual void SetWithArgs(List<string> arguments) { }
    public virtual string Description(bool isPositive = true)
    {
        return string.Empty;
    }
    public virtual string DescriptionAsNoun(bool isPositive = true)
    {
        return string.Empty;
    }
}
