using UnityEngine;

public class EnemyView : MonoBehaviour
{
    public Animator bodyAnimator;      //Animates position of object
    public Animator spriteAnimator;    //Animates sprite of object

    public enum AnimState { Idle, Attacking, Healing, Tactic, Damaged };

    private void Awake()
    {
        bodyAnimator = GetComponent<Animator>();
        //No sprite animations yet for enemies
    }

    public void ChangeAnimState(string animName)
    {
        bodyAnimator.Play(animName);
        /*
        switch (animState)
        {
            case AnimState.Attacking:
                bodyAnimator.Play("Enemy_Attack1");
                break;
            case AnimState.Damaged:
                bodyAnimator.Play("Enemy_Damage1");
                break;
            default:
                bodyAnimator.Play("Enemy_Idle");
                break;
        }
        */
    }

    public void PlaySound(AudioClip clip)
    {
        SoundEffectsController.instance.PlaySound(clip.name);
    }
}
