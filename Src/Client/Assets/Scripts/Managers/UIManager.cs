﻿using Assets.Scripts.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts.Managers
{
    class UIManager:Singleton<UIManager>
    {
        class UIElment
        {
           public string Resouce;
           public bool  Cache;
           public GameObject Instance;
        }
        /// <summary>
        /// UI注册集合
        /// </summary>
        Dictionary<Type, UIElment> UIResouces = new Dictionary<Type, UIElment>();
        public UIManager()
        {
            UIResouces.Add(typeof(UITest), new UIElment() { Resouce = "UI/UITest", Cache = true, });
            UIResouces.Add(typeof(UIBag), new UIElment() { Resouce = "UI/UIBag", Cache = false, });
            UIResouces.Add(typeof(UIShop), new UIElment() { Resouce = "UI/UIShop", Cache = false, });
            UIResouces.Add(typeof(UICharEquip) ,new UIElment() { Resouce = "UI/UICharEquip", Cache = false, });
            UIResouces.Add(typeof(UIQuestSystem), new UIElment() { Resouce = "UI/UIQuestSystem", Cache = false, });
            UIResouces.Add(typeof(UIQuestDialog), new UIElment() { Resouce = "UI/UIQuestDialog", Cache = false, });
            UIResouces.Add(typeof(UIFriends), new UIElment() { Resouce = "UI/UIFriends", Cache = false, });
            UIResouces.Add(typeof(UIGuildPopNoGuild), new UIElment() { Resouce = "UI/UIGuildPopNoGuild", Cache = false, });
            UIResouces.Add(typeof(UIGuildPopCreate), new UIElment() { Resouce = "UI/UIGuildPopCreate", Cache = false, });
            UIResouces.Add(typeof(UIGuildList), new UIElment() { Resouce = "UI/UIGuildList", Cache = false, });
            UIResouces.Add(typeof(UIGuild), new UIElment() { Resouce = "UI/UIGuild", Cache = false, });
            UIResouces.Add(typeof(UIGuildApplyList), new UIElment() { Resouce = "UI/UIGuildApplyList", Cache = false, });
            UIResouces.Add(typeof(UIRide), new UIElment() { Resouce = "UI/UIRide", Cache = false, });
            //UIResouces.Add(typeof(UITeam), new UIElment() { Resouce = "UI/UITeam", Cache = false, });
        }
        ~UIManager()
        {

        }


        public T Show<T>()
        {
            Type type = typeof(T);
            if (UIResouces.ContainsKey(type))
            {
                UIElment info = UIResouces[type];
                if (info.Instance==null)
                {
                    UnityEngine.Object prefab = Resources.Load(info.Resouce);
                    if (prefab==null)
                    {
                        return default(T);//返回 T 的默认值 
                    }
                    info.Instance =(GameObject) GameObject.Instantiate(prefab);
                }
                else
                {
                    info.Instance.SetActive(true);
                }
                return info.Instance.GetComponent<T>();
            }
            return default(T);
        }

        public void Close(Type type)
        {
            if (UIResouces.ContainsKey(type))
            {
                UIElment info = UIResouces[type];
                if (info.Cache)
                {
                    info.Instance.SetActive(false);
                }
                else
                {
                    GameObject.Destroy(info.Instance);
                    info.Instance = null;
                }
            }
        }
    }
}
