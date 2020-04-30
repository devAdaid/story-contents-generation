using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProppAction
{
    public List<string> arguments;
    public virtual string ActionName => string.Empty;
    public virtual void SetWithArgs(ProppStory story, List<string> arguments)
    {
        this.arguments = arguments;
    }
    public virtual string Description()
    {
        return string.Empty;
    }
    public virtual string DescriptionAsNoun()
    {
        return string.Empty;
    }

    public override string ToString()
    {
        string result = $"{ActionName}(";
        if(arguments != null)
        {
            foreach (var arg in arguments)
            {
                result += $"{arg},";
            }
        }
        result += ")";
        return result;
    }
}
