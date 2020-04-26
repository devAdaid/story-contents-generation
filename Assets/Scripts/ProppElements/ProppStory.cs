using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class ProppStory
{
    public ProppFunctionContainer firstFunction = null;
    public List<ProppMove> moves = new List<ProppMove>();
    public List<ProppCharacter> characters = new List<ProppCharacter>();
    private Dictionary<string, ProppCharacter> _charDictinary = new Dictionary<string, ProppCharacter>();
    private Dictionary<int, ProppMove> _moveDictionary = new Dictionary<int, ProppMove>();

    public ProppMove FirstMove
    {
        private set; get;
    }
    public ProppMove LastMove
    {
        private set; get;
    }

    public ProppStory() { }

    public ProppStory(ProppStoryData data)
    {
        characters = data.characters;
        foreach(var m in data.moves)
        {
            AddMove(new ProppMove(m, this));
        }
        firstFunction = FirstMove.FirstFunction;
    }

    public void AddMove(ProppMove move)
    {
        if (moves.Count == 0)
        {
            FirstMove = move;
        }
        if (LastMove != null)
        {
            LastMove.LastFunction.nextFunction = move.FirstFunction;
        }
        LastMove = move;
        moves.Add(move);
        _moveDictionary.Add(move.Number, move);
    }

    public void AddCharacter(ProppCharacter character)
    {
        characters.Add(character);
        _charDictinary.Add(character.name, character);
    }

    public ProppCharacter FindCharacter(string charName)
    {
        return _charDictinary[charName];
    }

    public ProppCharacter FindCharacter(ECharacterType characterType)
    {
        foreach(var ch in characters)
        {
            if (ch.characterType == characterType) return ch;
        }
        return null;
    }

    public ProppFunction FindFunction(int moveNumber, int functionNumber)
    {
        ProppMove move = null;
        if(_moveDictionary.TryGetValue(moveNumber, out move))
        {
            foreach(var f in move.proppFunctions)
            {
                if(f.MoveNumber == functionNumber)
                {
                    return f.containFunction;
                }
            }
        }
        return null;
    }
}