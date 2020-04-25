using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ECharacterType
{
    None,
    Hero,
    Villain,
    FalseHero,
    Helper,
    Dispatcher,
    PersonSoughtFor,
    Etc
}

public class ProppCharacter
{
    public string name;
    public ECharacterType characterType;

    public ProppCharacter(string n, ECharacterType charType)
    {
        name = n;
        characterType = charType;
    }
}