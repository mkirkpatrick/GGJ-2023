using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour
{
    private PlayerController playerController;

    public Animator bodyAnimator;      //Animates position of object
    public Animator spriteAnimator;    //Animates sprite of object

    public enum AnimState {Idle, Attacking, Healing, Tactic, Damaged, Huma, Mani, Nihtee, Dead};

    private void Awake()
    {
        playerController = GameController.instance.playerController;
    }

    public void ChangeAnimState(string animName)
    { 
        if(animName == "Idle")
        {
            SetIdleAnimation(playerController.player.currentClan.clanName);
        }
        else
        {
            bodyAnimator.Play(animName);
        }
        /*
        switch(animState)
        {
            case AnimState.Idle:
                break;
            case AnimState.Attacking:
                bodyAnimator.Play("Player_Attack1");
                break;
            case AnimState.Damaged:
                bodyAnimator.Play("Player_Damage1");
                break;
            case AnimState.Healing:
                bodyAnimator.Play("Player_Heal1");
                break;
            case AnimState.Tactic:
                bodyAnimator.Play("Player_Tactic1");
                break;
            case AnimState.Huma:
                bodyAnimator.Play("Player_HumaAttack");
                break;
            case AnimState.Mani:
                bodyAnimator.Play("Player_ManiAttack");
                break;
            case
        }
        */
    }

    public void PlaySound(AudioClip clip)
    {
        SoundEffectsController.instance.PlaySound(clip.name);
    }

    private void SetIdleAnimation(string _clanName) {

        switch (_clanName) {
            case "Huma":
                spriteAnimator.Play("Base Layer.Huma_Idle");
                break;
            case "Mani":
                spriteAnimator.Play("Base Layer.Mani_Idle");
                break;
            case "Nih-Tee":
                spriteAnimator.Play("Base Layer.Nihtee_Idle");
                break;
        }
    } 
}
