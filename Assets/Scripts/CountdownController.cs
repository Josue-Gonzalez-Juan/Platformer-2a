using System.Collections;
using System.Collections.Generic;
//using System.Diagnostics;
using System.Globalization;
using UnityEngine;
using UnityEngine.UI;

public class CountdownController : MonoBehaviour
{
    public int countdownTime;
    public Text countdownDisplay;

    IEnumerator CountdownToStart()
    {
        while(countdownTime >= 0)
        {
            countdownDisplay.text = "TIME\n  " + countdownTime.ToString();

            yield return new WaitForSeconds(1f);

            countdownTime--;
        }
        if (countdownTime < 0)
        {
            Debug.Log("Player Loses");
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CountdownToStart());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
