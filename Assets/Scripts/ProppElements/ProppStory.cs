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
    public ProppLocationData locations;

    public string Text
    {
        get
        {
            if(string.IsNullOrEmpty(_text))
            {
                _text = string.Empty;
                foreach(var f in functions)
                {
                    foreach(var a in f.actions)
                    {
                        _text += a.Description();
                        _text += " ";
                    }
                }
            }
            return _text;
        }
    }
    private string _text = string.Empty;

    public ProppStory() { }

    public ProppStory(ProppStoryData data)
    {
        ProppActionFactory.Instance.SetStory(this);
        characters = data.characters;
        locations = data.locations;
        characters.SetCharDict();
        locations.SetLocationDict();
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

    public string FindLocationName(string key)
    {
        return locations.FindLocationName(key);
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