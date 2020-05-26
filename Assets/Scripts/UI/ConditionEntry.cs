using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConditionEntry : MonoBehaviour
{
    public StoryTellerTest cbr;
    public Toggle toggle;
    public int id;
    public Text conditionText;

    public void Set(int nid, string nstr)
    {
        id = nid;
        conditionText.text = nstr;
    }

    public void SetCondition(bool flag)
    {
        if(flag)
        {
            cbr.AddCondition(id);
        }
        else
        {
            cbr.RemoveCondition(id);
        }
    }
}
