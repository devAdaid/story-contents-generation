using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Function03_Violation : ProppFunction
{
    public override int Number => 3;
    public override string Name => "Violation";

    public ProppCharacter performCharacter;
    public ProppMotivation motivation;
    public string form;
    public ProppCharacter villainCharacter;
    public string villainAppearForm;
}