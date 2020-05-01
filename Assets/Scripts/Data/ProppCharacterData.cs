using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ProppCharacterData
{
    public string heroName;
    public string villainName;
    public string donorName;
    public string familyName;
    public string princessName;
    public string helperName;
    private Dictionary<string, string> charDictonary = new Dictionary<string, string>();

    public void SetDict()
    {
        if (charDictonary == null || charDictonary.Count == 0)
        {
            charDictonary.Add("hero", heroName);
            charDictonary.Add("villain", villainName);
            charDictonary.Add("donor", donorName);
            charDictonary.Add("family", familyName);
            charDictonary.Add("princess", princessName);
            charDictonary.Add("helper", helperName);
        }
        else
        {
            charDictonary["hero"] = heroName;
            charDictonary["villain"] = villainName;
            charDictonary["donor"] = donorName;
            charDictonary["family"] = familyName;
            charDictonary["princess"] = princessName;
            charDictonary["helper"] = helperName;
        }
    }
    
    public string FindCharacterName(string role)
    {
        string result = string.Empty;
        if (!charDictonary.TryGetValue(role, out result))
        {
            Debug.LogError($"Role {role} not exist");
        }
        return result;
    }
}
