﻿using UnityEngine;
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

    public bool flushStart()
    {
        stagingcanvas.SetActive(true);
        var color = fadewhite.color;
        color.a += 0.02f;
        if (color.a <= 1.0f)
        {
            fadewhite.color = color;
            return false;
        }
        color.a = 1.0f;
        fadewhite.color = color;
        return true;
    }
    public bool flushEnd()
    {
        var color = fadewhite.color;
        color.a -= 0.02f;
        if (color.a >= 0.0f)
        {
            fadewhite.color = color;
            return false;
        }
        color.a = 0.0f;
        fadewhite.color = color;
        stagingcanvas.SetActive(false);
        return true;
    }

    public bool fadeOutBlack()
    {
        stagingcanvas.SetActive(true);
        var color = fadeblack.color;
        color.a += 0.02f;
        if (color.a <= 1)
        {
            fadeblack.color = color;
            return false;
        }
        color.a = 1.0f;
        return true;
    }

    public bool fadeInBlack()
    {
        var color = fadeblack.color;
        color.a -= 0.01f;
        if (color.a >= 0)
        {
            fadeblack.color = color;
            return false;
        }
        color.a = 0;
        stagingcanvas.SetActive(false);
        return true;
    }

    public void blackOutStart()
    {
        fadeblack.color = new Color(0, 0, 0, 255);
        stagingcanvas.SetActive(true);
    }
    public void blackOutEnd()
    {
        fadeblack.color = new Color(0, 0, 0, 0);
        stagingcanvas.SetActive(false);
    }


}
