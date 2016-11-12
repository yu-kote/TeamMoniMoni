using UnityEngine;
using System.Collections;

public class TitleMenuNewgame : MonoBehaviour
{
    private Vector3 size;

    private int local_time;
    private bool display_newgame;
    private float changesize_newgame;
    
    // Use this for initialization
    void Start()
    {
        local_time = 55;
        display_newgame = false;
        changesize_newgame = 0.0f;
        size = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
            local_time++;
            transform.localScale = size * changesize_newgame;

        if (local_time == 1 && display_newgame == false)
        {
            display_newgame = true;
            local_time = 10;
        }
        if (local_time == 3 && display_newgame == true)
        {
            display_newgame = false;
            local_time = 10;
        }

        if (display_newgame == true)
        {
            if (changesize_newgame < 1.00f) changesize_newgame += 0.02f;
            if (changesize_newgame >= 1.00f) changesize_newgame = 1.000f;
        }
        if (display_newgame == false)
        {
            if (changesize_newgame > 0.00f) changesize_newgame -= 0.02f;
            if (changesize_newgame <= 0.00f) changesize_newgame = 0.000f;
        }


    }
    public void OnClick()
    {
        if (local_time >= 55) local_time = 0;
    }
}
