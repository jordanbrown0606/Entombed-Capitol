﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

public class ExitNode : CoreNodeBase
{
    [Input] public int entry;

    public override string GetDialogueType {  get { return "ExitNode";  } }
}