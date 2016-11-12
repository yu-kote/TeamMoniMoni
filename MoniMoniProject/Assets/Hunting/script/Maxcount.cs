using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Maxcount : MonoBehaviour
{

    Text text;

    touch touches;

	// Use this for initialization
	void Start ()
    {
        text = GetComponent<Text>();
        touches = GetComponent<touch>();
        text.text = touches.Maxcount.ToString();
    }
	
	// Update is called once per frame
	void Update ()
    {
        text.text = touches.Maxcount.ToString(); 
	}
}
