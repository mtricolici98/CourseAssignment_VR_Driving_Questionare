using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarBLinker : MonoBehaviour
{
    public Light rightBlinker;
    public Light leftBlinker;
    private bool on;

    public bool leftOn;
    public bool rightOn;

    void OnEnable()
    {
        on = false;
        if (leftOn)
        {
            TurnOnLeft();
        }
        if (rightOn)
        {
            TurnOnRight();
        }
    }
    // Update is called once per frame
    void Update()
    {
    }

    private void ResetLights()
    {
        leftBlinker.enabled = false;
        rightBlinker.enabled = false;
    }
    void TurnOnLeft()
    {
        StartCoroutine(Blink(leftBlinker));
    }

    void TurnOnRight()
    {
        StartCoroutine(Blink(rightBlinker));
    }

    IEnumerator Blink(Light light)
    {
        while (true)
        {
            on = !on;
            light.enabled = on;
            yield return new WaitForSeconds(0.5f);
        }
    }
}
