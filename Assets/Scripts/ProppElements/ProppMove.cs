using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public void AddFunction(ProppFunctionFactory factory, int idx)
    {
        var function = new ProppFunctionContainer(factory.CreateFunction(idx), Number);
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
}