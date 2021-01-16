﻿using UnityEngine;


public class ZombieDeadSMB : StateMachineBehaviour
{
    [SerializeField] private int _index;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);

        animator.GetComponent<ZombieController>().ActivateDeadEffect(_index);
    }
}