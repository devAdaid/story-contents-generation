using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Function08_VilainyLack : ProppFunction
{
    public override int Number => 8;
    public override string Name => "VilainyLack";
    public override string Designation => "A";

    public ProppCharacter performCharacter;
    public ProppCharacter targetCharacter;
    public ProppMotivation motivation;
    public string form;
}