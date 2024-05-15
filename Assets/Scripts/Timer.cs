using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public TMP_Text times;

    public float sec = 30f;

    void Update()
    {

        if (sec > 0)
        {
            sec -= Time.deltaTime;
            times.text = Mathf.RoundToInt(sec).ToString();
        }
    }
}
