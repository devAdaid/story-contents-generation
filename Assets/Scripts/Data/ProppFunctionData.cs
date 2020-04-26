using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[System.Serializable]
public class ProppFunctionData
{
    public int functionNumber = 0;
    public List<string> descriptionKey = new List<string>();
    public List<string> descriptionValue = new List<string>();
    public ProppFunctionData(ProppFunction function)
    {
        functionNumber = function.Number;
        descriptionKey = function.description.Keys.ToList();
        descriptionValue = function.description.Values.ToList();
    }
}