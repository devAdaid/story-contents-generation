using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Function05_Delivery : ProppFunction
{
    public override int Number => 5;
    public override string Name => "Delivery";
    public override string Designation => "ζ";

    public ProppCharacter performCharacter;
    public ProppCharacter targetCharacter;
    public string form;
}
