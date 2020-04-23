using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProppStory
{
    public ProppFunctionContainer firstFunction = null;
    public List<ProppMove> moves = new List<ProppMove>();
    public ProppMove FirstMove
    {
        private set; get;
    }
    public ProppMove LastMove
    {
        private set; get;
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
    }
}