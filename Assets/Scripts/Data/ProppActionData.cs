﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ProppActionData
{
    public string actionName;
    public List<string> arguments;

    public ProppActionData(ProppAction action)
    {
        actionName = action.ActionName;
        arguments = action.arguments;
    }
}
