using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextController : MonoBehaviour
{
    public GameObject character;
    public Text textBox;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        switch (character.GetComponent<Character>().lives)
        {
            case 3: 
                textBox.text = "  ";
                break;
            case 2:
                textBox.text = " ";
                break;
            case 1:
                textBox.text = "";
                break;
            case 0:
                textBox.text = "";
                break;
            default:
                textBox.text = "  ";
                break;
        }
    }
}
