using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContinueButton : MonoBehaviour
{
    [SerializeField] Button button;
    void Start()
    {
        if (PlayerPrefs.GetInt("score") == 0)
        {
            button.interactable = false;
        }
    }

}
