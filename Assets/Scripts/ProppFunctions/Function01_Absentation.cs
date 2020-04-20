using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Function01_Absentation : ProppFunction
{
    public override int Number => 1;
    public override string Name => "Absentation";

    public ProppCharacter targetCharacter;
    public ProppMotivation motivation;
    public string form;
}