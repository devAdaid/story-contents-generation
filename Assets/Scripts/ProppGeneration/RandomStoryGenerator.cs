using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomStoryGenerator : StoryGenerator
{
    private ProppGrammer _grammer = new ProppGrammer();

    public override ProppStory GenerateStory()
    {
        ProppStory story = new ProppStory();
        GeneratePlot(story);
        return story;
    }

    public void GeneratePlot(ProppStory story)
    {
        story.AddMove(GenerateMove(1));
        story.firstFunction = story.FirstMove.FirstFunction;
    }

    public void GenerateContext(ProppStory story)
    {
        // For test
        ProppCharacter hero = new ProppCharacter("Hero", ECharacterType.Hero);
        ProppCharacter villain = new ProppCharacter("Villain", ECharacterType.Villain);
        ProppCharacter helper = new ProppCharacter("Helper", ECharacterType.Helper);
        story.AddCharacter(hero);
        story.AddCharacter(villain);
        story.AddCharacter(helper);
    }

    public ProppMove GenerateMove(int number)
    {
        ProppMove move = new ProppMove(number);
        for (int i = 1; i <= 31; i++)
        {
            AddFunction(move, i);
        }
        return move;
    }

    public void AddFunction(ProppMove move, int functionNumber)
    {
        var includeType = _grammer.GetFunctionIncludeType(move, functionNumber);
        switch (includeType)
        {
            case EFunctionIncludeType.ShouldBeIncluded:
                move.AddFunction(functionNumber);
                break;
            case EFunctionIncludeType.Optional:
                int rand = Random.Range(0, 2);
                if (rand == 1) move.AddFunction(functionNumber);
                break;
        }
    }
}
