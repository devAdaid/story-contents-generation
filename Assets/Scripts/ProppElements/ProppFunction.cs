using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class ProppFunction
{
    public virtual int Number { get; private set; }
    public virtual int SubFunctionNumber => 0;
    public virtual string Name => string.Empty;
    public virtual string Designation => string.Empty;
    public List<ProppAction> actions = new List<ProppAction>();

    public override string ToString()
    {
        return $"{Number}: {Name}";
    }

    public ProppFunction(int number)
    {
        Number = number;
    }

    public ProppFunction(ProppFunctionData data)
    {
        Number = data.functionNumber;
        foreach(var a in data.actions)
        {
            var newAction = ProppActionFactory.Instance.CreateAction(a);
            actions.Add(newAction);
        }
    }
    
    public string Form = string.Empty;
    public Dictionary<string, string> description = new Dictionary<string, string>();
    public virtual void SetFunctionDescription(ProppStory story, Dictionary<string, string> description)
    {
        this.description = description;
    }
    public virtual string GetString() { return string.Empty; }
}
