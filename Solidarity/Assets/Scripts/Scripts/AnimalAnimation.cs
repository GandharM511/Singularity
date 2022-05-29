using System;
using UnityEngine;

public class AnimalAnimation : CharacterAnimation
{

    protected override void SetAnimation(Acting acting)
    {
        if (IsDead)
        {
            return;
        }

        Acting = acting;
        switch (acting)
        {
            case Acting.Eat:
                Animator.Play("eat");
                break;
            case Acting.Eat2:
                Animator.Play("eat2");
                break;
            case Acting.Idle:
                Animator.Play("idle");
                break;
            case Acting.Idle2:
                Animator.Play("idle2");
                break;
            case Acting.Jump:
                Animator.Play("jump");
                break;
            case Acting.Jump2:
                Animator.Play("jump2");
                break;
            case Acting.Sleep:
                Animator.Play("sleep");
                break;
            case Acting.Sleep2:
                Animator.Play("sleep2");
                break;
            case Acting.Walk:
                Animator.Play("walk");
                break;
            case Acting.Walk2:
                Animator.Play("walk2");
                break;
        }
    }

}
