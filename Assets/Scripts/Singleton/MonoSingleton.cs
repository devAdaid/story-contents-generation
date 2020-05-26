using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    public static T Instance
    {
        get
        {
            if (_instance == null)
            {
                // 씬에서 미리 만들어놓은 인스턴스가 있는지 탐색
                _instance = FindObjectOfType<T>();

                if (_instance == null)
                {
                    // 미리 세팅해놓은 프리팹이 있다면 해당 프리팹으로 인스턴스 생성
                    T prefab = Resources.Load<T>("Prefabs/Singleton/" + typeof(T).ToString());
                    //Debug.Log(typeof(T).ToString());
                    if (prefab != null)
                    {
                        //Debug.Log("Prefab Singleton Created");
                        _instance = Instantiate(prefab) as T;
                        _instance.name = typeof(T).ToString();
                    }
                    // 아니라면 일반 GameObject에 컴포넌트를 부착하여 생성
                    else
                    {
                        //Debug.Log("New Singleton Created");
                        _instance = new GameObject(typeof(T).ToString(), typeof(T)).GetComponent<T>();
                    }
                }
            }

            return _instance;
        }
    }

    protected static T _instance = null;

    public void Echo() { }

    protected virtual void OnApplicationQuit()
    {
        _instance = null;
    }
}