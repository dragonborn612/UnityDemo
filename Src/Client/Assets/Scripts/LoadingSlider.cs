﻿using Assets.Scripts.Managers;
using Assets.Scripts.Services;
using Services;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingSlider : MonoBehaviour
{
    public Slider loadingSlider;
    public Text loadingText;
    public  float loadTime=3f;
    private float timer;
    public GameObject loadingPanle;
    public GameObject rigiestPanle;
    public GameObject tipsPanle;
	// Use this for initialization
	void Start ()
    {
        log4net.Config.XmlConfigurator.ConfigureAndWatch(new System.IO.FileInfo("log4net.xml"));
        UnityLogger.Init();
        Common.Log.Init("Unity");
        Common.Log.Info("LoadingManager start");//引用Log.InfoFormat

        loadingPanle.gameObject.SetActive(true);
        rigiestPanle.gameObject.SetActive(false);
        tipsPanle.gameObject.SetActive(true);
        //loadingSlider = gameObject.GetComponent<Slider>();
        UserService.Instance.Init();
        MapService.Instance.Init();
        FriendService.Instance.Init();
        TeamManager.Instance.Init();
        TeamService.Instance.Init();
        //TestManager.Instance.Intit();
        ShopManager.Instance.Init();
        ItemService.Instance.Intit();
        StatusService.Instance.Init();
        QuestService.Instance.Init();
        GuildService.Instance.Init();

    }
	
	// Update is called once per frame
	void Update ()
    {

        Loading();
        Finishedloading();
    }
    void Loading()
    {
        timer += Time.deltaTime;
        if (timer>=loadTime)
        {
            timer = loadTime;
        }
        double percentage = timer / loadTime;
        loadingSlider.value =(float) percentage;
        loadingText.text = "已加载" + percentage.ToString("P") ;
    }
    void Finishedloading()
    {
        if (loadingSlider.value==1)
        {
            loadingSlider.gameObject.SetActive(false);
            rigiestPanle.gameObject.SetActive(true);
        }
    }
}
