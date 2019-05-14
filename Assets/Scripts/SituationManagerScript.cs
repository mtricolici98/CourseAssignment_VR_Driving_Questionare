using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SituationManagerScript : MonoBehaviour
{
    public GameObject[] situatuions;
    public GameObject camerarig;
    public GameObject audioSource;
    private int sit = 0;

    private void Start()
    {
        SwitchTo(0);
    }

    void Update()
    {
        if (Input.GetKeyDown("1") && sit > 0)
        {
            SwitchTo(--sit);
            Debug.Log(GetActiveSituation().name);
        }

        if (Input.GetKeyDown("2") && sit < 9)
        {
            SwitchTo(++sit);
            Debug.Log(GetActiveSituation().name);
        }
    }
    public void SwitchTo(int SituationNr)
    {
        foreach (GameObject sit in situatuions)
        {
            sit.SetActive(false);
        }
        situatuions[SituationNr].SetActive(true);
        var allchildren = situatuions[SituationNr].GetComponentInChildren<Transform>();
        foreach(Transform chi in allchildren)
        {
            if (chi.name == "PlayerCar")
            {
                camerarig.transform.SetParent(chi);
                camerarig.transform.localPosition = new Vector3(-0.37f, 1.11f, 0.09f);
                audioSource.transform.position = new Vector3(chi.transform.position.x, chi.transform.position.y + 10f, chi.transform.position.z);
            }
        }
    }

    public GameObject GetActiveSituation()
    {
        foreach(GameObject sit in situatuions)
        {
            if (sit.activeSelf == true)
            {
                return sit;
            }
        }
        return situatuions[0];
    }
}
