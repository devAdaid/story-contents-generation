using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SpriteData
{
    public string key;
    public Sprite sprite;
}

public class SpriteDatabase : MonoBehaviour
{
    public List<SpriteData> sprites;
    private bool _isLoaded = false;
    private Dictionary<string, Sprite> _spriteDict = new Dictionary<string, Sprite>();

    public void Initialize()
    {
        foreach (var s in sprites)
        {
            _spriteDict.Add(s.key, s.sprite);
        }
    }

    public Sprite GetSprite(string sprName)
    {
        if(_spriteDict.ContainsKey(sprName))
        {
            return _spriteDict[sprName];
        }
        return null;
    }
}
