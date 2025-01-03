using AI.FSM;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class index_up_shapeTrigger : AI.FSM.FSMTrigger
{
    public override bool HandleTrigger(FSMBase fsm)
    {
        //ÅĞ¶ÏÌõ¼şÂú²»Âú×ã
        var gesture_fsm = fsm as gesture_fsm;
        return true;
    }

    protected override void init()
    {
        this.TriggerID = FSMTriggerID.index_up_shape;
    }
}
