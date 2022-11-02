using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public delegate void EventDelegate(StatusType status, EventArgs e);

public class StatusEventManager : Singleton<StatusEventManager>
{
    public event EventDelegate SendEvent;
  

    public void DispatchEvent( object obj ,StatusType status)
    { 
        StatusEvent evt = new StatusEvent();
        evt.obj = obj;
        evt.status = status;
        if (null != SendEvent)
            SendEvent(status, evt);
    }

}
