using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StoryGenerator
{
    public abstract ProppStory GenerateStory();

    public void FillContext(ProppStory story)
    {

    }

    protected void Fill_Absentation(ProppStory story)
    {
        Dictionary<string, string> description = new Dictionary<string, string>();
        story.AddCharacter(new ProppCharacter("Absent Person", ECharacterType.Etc));
        description.Add("absentedCharName", "Absent Person");
        description.Add("form", "{0}이 부재중입니다.");

        ProppFunction function = story.FindFunction(1, 1);
        if (function != null)
        {
            function.SetFunctionDescription(story, description);
        }
    }
}