﻿//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public abstract class SingletonPersistant<T> : MonoBehaviour where T : SingletonPersistant<T>
//{
//    private static T instance;
//    public static T Instance
//    {
//        get
//        {
//            if (instance == null)
//            {
//                instance = FindObjectOfType<T>();
//                if (instance == null)
//                {
//                    GameObject obj = new GameObject();
//                    obj.name = typeof(T).Name;
//                    instance = obj.AddComponent<T>();
//                }
//            }
//            return instance;
//        }
//    }
//    public virtual void Awake()
//    {
//        if (instance == null)
//        {
//            instance = this as T;
//            //DontDestroyOnLoad(this.gameObject);
//        }
//        else
//        {
//            Destroy(gameObject);
//        }
//    }
//}