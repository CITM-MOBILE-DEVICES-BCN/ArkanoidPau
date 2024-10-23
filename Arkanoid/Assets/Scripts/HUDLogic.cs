using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUDLogic : MonoBehaviour
{
    [SerializeField] TMP_Text scoreText;
    [SerializeField] TMP_Text healthText;
    [SerializeField] TMP_Text highScoreText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score:" + GameManager.instance.score.ToString();
        healthText.text = "Lives:" + GameManager.instance.lives.ToString();
        highScoreText.text = "HighScore:" + GameManager.instance.highScore.ToString();
    }
}
