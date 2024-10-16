using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public abstract class CoreNodeBase : Node 
{
    public abstract string GetDialogueType { get; }
}