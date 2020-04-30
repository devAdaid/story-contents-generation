using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ProppVillainyData
{
    public ProppActionData villainyActionData;
    public ProppActionData liquidationActionData;

    public ProppVillainyData() { }
    public ProppVillainyData(ProppVillainy villainy)
    {
        villainyActionData = new ProppActionData(villainy.villainyAction);
        liquidationActionData = new ProppActionData(villainy.liquidationAction);
    }
}