﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public class EntryNode : CoreNodeBase 
{
    [Output(connectionType = ConnectionType.Override)] public bool exit;

    public override string GetDialogueType => throw new System.NotImplementedException();
}