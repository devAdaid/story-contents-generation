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
    private Dictionary<string, string> charDictonary = new Dictionary<string, string>();

    public void SetCharDict()
    {
        charDictonary.Add("hero", heroName);
        charDictonary.Add("villain", villainName);
        charDictonary.Add("donor", donorName);
        charDictonary.Add("family", familyName);
        charDictonary.Add("princess", princessName);
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
