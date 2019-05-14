using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private int score;
    private int lvl;

    private void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.DpadLeft))
        {
            NextQuestion();
        }
        if (OVRInput.GetDown(OVRInput.Button.DpadRight))
        {
            StartQuestion();
        }
        if (Input.GetKeyDown("space"))
        {
            AnsweredCorrectly();
        }
    }

    private void Awake()
    {
        lvl = 0;
    }

    void StartGame()
    {

    }

    public void AnsweredCorrectly()
    {
        score++;
        NextQuestion();
    }

    public void AnswerWrongly()
    {
        NextQuestion();
    }

    void NextQuestion()
    {
        if (lvl < 8)
        {
            lvl++;
            gameObject.GetComponent<SituationManagerScript>().SwitchTo(lvl);
        }
        else
            finishGame();
    }
    
    public void StartQuestion()
    {
        var activeSit = gameObject.GetComponent<SituationManagerScript>().GetActiveSituation();
        activeSit.gameObject.GetComponent<MovementManager>().StartMoving();
        if (activeSit.name == "Situation2" || activeSit.name == "Situation9")
        {
            activeSit.gameObject.GetComponent<PedestrianManager>().StartMoving();
        }
    }

    void finishGame()
    {
        var activeSit = gameObject.GetComponent<SituationManagerScript>().GetActiveSituation();
        activeSit.gameObject.GetComponent<UIFader>().ShowScore(score);
    }
}
