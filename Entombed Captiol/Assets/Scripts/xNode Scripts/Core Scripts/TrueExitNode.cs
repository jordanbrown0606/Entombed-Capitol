using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrueExitNode : CoreNodeBase
{
    [Input] public int entry;
    public override string GetDialogueType { get { return "TrueExit"; } }
}
