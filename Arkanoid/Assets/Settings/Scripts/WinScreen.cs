using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScreen : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameManager.instance.winScreen = this.gameObject;
        this.gameObject.SetActive(false);
    }

}
