using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StoryTellingSystem : MonoBehaviour
{
    public Image bgImg;
    public Text storyText;
    public Text char1Text;
    public Text char2Text;
    public Text bgText;
    public Image char1Img;
    public Image char2Img;
    public SpriteDatabase spriteDatabase;

    private void Awake()
    {
        spriteDatabase.Initialize();
        char1Img.gameObject.SetActive(false);
        char2Img.gameObject.SetActive(false);
    }

    public void UnStageChar()
    {
        char1Img.gameObject.SetActive(false);
        char2Img.gameObject.SetActive(false);
    }

    public void OnStageCharacter(string ch1)
    {
        SetCharacter(char1Img, ch1);
        char2Img.gameObject.SetActive(false);
    }

    public void OnStageCharacter(string ch1, string ch2)
    {
        SetCharacter(char2Img, ch1);
        SetCharacter(char2Img, ch2);
    }

    public void SetText(string text)
    {
        storyText.text = text;
    }

    public void SetCharacter(Image charImg, string ch)
    {
        charImg.gameObject.SetActive(true);
        charImg.sprite = spriteDatabase.GetSprite(ch);
    }

    public void SetBackground(string bg)
    {
        bgImg.sprite = spriteDatabase.GetSprite(bg);
    }
}
