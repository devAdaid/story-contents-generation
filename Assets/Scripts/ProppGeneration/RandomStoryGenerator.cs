using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomStoryGenerator : StoryGenerator
{
    private bool _leaveHome = false;
    private bool _canEnd = false;

    public RandomStoryGenerator()
    {
        LoadPairData();
        LoadBackgroundData();
    }

    public override ProppStory GenerateStory(out ProppStoryData storyData)
    {
        storyData = new ProppStoryData();
        GeneratePlot(storyData);
        return FillContext(storyData);
    }

    #region Plots
    public void GeneratePlot(ProppStoryData story)
    {
        Premary(story);
        Complication(story);
        Donor(story);
        Course(story);
        if(_canEnd)
        {
            int rand = Random.Range(0, 2);
            if (rand == 1) return;
        }
        Ending(story);
    }

    private void Premary(ProppStoryData story)
    {
        int rand = Random.Range(0, 2);
        if (rand == 1)
        {
            story.functions.Add(new ProppFunctionData(2, "talk", "family", "princess", "interdiction"));
            story.functions.Add(new ProppFunctionData(3, "violate", "family"));
        }
    }

    private void Complication(ProppStoryData story)
    {
        story.functions.Add(new ProppFunctionData(8, "villainy"));
        story.functions.Add(new ProppFunctionData(9));
        story.functions.Add(new ProppFunctionData(10));
        AddRandom(story, 11);
    }

    private void Donor(ProppStoryData story)
    {
        int rand = Random.Range(0, 3);
        switch(rand)
        {
            case 0:
                story.functions.Add(new ProppFunctionData(12));
                story.functions.Add(new ProppFunctionData(13));
                story.functions.Add(new ProppFunctionData(14));
                break;
            case 1:
                story.functions.Add(new ProppFunctionData(12));
                story.functions.Add(new ProppFunctionData(13));
                story.functions.Add(new ProppFunctionData(14));
                story.functions.Add(new ProppFunctionData(15));
                break;
            case 2:
                story.functions.Add(new ProppFunctionData(12));
                story.functions.Add(new ProppFunctionData(13));
                story.functions.Add(new ProppFunctionData(15));
                story.functions.Add(new ProppFunctionData(14));
                break;
        }
    }

    private void Course(ProppStoryData story)
    {
        int rand = Random.Range(0, 5);
        switch (rand)
        {
            case 0:
                Struggle(story);
                story.functions.Add(new ProppFunctionData(19, "liquidate"));
                break;
            case 1:
                story.functions.Add(new ProppFunctionData(19, "liquidate"));
                AddIf(story, 20, _leaveHome);
                Pursuit(story);
                break;
            case 2:
                Struggle(story);
                story.functions.Add(new ProppFunctionData(19, "liquidate"));
                AddIf(story, 20, _leaveHome);
                break;
            case 3:
                Struggle(story);
                story.functions.Add(new ProppFunctionData(19, "liquidate"));
                AddIf(story, 20, _leaveHome);
                Pursuit(story);
                break;
            case 4:
                story.functions.Add(new ProppFunctionData(19, "liquidate"));
                AddIf(story, 20, _leaveHome);
                break;
        }
    }

    private void Pursuit(ProppStoryData story)
    {
        story.functions.Add(new ProppFunctionData(21));
        story.functions.Add(new ProppFunctionData(22));
    }

    private void Struggle(ProppStoryData story)
    {
        story.functions.Add(new ProppFunctionData(16));
        story.functions.Add(new ProppFunctionData(18));
    }
    
    private void Ending(ProppStoryData story)
    {
        int rand = Random.Range(0, 3);
        switch(rand)
        {
            case 0:
                story.functions.Add(new ProppFunctionData(31));
                break;
            case 1:
                story.functions.Add(new ProppFunctionData(30));
                story.functions.Add(new ProppFunctionData(31));
                break;
        }
    }

    private void AddIf(ProppStoryData story, int a, bool flag)
    {
        if(flag) story.functions.Add(new ProppFunctionData(a));
    }

    private void AddRandom(ProppStoryData story, int a)
    {
        int rand = Random.Range(0, 2);
        if (rand == 1)
        {
            story.functions.Add(new ProppFunctionData(a));
        }
    }

    private void AddPairRandom(ProppStoryData story, int a, int b)
    {
        int rand = Random.Range(0, 2);
        if (rand == 1)
        {
            story.functions.Add(new ProppFunctionData(a));
            story.functions.Add(new ProppFunctionData(b));
        }
    }
    #endregion

    public ProppStory FillContext(ProppStoryData storyData)
    {
        int key = 0;
        foreach (var f in storyData.functions)
        {
            key |= (1 << f.functionNumber);
        }
        
        RenameBackground(storyData);

        // Interdiction
        ReplaceActionData(ref storyData.interdiction, GetRandomPairFunction(_interdictionPairs).functionData[0].actions[0]);

        // Villainy
        var randomVillainyPair = GetRandomPairFunction(_villainyPairs);
        ReplaceActionData(ref storyData.villainy.villainyActionData, randomVillainyPair.functionData[0].actions[0]);
        ReplaceActionData(ref storyData.villainy.liquidationActionData, randomVillainyPair.functionData[1].actions[0]);

        ModifyWithPairFunction(storyData, GetRandomPairFunction(_complicationPairs));
        ModifyWithPairFunction(storyData, GetRandomPairFunction(_donorPairs));
        ModifyWithPairFunction(storyData, GetRandomPairFunction(_agentPairs));
        ModifyWithPairFunction(storyData, GetRandomPairFunction(_strugglePairs));
        ModifyWithPairFunction(storyData, GetRandomPairFunction(_pursuePairs));
        ModifyWithPairFunction(storyData, GetRandomPairFunction(_endPairs));
        return new ProppStory(storyData);
    }
}
