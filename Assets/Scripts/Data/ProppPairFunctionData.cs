using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ProppPairFunctionData
{
    public List<ProppFunctionData> functionData;

    public ProppPairFunctionData(ProppPairFunctionDataContainer data)
    {
        functionData = data.functionData;
    }

    public int CalculateFunctionKey()
    {
        int result = 0;
        foreach (var f in functionData)
        {
            result |= (1 << f.functionNumber);
        }
        return result;
    }
}

public class ProppPairFunctionDataContainer
{
    public List<ProppFunctionData> functionData;
    public ProppPairFunctionDataContainer(ProppPairFunctionData data)
    {
        functionData = data.functionData;
    }
}