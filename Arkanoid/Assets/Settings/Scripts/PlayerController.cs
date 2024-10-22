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
    [SerializeField] Transform ball;

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
        if (ball.parent == null)
        {
            transform.position = new Vector3(ball.position.x, transform.position.y, transform.position.z);
            
        }
        
    }

    void ManualPlay()
    {
        if (GameManager.instance.isPaused == false) 
        transform.position = new Vector3(Mathf.Lerp(-6.89f, 6.89f, playerSlider.value), transform.position.y, transform.position.z);
    }
}
