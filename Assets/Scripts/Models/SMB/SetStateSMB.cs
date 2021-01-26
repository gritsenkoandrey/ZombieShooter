using UnityEngine;


public class SetStateSMB : StateMachineBehaviour
{
    [SerializeField] private int _numAnimRandom = 0;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        base.OnStateEnter(animator, stateInfo, layerIndex);

        int randState = Random.Range(0, _numAnimRandom);
        animator.SetInteger(NameManager.RANDOM_PARAMETER, randState);
    }
}