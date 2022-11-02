using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusEvent : EventArgs
{ 
    public object obj { get; set; }
    public StatusType status { get; set; }
}
