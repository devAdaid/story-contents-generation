using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ProppFunctionContainer
{
    public ProppFunctionContainer nextFunction = null;
    public ProppFunction containFunction = null;
    public int MoveNumber { get; set; }

    public ProppFunctionContainer(int functionNumber, int moveNumber)
    {
        containFunction = ProppFunctionFactory.Instance.CreateFunction(functionNumber);
        MoveNumber = moveNumber;
    }
}