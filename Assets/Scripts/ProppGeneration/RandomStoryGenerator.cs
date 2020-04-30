using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomStoryGenerator : StoryGenerator
{
    public override ProppStory GenerateStory()
    {
        ProppStory story = new ProppStory();
        GeneratePlot(story);
        return story;
    }

    public void GeneratePlot(ProppStory story)
    {
        story.AddFunction(new ProppFunction(8));
        story.AddFunction(new ProppFunction(9));
        story.AddFunction(new ProppFunction(10));
        story.AddFunction(new ProppFunction(11));
    }
}
