using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI;

public class ScoreTextScript : MonoBehaviour
{
    public static float scoreValue;
    Text score;
    private float scoreTime;

    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<Text>();
        scoreValue = 0;
    }

    // Update is called once per frame
    void Update()
    {
        scoreTime = scoreValue + Mathf.Round(Time.timeSinceLevelLoad);
        score.text = scoreTime.ToString();
    }
}
