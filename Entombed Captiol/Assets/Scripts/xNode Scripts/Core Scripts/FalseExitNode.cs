using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FalseExitNode : CoreNodeBase
{
    [Input] public int entry;
    public override string GetDialogueType { get { return "FalseExit"; } }

}
