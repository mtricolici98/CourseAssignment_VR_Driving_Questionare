using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : MonoBehaviour
{
    public GameObject playerCarObject;
    public GameObject endPositionObject;
    public UIFader uiFader;

    private Vector3 startPos;
    private Vector3 endPos;

    public float TimeToDrive = 4f;
    private float currentLerpTime = 0f;

    private bool keyHit = false;

    void Start()
    {
        uiFader = gameObject.GetComponent<UIFader>();
        startPos = playerCarObject.transform.position;
        endPos = new Vector3(playerCarObject.transform.position.x, playerCarObject.transform.position.y, endPositionObject.transform.position.z - 4f); 
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            StartMoving();
        }

        if (keyHit == true)
        {
            currentLerpTime += Time.deltaTime;
            if (currentLerpTime >= TimeToDrive)
            {
                currentLerpTime = TimeToDrive;
                keyHit = false;
                uiFader.ShowQuestions();
            }

            float Perc = currentLerpTime / TimeToDrive;
            playerCarObject.transform.position = Vector3.Lerp(startPos, endPos, Perc);
        }
    }

    public void StartMoving()
    {
        keyHit = true;
        uiFader.HideStart();
    }

}
