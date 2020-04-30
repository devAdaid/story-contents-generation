using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ProppStory
{
    public ProppAction interdiction;
    public ProppVillainy villainy;
    public List<ProppFunction> functions = new List<ProppFunction>();
    //public List<ProppCharacter> characters = new List<ProppCharacter>();
    public ProppCharacterData characters;

    public ProppStory() { }

    public ProppStory(ProppStoryData data)
    {
        ProppActionFactory.Instance.SetStory(this);
        characters = data.characters;
        characters.SetCharDict();
        interdiction = ProppActionFactory.Instance.CreateAction(data.interdiction);
        villainy = new ProppVillainy(data.villainy);
        foreach(var f in data.functions)
        {
            AddFunction(new ProppFunction(f));
        }
    }

    public void AddFunction(ProppFunction func)
    {
        functions.Add(func);
    }

    public string FindCharacterName(string role)
    {
        return characters.FindCharacterName(role);
    }

    public ProppFunction FindFunction(int moveNumber, int functionNumber)
    {
        foreach (var f in functions)
        {
            if (f.Number == functionNumber)
            {
                return f;
            }
        }
        return null;
    }
}