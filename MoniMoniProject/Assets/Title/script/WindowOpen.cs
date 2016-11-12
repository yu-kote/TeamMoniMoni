using UnityEngine;
using System.Collections;

public class WindowOpen : MonoBehaviour {
    private Vector3 size_window;

    private int local_time;
    private bool display_window;
    private float changesize_window;

    // Use this for initialization
    void Start()
    {
        local_time = 55;
        display_window = false;
        changesize_window = 0.0f;
        size_window = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {
        local_time++;
        transform.localScale = size_window * changesize_window;

        if (local_time == 1 && display_window == false)
        {
            display_window = true;
            local_time = 10;
        }
        if (local_time == 3 && display_window == true)
        {
            display_window = false;
            local_time = 10;
        }

        if (display_window == true)
        {
            if (changesize_window < 1.00f) changesize_window += 0.02f;
            if (changesize_window >= 1.00f) changesize_window = 1.000f;
        }
        if (display_window == false)
        {
            if (changesize_window > 0.00f) changesize_window -= 0.02f;
            if (changesize_window <= 0.00f) changesize_window = 0.000f;
        }

    }
    public void OnClick()
    {
        if (local_time >= 55) local_time = 0;
    }
}
