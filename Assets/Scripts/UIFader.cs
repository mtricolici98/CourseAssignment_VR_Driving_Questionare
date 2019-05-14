using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIFader : MonoBehaviour
{
    public GameObject canvasGameObject;

    private CanvasGroup startButton;
    private CanvasGroup questionsPanel;

    private void Start()
    {
        startButton = canvasGameObject.transform.GetChild(0).GetComponent<CanvasGroup>();
        questionsPanel = canvasGameObject.transform.GetChild(1).GetComponent<CanvasGroup>();

        startButton.alpha = 1;
        questionsPanel.alpha = 0;
    }

    public void HideStart()
    {
        FadeOut(startButton);
    }

    public void ShowQuestions()
    {
        FadeIn(questionsPanel);
    }

    public void ShowScore(int score)
    { 
        var scorePanel = canvasGameObject.transform.GetChild(2).GetComponent<CanvasGroup>();
        if (scorePanel != null)
        {
            FadeOut(questionsPanel);
            scorePanel.transform.GetChild(1).GetComponent<TMPro.TextMeshProUGUI>().text = "Your score is " + score + "/9";
            FadeIn(scorePanel);
        }
    }

    public void FadeIn(CanvasGroup uiElement)
    {
        StartCoroutine(FadeCanvasGroup(uiElement, uiElement.alpha, 1, .5f));
    }

    public void FadeOut(CanvasGroup uiElement)
    {
        StartCoroutine(FadeCanvasGroup(uiElement, uiElement.alpha, 0, .5f));
    }

    public IEnumerator FadeCanvasGroup(CanvasGroup cg, float start, float end, float lerpTime = 1)
    {
        float _timeStartedLerping = Time.time;
        float timeSinceStarted = Time.time - _timeStartedLerping;
        float percentageComplete = timeSinceStarted / lerpTime;

        while (true)
        {
            timeSinceStarted = Time.time - _timeStartedLerping;
            percentageComplete = timeSinceStarted / lerpTime;

            float currentValue = Mathf.Lerp(start, end, percentageComplete);

            cg.alpha = currentValue;

            if (percentageComplete >= 1) break;

            yield return new WaitForFixedUpdate();
        }
    }
}
