using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoolResetAtEnd : StateMachineBehaviour {

    [SerializeField] private string booleanVariableName;

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.SetBool(booleanVariableName, false);
    }
}
