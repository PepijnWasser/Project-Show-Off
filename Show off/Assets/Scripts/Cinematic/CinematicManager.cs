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

    public int minScoreForGoodEnd;
    bool badEndingBool;

    public bool finished;


    private void Start()
    {
        RenderTexture textureToRender;

        //set ending based on performance
        PlayerInfo playerInfo = GameObject.FindObjectOfType<PlayerInfo>();
        if (playerInfo != null)
        {
            if(playerInfo.coralHealth >= minScoreForGoodEnd)
            {
                badEndingBool = false;
            }
            else
            {
                badEndingBool = true;
            }
        }
        else
        {
            Debug.LogError("noPlayerInfoFound", this);
        }

        //play video
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
        //check if video has ended
        if(Convert.ToInt32(videoPlayerUsing.frame) >= Convert.ToInt32(videoPlayerUsing.frameCount - 1))
        {
            finished = true;
        }
    }
}
