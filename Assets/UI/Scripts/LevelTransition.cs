using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.Runtime.CompilerServices;

public class LevelTransition : MonoBehaviour
{
    Image screenTransition;
    TextMeshProUGUI tmpro;

    public delegate void EndTransition();

    private void Awake()
    {
        screenTransition = GetComponentInChildren<Image>();
        tmpro = GetComponentInChildren<TextMeshProUGUI>();
    }
    
    public void StartTransition(int nextLevel, Func<int, bool> method)
    {
       // Debug.Log("Start Transition");
        StartCoroutine(Transition(nextLevel, method));
    }

    IEnumerator Transition(int nextLevel, Func<int, bool> method)
    {
        //Debug.Log("Transition Running");
        Time.timeScale = 1.0f;
        float t = 0f;
        while (t < 1f)
        {
            t += Time.deltaTime;
            screenTransition.fillAmount = t;
            Debug.Log(t);
            yield return null;
        }
        tmpro.text = $"Level {nextLevel}";
        yield return new WaitForSeconds(0.5f);
        //tmpro.text = "";
        method(nextLevel);

        yield return new WaitForSeconds(0.5f);
        while (t > 0f)
        {
            t -= Time.deltaTime;
            screenTransition.fillAmount = t;

            yield return null;
        }
        screenTransition.fillAmount = 0;
        tmpro.text = "";
    }
}
