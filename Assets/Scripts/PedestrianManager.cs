using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedestrianManager : MonoBehaviour
{
    public GameObject pedestrianObject;
    public GameObject endPositionObject;

    private Vector3 startPos;
    private Vector3 endPos;

    public float TimeToWalk = 4f;
    private float currentLerpTime = 0f;

    private bool keyHit = false;

    void Start()
    {
        startPos = pedestrianObject.transform.position;
        endPos = new Vector3(endPositionObject.transform.position.x + 6f, pedestrianObject.transform.position.y, pedestrianObject.transform.position.z);
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
            if (currentLerpTime >= TimeToWalk)
            {
                currentLerpTime = TimeToWalk;
                keyHit = false;
                pedestrianObject.GetComponent<Animation>().Stop();
                pedestrianObject.GetComponent<AudioSource>().Stop();
            }

            float Perc = currentLerpTime / TimeToWalk;
            pedestrianObject.transform.position = Vector3.Lerp(startPos, endPos, Perc);
        }
    }


    public void StartMoving()
    {
        keyHit = true;
        pedestrianObject.GetComponent<Animation>().Play();
        pedestrianObject.GetComponent<AudioSource>().Play();
    }
}
