using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProppFunctionContainer
{
    public ProppFunctionContainer nextFunction = null;
    public ProppFunction containFunction = null;
    public int MoveNumber { get; set; }

    public ProppFunctionContainer(ProppFunction function, int moveNumber)
    {
        containFunction = function;
        MoveNumber = moveNumber;
    }
}