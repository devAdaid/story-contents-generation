using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CBRStoryGenerator : StoryGenerator
{
    public List<int> includeFunctions;
    private int _functionKey = 0;

    public CBRStoryGenerator()
    {
        LoadStoryData();
        LoadPairData();
        LoadBackgroundData();
    }

    public CBRStoryGenerator(List<int> include)
    {
        LoadStoryData();
        LoadPairData();
        LoadBackgroundData();
        SetCondition(include);
    }

    public void SetCondition(List<int> include)
    {
        include.Sort();
        includeFunctions = include;
        _functionKey = CalculateFunctionKey(includeFunctions);
        //Debug.Log($"My Key: {_functionKey}");
    }

    public override ProppStory GenerateStory(out ProppStoryData storyData)
    {
        storyData = RetrieveStoryData();
        ProppStory story = ReuseReviseStory(storyData);
        return story;
    }

    public int CalculateFunctionKey(List<int> include)
    {
        int result = 0;
        foreach (var i in include)
        {
            result |= (1 << i);
        }
        return result;
    }
    
    private ProppStoryData RetrieveStoryData()
    {
        foreach (var st in _storyData)
        {
            st.evaluateDistance = EvaluateDistance(includeFunctions.Count, _functionKey, st.FunctionKey);
            //Debug.Log($"{st.name}: {st.evaluateDistance}");
            if (st.evaluateDistance == 0) return st;
        }
        _storyData.Sort();
        return _storyData[0];
    }

    private ProppStory ReuseReviseStory(ProppStoryData storyData)
    {
        ProppStoryData cloneData = new ProppStoryData(storyData);
        
        // Background
        RenameBackground(cloneData);

        // Interdiction
        ReplaceActionData(ref cloneData.interdiction, GetRandomPairFunction(_interdictionPairs).functionData[0].actions[0]);

        // Villainy
        var randomVillainyPair = GetRandomPairFunction(_villainyPairs);
        ReplaceActionData(ref cloneData.villainy.villainyActionData, randomVillainyPair.functionData[0].actions[0]);
        ReplaceActionData(ref cloneData.villainy.liquidationActionData, randomVillainyPair.functionData[1].actions[0]);
        
        // Others
        ModifyWithPairFunction(cloneData, GetRandomPairFunction(_donorPairs));
        ModifyWithPairFunction(cloneData, GetRandomPairFunction(_agentPairs));
        ModifyWithPairFunction(cloneData, GetRandomPairFunction(_strugglePairs));
        ModifyWithPairFunction(cloneData, GetRandomPairFunction(_pursuePairs));
        ModifyWithPairFunction(cloneData, GetRandomPairFunction(_endPairs));

        return new ProppStory(cloneData);
    }
}
