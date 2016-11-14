using UnityEngine;
using System.Collections;

public class TitleMenuContinue : MonoBehaviour {
    private bool first_open;
    private int first_open_time;
    private Vector3 size_continue;
    private int local_time;
    private bool display_continue;
    private float changesize_continue;
   
    // Use this for initialization
    void Start()
    {
        first_open = false;

        local_time = 58;
        first_open_time = 0;
        display_continue = false;
        changesize_continue = 0.0f;
        size_continue = transform.localScale;
     }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(size_continue.x * changesize_continue, (size_continue.y + 5) * changesize_continue - 5, size_continue.z * changesize_continue);


        if(first_open==true) first_open_time++;
        local_time++;
        
        if (local_time == 2 && display_continue == false)
        {
            display_continue = true;
            local_time = 10;
        }
        if (local_time == 4 && display_continue == true)
        {
            display_continue = false;
            local_time = 10;
        }

        if (display_continue == true)
        {
            if (changesize_continue < 1.00f) changesize_continue += 0.02f;
            if (changesize_continue >= 1.00f) changesize_continue = 1.000f;
        }
        if (display_continue == false)
        {
            if (changesize_continue > 0.00f) changesize_continue -= 0.02f;
            if (changesize_continue <= 0.00f) changesize_continue = 0.000f;
        }

    }
    public void OnClick()
    {
        if (first_open_time >= 56 && local_time >= 60) local_time = 0;
    }
    public void OnClick_2()
    {
        first_open = true;
    }
}
