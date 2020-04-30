using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
[System.Serializable]
public class ProppBackgroundData : ScriptableObject
{
    public ProppCharacterData characterData;
    public ProppLocationData locationData;

    public ProppBackgroundData(ProppBackgroundDataContainer data)
    {
        characterData = data.characterData;
        locationData = data.locationData;
    }
}

[System.Serializable]
public class ProppBackgroundDataContainer
{
    public ProppCharacterData characterData;
    public ProppLocationData locationData;

    public ProppBackgroundDataContainer(ProppBackgroundData data)
    {
        characterData = data.characterData;
        locationData = data.locationData;
    }
}
