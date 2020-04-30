using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProppVillainy
{
    public ProppAction villainyAction;
    public ProppAction liquidationAction;

    public ProppVillainy(ProppVillainyData data)
    {
        villainyAction = ProppActionFactory.Instance.CreateAction(data.villainyActionData);
        liquidationAction = ProppActionFactory.Instance.CreateAction(data.liquidationActionData);
    }
}