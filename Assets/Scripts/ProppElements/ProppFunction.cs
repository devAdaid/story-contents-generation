using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class ProppFunction
{
    public virtual int Number => 0;
    public virtual int SubFunctionNumber => 0;
    public virtual string Name => string.Empty;
    public virtual string Designation => string.Empty;
    public string Form = string.Empty;
    public Dictionary<string, string> description = new Dictionary<string, string>();

    public override string ToString()
    {
        return $"{Number}: {Name}";
    }

    public virtual void SetFunctionDescription(ProppStory story, Dictionary<string, string> description)
    {
        this.description = description;
    }
    public virtual string GetString() { return string.Empty; }
}
