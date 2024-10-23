using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.loseScreen = this.gameObject;
        this.gameObject.SetActive(false);
    }
}
