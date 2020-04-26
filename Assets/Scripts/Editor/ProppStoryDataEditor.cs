using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(ProppStoryData))]
public class ProppStoryDataEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
        ProppStoryData story = (ProppStoryData)target;
        if(GUILayout.Button("Make Function Description Fields"))
        {
            foreach(var m in story.moves)
            {
                foreach(var f in m.proppFunctions)
                {
                    switch(f.functionNumber)
                    {
                        case 7: case 27: case 28: case 31:
                            break;
                        default:
                            f.descriptionKey.Add("performCharName");
                            f.descriptionValue.Add("");
                            break;
                    }
                    switch (f.functionNumber)
                    {
                        case 3:
                        case 7:
                        case 10:
                        case 11:
                        case 14:
                        case 15:
                        case 17:
                        case 19:
                        case 20:
                        case 23:
                        case 24:
                            break;
                        default:
                            f.descriptionKey.Add("targetCharName");
                            f.descriptionValue.Add("");
                            break;
                    }
                    switch (f.functionNumber)
                    {
                        case 2:
                            f.descriptionKey.Add("interdiction");
                            f.descriptionValue.Add("");
                            break;
                        case 8:
                            f.descriptionKey.Add("vilainyOrLack");
                            f.descriptionValue.Add("");
                            break;
                        case 17:
                            f.descriptionKey.Add("brand");
                            f.descriptionValue.Add("");
                            break;
                        case 24:
                            f.descriptionKey.Add("claim");
                            f.descriptionValue.Add("");
                            break;
                        case 25:
                            f.descriptionKey.Add("task");
                            f.descriptionValue.Add("");
                            break;
                        case 26:
                            f.descriptionKey.Add("solution");
                            f.descriptionValue.Add("");
                            break;
                    }
                }
            }
        }

        if(GUILayout.Button("Erase All Description"))
        {
            foreach (var m in story.moves)
            {
                foreach (var f in m.proppFunctions)
                {
                    f.descriptionKey.Clear();
                    f.descriptionValue.Clear();
                }
            }
        }
    }
}
