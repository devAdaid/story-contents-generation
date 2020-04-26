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

    public ProppMove(ProppMoveData data, ProppStory story)
    {
        Number = data.number;
        foreach(var f in data.proppFunctions)
        {
            AddFunction(f, story);
        }
    }

    public void AddFunction(int functionNumber)
    {
        var function = new ProppFunctionContainer(functionNumber, Number);
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

    public void AddFunction(ProppFunctionData functionData, ProppStory story)
    {
        Dictionary<string, string> description = new Dictionary<string, string>();
        for(int i = 0; i < functionData.descriptionKey.Count; i++)
        {
            description.Add(functionData.descriptionKey[i], functionData.descriptionValue[i]);
        }

        var function = new ProppFunctionContainer(functionData.functionNumber, Number);
        function.containFunction.SetFunctionDescription(story, description);
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