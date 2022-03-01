using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UISetText : MonoBehaviour
{
    UnityEngine.UI.Text TextObject;
    public string myText = "0000#";
    // Start is called before the first frame update
    void Start()
    {
        TextObject = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
