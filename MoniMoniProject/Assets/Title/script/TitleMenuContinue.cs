using UnityEngine;
using System.Collections;

public class TitleMenuContinue : MonoBehaviour {

    private Vector3 size_continue;
    private int local_time;
    private bool display_continue;
    private float changesize_continue;
   
    // Use this for initialization
    void Start()
    {
        local_time = 55;
        display_continue = false;
        changesize_continue = 0.0f;
        size_continue = transform.localScale;
     }

    // Update is called once per frame
    void Update()
    {
        transform.localScale = new Vector3(size_continue.x * changesize_continue, (size_continue.y + 5) * changesize_continue - 5, size_continue.z * changesize_continue);


        local_time++;
        
        if (local_time == 1 && display_continue == false)
        {
            display_continue = true;
            local_time = 10;
        }
        if (local_time == 3 && display_continue == true)
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
        if (local_time >= 55) local_time = 0;
    }
}
