using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// broad the message to mods
/// </summary>

public delegate void CallBack();
public delegate void CallBack<T>(T arg);
public delegate void CallBack<T, X>(T arg1, X arg2);
public delegate void CallBack<T, X,Y>(T arg1, X arg2, Y arg3);

public class EventCenter
{
    private static Dictionary<EventType, Delegate> m_eventTable = new Dictionary<EventType, Delegate>();

    private static void OnListenerAdding(EventType eventType,Delegate callBack)
    {
        if (!m_eventTable.ContainsKey(eventType))
        {
            m_eventTable.Add(eventType, null);
        }

        Delegate d = m_eventTable[eventType];

        if (d != null && d.GetType() != callBack.GetType())
        {
            throw new Exception(string.Format("try to add{0} different kind of delegate,now delegate is {1}, aim delegate is{2} ", eventType, d.GetType(), callBack.GetType()));
        }
    }

    // no parameters
    public static void AddListener(EventType eventType,CallBack callBack)
    {
        OnListenerAdding(eventType, callBack);
        m_eventTable[eventType] =(CallBack) m_eventTable[eventType] + callBack;

    }

    // one parameters
    public static void AddListener<T>(EventType eventType, CallBack<T> callBack)
    {
        OnListenerAdding(eventType, callBack);
        m_eventTable[eventType] = (CallBack<T>)m_eventTable[eventType] + callBack;

    }
    // two
    public static void AddListener<T,X>(EventType eventType, CallBack<T,X> callBack)
    {
        OnListenerAdding(eventType, callBack);
        m_eventTable[eventType] = (CallBack<T,X>)m_eventTable[eventType] + callBack;

    }

    private static void OnListenerRemoving(EventType eventType,Delegate callBack)
    {
        if (m_eventTable.ContainsKey(eventType))
        {
            Delegate d = m_eventTable[eventType];
            if (d == null)
            {
                throw new Exception(string.Format("error: event{0} has no matched delegate", eventType));
            }
            else if (d.GetType() != callBack.GetType())
            {
                throw new Exception(string.Format("remove error: try to remove{0} different delegate, now delegate id {1}, aim delegate is {2}", eventType, d.GetType(), callBack.GetType()));
            }
        }
        else
        {
            throw new Exception(string.Format("error: event{0} does not excite", eventType));
        }
    }

    private static void OnListenerRemoved(EventType eventType)
    {
        if (m_eventTable[eventType] == null)
        {
            m_eventTable.Remove(eventType);
        }
    }
    // no param 
    public static void RemoveListener(EventType eventType, CallBack callBack)
    {
        OnListenerRemoving(eventType,callBack);
        m_eventTable[eventType] = (CallBack)m_eventTable[eventType] - callBack;
        OnListenerRemoved(eventType);
    }
    //one param
    public static void RemoveListener<T>(EventType eventType, CallBack<T> callBack)
    {
        OnListenerRemoving(eventType, callBack);
        m_eventTable[eventType] = (CallBack<T>)m_eventTable[eventType] - callBack;
        OnListenerRemoved(eventType);
    }
    //two param
    public static void RemoveListener<T,X>(EventType eventType, CallBack<T,X> callBack)
    {
        OnListenerRemoving(eventType, callBack);
        m_eventTable[eventType] = (CallBack<T,X>)m_eventTable[eventType] - callBack;
        OnListenerRemoved(eventType);
    }

    //no parameters
    public static void Broadcast(EventType eventType)
    {
        Delegate d;
       if( m_eventTable.TryGetValue(eventType,out d))
       {
            CallBack callBack = d as CallBack;
            if (callBack != null)
            {
                callBack();
            }
            else
            {
                throw new Exception(string.Format("broadcast error: event {0} has different type", eventType));
            }
       }
    }
    // one param
    public static void Broadcast<T>(EventType eventType, T arg)
    {
        Delegate d;
        if (m_eventTable.TryGetValue(eventType, out d))
        {
            CallBack<T> callBack = d as CallBack<T>;
            if (callBack != null)
            {
                callBack(arg);
            }
            else
            {
                throw new Exception(string.Format("broadcast error: event {0} has different type", eventType));
            }
        }
    }
    // two param
    public static void Broadcast<T,X>(EventType eventType, T arg1, X arg2)
    {
        Delegate d;
        if (m_eventTable.TryGetValue(eventType, out d))
        {
            CallBack<T,X> callBack = d as CallBack<T,X>;
            if (callBack != null)
            {
                callBack(arg1,arg2);
            }
            else
            {
                throw new Exception(string.Format("broadcast error: event{0} has different type", eventType));
            }
        }
    }

}
