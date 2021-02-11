using UnityEngine;


public class ZombieDeadSMB : StateMachineBehaviour
{
    [SerializeField] private int _index = 0;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);

        animator.GetComponentInChildren<ZombieHealth>().ActivateDeadEffect(_index);
    }
}