using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ProppLocationData
{
    public string home;
    public string outHome;
    public string villainHouse;
    public string donorHome;
    private Dictionary<string, string> _locationDict = new Dictionary<string, string>();

    public void SetDict()
    {
        if (_locationDict == null || _locationDict.Count == 0)
        {
            _locationDict.Add("Home", home);
            _locationDict.Add("OutHome", outHome);
            _locationDict.Add("VillainHouse", villainHouse);
            _locationDict.Add("DonorHome", donorHome);
        }
        else
        {
            _locationDict["Home"] = home;
            _locationDict["OutHome"] = outHome;
            _locationDict["DonorHome"] = donorHome;
            _locationDict["VillainHouse"] = villainHouse;
        }
    }

    public string FindLocationName(string key)
    {
        string result = string.Empty;
        if(!_locationDict.TryGetValue(key, out result))
        {
            Debug.LogError($"Location key {key} not exist");
        }
        return result;
    }
}
