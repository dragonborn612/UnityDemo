﻿using SkillBridge.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Gameobject
{
    public class GameObjectTool
    {
        /// <summary>
        /// 将服务器传输过来的坐标、Int坐标等各种坐标转化成unity世界坐标
        /// </summary>
        /// <param name="vector"></param>
        /// <returns></returns>
        public static Vector3 LogicToWorld(NVector3 vector)
        {
            return new Vector3(vector.X /100f, vector.Z / 100f, vector.Y /100f);
        }
        public static Vector3 LogicToWorld(Vector3Int vector)
        {
            return new Vector3(vector.x / 100f, vector.z / 100f, vector.y / 100f);
        }
        public static float LogicToWorld(int val)
        {
            return val / 100f;
        }
        /// <summary>
        /// 世界转逻辑
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static int WorldToLogic(float val)
        {
            return Mathf.RoundToInt(val * 100f);
        }
        public static NVector3 WorldToLogicN(Vector3 vector)
        {
            return new NVector3()
            {
                X = Mathf.RoundToInt(vector.x * 100),
                Y = Mathf.RoundToInt(vector.z * 100),
                Z = Mathf.RoundToInt(vector.y * 100)
            };
        }
        public static Vector3Int WorldToLogic(Vector3 vector)
        {
            return new Vector3Int()
            {
                x = Mathf.RoundToInt(vector.x * 100),
                y = Mathf.RoundToInt(vector.z * 100),
                z = Mathf.RoundToInt(vector.y * 100)
            };
        }
        public static bool EntityUpdata(NEntity entity,Vector3 position,Quaternion rotation,float speed)
        {
            NVector3 pos = WorldToLogicN(position);
            NVector3 dir = WorldToLogicN(rotation.eulerAngles);
            int sped = Mathf.RoundToInt(speed);
            bool updata = false;
            if (!entity.Position.Equal(pos))//是否一样
            {
                entity.Position = pos;
                updata = true;
            }
            if (!entity.Direction.Equal(dir))
            {
                entity.Direction = dir;
                updata = true;
            }
            if (entity.Speed!=sped)
            {
                entity.Speed = sped;
                updata = true;
            }
            return updata;
        }
    }
}
