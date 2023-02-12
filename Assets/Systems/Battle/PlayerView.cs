using UnityEngine;

public class PlayerView : MonoBehaviour
{
    public Animator bodyAnimator;      //Animates position of object
    public Animator spriteAnimator;    //Animates sprite of object

    public enum AnimState {Idle, Attacking, Healing, Tactic, Damaged};

    private void Awake()
    {
        bodyAnimator = GetComponent<Animator>();
        spriteAnimator = transform.GetChild(0).GetComponent<Animator>();
    }

    public void ChangeAnimState(AnimState animState)
    { 
        switch(animState)
        {
            case AnimState.Attacking:
                bodyAnimator.Play("Player_Attack1");
                break;
            case AnimState.Damaged:
                bodyAnimator.Play("Player_Damage1");
                break;
            default:
                bodyAnimator.Play("Player_Idle");
                break;
        }
    }

    public void ChangeAnimState(string animName)
    {
        bodyAnimator.Play(animName);
    }
}
