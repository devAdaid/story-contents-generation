using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class ProppActionFactory
{
    public static ProppActionFactory Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new ProppActionFactory();
            }
            return _instance;
        }
    }
    private static ProppActionFactory _instance = null;
    ProppStory story = null;
    private Dictionary<string, ConstructorInfo> _constructorInfos = new Dictionary<string, ConstructorInfo>();

    public ProppActionFactory()
    {
        Initialize();
    }

    public void Initialize()
    {
        Assembly assembly = Assembly.GetExecutingAssembly();
        Type[] types = assembly.GetTypes();

        // Action 하위 클래스 모두 찾음
        List<Type> actionTypes = new List<Type>();
        foreach (Type type in types)
        {
            if (type.IsSubclassOf(typeof(ProppAction)))
                actionTypes.Add(type);
        }

        // Action 하위 클래스들의 command와 생성자 연결
        foreach (Type actionType in actionTypes)
        {
            FieldInfo idField = actionType.GetField("key");
            string command = idField.GetRawConstantValue() as string;
            ConstructorInfo constructorInfo = actionType.GetConstructor(Type.EmptyTypes);

            _constructorInfos.Add(command, constructorInfo);
        }
    }

    public void SetStory(ProppStory s)
    {
        story = s;
    }

    public ProppAction CreateAction(string command)
    {
        ConstructorInfo constructorInfo;
        if (!_constructorInfos.TryGetValue(command, out constructorInfo))
        {
            return null;
        }

        return constructorInfo.Invoke(null) as ProppAction;
    }

    public ProppAction CreateAction(ProppActionData data)
    {
        ConstructorInfo constructorInfo;
        if (data == null) return null;

        if (!_constructorInfos.TryGetValue(data.actionName, out constructorInfo))
        {
            Debug.Log(data.actionName);
            return null;
        }

        ProppAction result = (constructorInfo.Invoke(null) as ProppAction);
        result.SetWithArgs(story, data.arguments);
        return result;
    }
}
