using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryGenerator
{
    private ProppFunctionFactory _functionFactory = null;

    public StoryGenerator()
    {
        _functionFactory = new ProppFunctionFactory();
        _functionFactory.Initialize();
    }

    public ProppStory GenerateStory()
    {
        ProppStory story = new ProppStory();
        story.AddMove(GenerateMove(1));
        story.AddMove(GenerateMove(2));
        story.firstFunction = story.FirstMove.FirstFunction;
        return story;
    }

    public ProppMove GenerateMove(int number)
    {
        ProppMove move = new ProppMove(number);
        move.AddFunction(_functionFactory, 8);
        move.AddFunction(_functionFactory, 9);
        move.AddFunction(_functionFactory, 10);
        move.AddFunction(_functionFactory, 11);
        return move;
    }

}