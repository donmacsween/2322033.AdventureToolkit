using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PuzzleExit : MonoBehaviour
{
    [SerializeField] private UnityEvent events;
    [SerializeField] private GameObject UIPanel;
    [SerializeField] private float      exitDelay;


    private void OnTriggerEnter(Collider other)
    {
        if (events != null) 
        {
            StartCoroutine(Exit());       
        }
    }

    IEnumerator Exit()
    {
        UIPanel.SetActive(true);
        yield return new WaitForSeconds(exitDelay);
        events.Invoke();
    }
}
