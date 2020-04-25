using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ProppMove
{
    public List<ProppFunctionContainer> proppFunctions = new List<ProppFunctionContainer>();
    public ProppFunctionContainer FirstFunction
    {
        private set; get;
    }
    public ProppFunctionContainer LastFunction
    {
        private set; get;
    }
    public int Number { get; set; }

    public ProppMove(int number)
    {
        Number = number;
    }

    public ProppMove(ProppMoveData data)
    {
        Number = data.number;
        foreach(var f in data.proppFunctions)
        {
            AddFunction(f.functionNumber);
        }
    }

    public void AddFunction(int idx)
    {
        var function = new ProppFunctionContainer(idx, Number);
        if (proppFunctions.Count == 0)
        {
            FirstFunction = function;
        }
        if (LastFunction != null)
        {
            LastFunction.nextFunction = function;
        }
        LastFunction = function;

        proppFunctions.Add(function);
    }

    public ProppFunction FindFunction(int functionNumber)
    {
        foreach (var f in proppFunctions)
        {
            if (f.containFunction.Number == functionNumber)
            {
                return f.containFunction;
            }
        }
        return null;
    }
}