using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.UIElements.UxmlAttributeDescription;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public Slider playerSlider;
    // Start is called before the first frame update
    void Start()
    {
            
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position = new Vector3(Mathf.Lerp(-6.89f, 6.89f, playerSlider.value), transform.position.y, transform.position.z);   
    }
}
