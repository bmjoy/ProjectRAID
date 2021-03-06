﻿using UnityEngine;

public class BaseCasterCharacter : BaseRangeCharacter
{
    public class CurrentCastingInfo
    {
        public bool m_IsCasting;
        public BaseCharacter m_CastTarget;

        public float m_CastTime;
        public float m_CastStartTime;
    }

    public CurrentCastingInfo CurrentCasting { get; private set; }

    private Coroutine m_currentCastingCoroutine;

    protected float m_AutoInteractionAnimationSpeed;

    /// <summary>
    /// Called when the automatic interaction happened.
    /// </summary>
    /// <param name="targetToInteractWith"></param>
    protected override void OnAutoInteractionTriggered(BaseCharacter targetToInteractWith)
    {
        if (CurrentCasting != null && CurrentCasting.m_IsCasting)
        {
            Debug.LogError("OnAutoInteractionTriggered called, while character is still casting!!");

            return;
        }

        if (m_animator != null)
        {
            m_animator.SetBool("Casting", true);
            m_animator.SetFloat("CastingSpeed", m_AutoInteractionAnimationSpeed);
        }

        CurrentCasting = new CurrentCastingInfo
        {
            m_IsCasting = true,
            m_CastStartTime = Time.time,

            m_CastTime = m_AutoInteractionCd - 0.1f,
            m_CastTarget = targetToInteractWith
        };

        m_currentCastingCoroutine = Root.Instance.CoroutineHelper.CallDelayed(this, CurrentCasting.m_CastTime, () =>
        {
            StopCasting();

            if (m_animator != null)
            {
                m_animator.SetTrigger("Fire");
            }

            base.OnAutoInteractionTriggered(targetToInteractWith);
        });
    }

    /// <summary>
    /// Stops the interaction.
    /// </summary>
    public override void StopInteraction()
    {
        base.StopInteraction();

        StopCasting();

        if (m_animator != null)
        {
            m_animator.SetBool("Casting", false);
        }

        if (m_animator != null)
        {
            m_animator.SetBool("Fire", false);
        }
    }

    /// <summary>
    /// Stops the current cast.
    /// </summary>
    private void StopCasting()
    {
        if (m_currentCastingCoroutine != null)
        {
            StopCoroutine(m_currentCastingCoroutine);
        }

        if (CurrentCasting != null && CurrentCasting.m_IsCasting)
        {
            CurrentCasting.m_IsCasting = false;
        }
    }
}
