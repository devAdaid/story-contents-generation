using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Function09_Mediation : ProppFunction
{
    public override int Number => 9;
    public override string Name => "Mediation";

    public ProppCharacter mediateCharacter;
    public ProppCharacter dispatchCharacter;
    public ProppMotivation motivation;
    public string form;
    public string mediatedTarget;
}