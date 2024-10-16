﻿using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using XNode;
#if UNITY_EDITOR
using XNodeEditor;
#endif

[CreateAssetMenu]
public class DialogueGraph : NodeGraph 
{
	public CoreNodeBase current;
}

#if UNITY_EDITOR
[CustomNodeGraphEditor(typeof(DialogueGraph))]
public class DialogueGraphEditor : NodeGraphEditor
{
    public override string GetNodeMenuName(Type type)
    {
        if (type.IsSubclassOf(typeof(DialogueNodeBase)) || type.IsSubclassOf(typeof(CoreNodeBase)))
        {
            return base.GetNodeMenuName(type);
        }

        return null;
    }


}
#endif