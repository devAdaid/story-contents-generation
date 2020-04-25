using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ProppMoveData
{
    public int number = 0;
    public List<ProppFunctionData> proppFunctions = new List<ProppFunctionData>();
    public ProppMoveData(ProppMove move)
    {
        number = move.Number;
        foreach (var f in move.proppFunctions)
        {
            proppFunctions.Add(new ProppFunctionData(f.containFunction));
        }
    }
}