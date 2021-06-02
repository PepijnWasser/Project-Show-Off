using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class CinematicManager : MonoBehaviour
{
    public RawImage display;
    public RenderTexture goodEndingTexture;
    public RenderTexture badEndingTexture;

    public VideoPlayer badVideoPlayer;
    public VideoPlayer goodVideoPlayer;

    VideoPlayer videoPlayerUsing;

    public bool badEndingBool;
    public bool finished;


    private void Start()
    {
        RenderTexture textureToRender;
        if (badEndingBool)
        {
            badVideoPlayer.frame = 0;
            videoPlayerUsing = badVideoPlayer;
            goodVideoPlayer.Pause();
            textureToRender = badEndingTexture;
        }
        else
        {
            goodVideoPlayer.frame = 0;
            videoPlayerUsing = goodVideoPlayer;
            badVideoPlayer.Pause();
            textureToRender = goodEndingTexture;
        }
        textureToRender.Release();
        display.texture = textureToRender;
    }

    private void Update()
    {
        if(Convert.ToInt32(videoPlayerUsing.frame) >= Convert.ToInt32(videoPlayerUsing.frameCount - 1))
        {
            finished = true;
        }
    }
}
