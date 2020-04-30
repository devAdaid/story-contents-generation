using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[System.Serializable]
public class ProppFunctionData
{
    public int functionNumber = 0;
    public List<ProppActionData> actions = new List<ProppActionData>();
    public ProppFunctionData(ProppFunction function)
    {
        functionNumber = function.Number;
        foreach(var a in function.actions)
        {
            actions.Add(new ProppActionData(a));
        }
    }
}