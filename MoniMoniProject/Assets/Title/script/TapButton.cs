using UnityEngine;
using System.Collections;

public class TapButton : MonoBehaviour {
   private bool clicked;
    private float cahngeAlpha;

    // Use this for initialization
    void Start () {
        
        clicked = false;
        cahngeAlpha = 1.0f;

    }

    // Update is called once per frame
    void Update () {
         this.GetComponent<CanvasGroup>().alpha = cahngeAlpha;
          
        if (clicked == true)
        {
             if (cahngeAlpha > 0.00f)
            {
                cahngeAlpha -= 0.02f;
            }
            if (cahngeAlpha <= 0.00f)
            {
                cahngeAlpha = 0.00f;
                clicked = false;
                gameObject.SetActive(false);
            }
        }
    }
    public void OnClick()
    {
        clicked = true;
    }
   
}
