using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.UIElements.UxmlAttributeDescription;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Slider playerSlider;
    bool autoPlay = false;
    public Transform ball;
    [SerializeField] Transform leftWall;
    [SerializeField] Transform rightWall;

    private void Start()
    {
        
        Time.timeScale = 1;
        GameManager.instance.isPaused = false;
        if (GameManager.instance.autoPlay)
        {
            autoPlay = true;
        }
    }

    void Update()
    {
        if (autoPlay)
        {
            AutoPlay();
        }
        else
        {
            ManualPlay();
        }
      
    }

    void AutoPlay()
    {
        if (ball.GetComponent<Ball>().followPlayer == false)
        {
            transform.position = new Vector3(ball.position.x+.4f, transform.position.y, transform.position.z);
        }
        
    }

    void ManualPlay()
    {
        if (GameManager.instance.isPaused == false) 
        transform.position = new Vector3(Mathf.Lerp(leftWall.position.x, rightWall.position.x, playerSlider.value), transform.position.y, transform.position.z);
    }
}
