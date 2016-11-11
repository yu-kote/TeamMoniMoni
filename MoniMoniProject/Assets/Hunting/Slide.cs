using UnityEngine;
using System.Collections;

public class Slide : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector2 tapPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);

    }
}
