using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace AI.FSM
{
    public class DefaultState : AI.FSM.FSMState
    {
        protected override void init()
        {
            this.StateID = AI.FSM.FSMStateID.Default;
        }

    }
}
