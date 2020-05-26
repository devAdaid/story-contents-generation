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
    public Image char0Img;
    public Image char1Img;
    public Image char2Img;
    public Animator char0Anim;
    public Animator char1Anim;
    public Animator char2Anim;
    public SpriteDatabase spriteDatabase;

    private void Awake()
    {
        spriteDatabase.Initialize();
        char0Img.gameObject.SetActive(false);
        char1Img.gameObject.SetActive(false);
        char2Img.gameObject.SetActive(false);
    }

    public void DefaultSetting()
    {
        UnStageChar();
        char0Anim.Play("Idle");
        char1Anim.Play("Idle");
        char2Anim.Play("Idle");
    }

    public void UnStageChar()
    {
        char0Img.gameObject.SetActive(false);
        char1Img.gameObject.SetActive(false);
        char2Img.gameObject.SetActive(false);
    }

    public void OnStageCharacter(string ch)
    {
        SetCharacter(char0Img, ch);
        char1Img.gameObject.SetActive(false);
        char2Img.gameObject.SetActive(false);
    }

    public void OnStageCharacter(string ch1, string ch2)
    {
        SetCharacter(char1Img, ch1);
        SetCharacter(char2Img, ch2);
        char0Img.gameObject.SetActive(false);
    }

    public void AnimateCharacter0(string anim)
    {
        char0Anim.Play(anim);
    }

    public void AnimateCharacter1(string anim)
    {
        char1Anim.Play(anim);
    }

    public void AnimateCharacter2(string anim)
    {
        char2Anim.Play(anim);
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
