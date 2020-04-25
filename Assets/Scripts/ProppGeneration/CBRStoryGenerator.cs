using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class CBRStoryGenerator : StoryGenerator
{
    public List<int> includeFunctions;
    private List<ProppStoryData> _storyData;
    private int _functionKey = 0;

    public CBRStoryGenerator()
    {
        _storyData = LoadStoryData();
    }

    public CBRStoryGenerator(List<int> include)
    {
        _storyData = LoadStoryData();
        SetCondition(include);
    }

    public void SetCondition(List<int> include)
    {
        include.Sort();
        includeFunctions = include;
        _functionKey = CalculateFunctionKey(includeFunctions);
        Debug.Log($"My Key: {_functionKey}");
    }

    public override ProppStory GenerateStory()
    {
        foreach (var st in _storyData)
        {
            st.evaluateDistance = EvaluateDistance(st.FunctionKey);
            Debug.Log($"{st.name}: {st.evaluateDistance}");
            if (st.evaluateDistance == 0) return new ProppStory(st);
        }
        _storyData.Sort();
        return new ProppStory(_storyData[0]);
    }

    public List<ProppStoryData> LoadStoryData()
    {
        var data = Resources.LoadAll<ProppStoryData>("Story");
        Debug.Log(data.Length);
        return data.ToList();
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

    public int EvaluateDistance(int otherStoryFunctionKey)
    {
        int evaluate = (~_functionKey) & otherStoryFunctionKey;
        return NumberOfSetBits(evaluate);
    }

    private int NumberOfSetBits(int i)
    {
        i = i - ((i >> 1) & 0x55555555);
        i = (i & 0x33333333) + ((i >> 2) & 0x33333333);
        return (((i + (i >> 4)) & 0x0F0F0F0F) * 0x01010101) >> 24;
    }
}
