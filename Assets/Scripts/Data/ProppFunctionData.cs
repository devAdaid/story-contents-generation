using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[System.Serializable]
public class ProppFunctionData
{
    public int functionNumber = 0;
    public List<ProppActionData> actions = new List<ProppActionData>();

    public ProppFunctionData(int number)
    {
        functionNumber = number;
    }

    public ProppFunctionData(int number, string action)
    {
        functionNumber = number;
        actions.Add(new ProppActionData(action, null));
    }

    public ProppFunctionData(int number, string action, params string[] args)
    {
        functionNumber = number;
        actions.Add(new ProppActionData(action, args.ToList()));
    }

    public ProppFunctionData(ProppFunction function)
    {
        functionNumber = function.Number;
        foreach(var a in function.actions)
        {
            actions.Add(new ProppActionData(a));
        }
    }

    public void ReplaceWith(ProppFunctionData functionData)
    {
        ClearActions();
        foreach(var a in functionData.actions)
        {
            AddActionData(a);
        }
    }

    public void AddActionData(ProppActionData actionData)
    {
        actions.Add(actionData);
    }

    public void ClearActions()
    {
        actions.Clear();
    }
}