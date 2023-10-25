using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StoryManager : MonoBehaviour
{
    [SerializeField] Button escape, work, die, Introduction;
    GameObject IntroductionPanel;
    [SerializeField] TextMeshProUGUI storyResult;
    void Start()
    {
        escape.onClick.AddListener(showStoryEscape);
        work.onClick.AddListener(showStoryWork);
        die.onClick.AddListener(showStoryDie);
        Introduction.onClick.AddListener(ShowIntroduction);
        IntroductionPanel = GameObject.Find("IntroductionPanel");
        IntroductionPanel.SetActive(false);
        storyResult.text = "Pick a Path";
    }
    void showStoryEscape()
    {
        storyResult.text = "There is no Escape. Get back to work peasant";
    }
    void showStoryWork()
    {
        storyResult.text = "Good keep working like that for all of eternity";
    }
    void showStoryDie()
    {
        storyResult.text = "Your boss has found your soul and forced you to get back to work";
    }
    void ShowIntroduction()
    {
        IntroductionPanel.SetActive(true);
    }
    void Update()
    {
        if(IntroductionPanel.activeSelf && Input.GetKeyDown(KeyCode.Escape))
        {
            IntroductionPanel.SetActive(false);
        }
    }
}
