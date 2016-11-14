using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StagingController : MonoBehaviour
{
    [SerializeField]
    GameObject stagingcanvas;
    [SerializeField]
    Image fadeblack;

    [SerializeField]
    Image fadewhite;

    int fadecount;
    public int fadetime;
    public float fadespeed;

    void Awake()
    {
        fadecount = 0;
        fadetime = 150;
        stagingcanvas.SetActive(true);
    }


    void Update()
    {
        if (fadecount < fadetime)
        {
            fadecount++;
            var color = fadeblack.color;
            color.a -= fadespeed;
            fadeblack.color = color;
        }
        else if (fadecount == fadetime)
        {
            stagingcanvas.SetActive(false);
            fadecount++;
        }
    }

    int flushcount = 0;
    public bool flushStart()
    {
        if (flushcount < 30)
        {
            stagingcanvas.SetActive(true);
            var color = fadewhite.color;
            color.a += 0.1f;
            fadewhite.color = color;
            flushcount++;
            return false;
        }
        flushcount = 0;
        return true;
    }
    public bool flushEnd()
    {
        if (flushcount < 30)
        {
            var color = fadewhite.color;
            color.a -= 0.1f;
            fadewhite.color = color;
            flushcount++;
            return false;
        }
        flushcount = 0;
        stagingcanvas.SetActive(false);
        return true;
    }

}
