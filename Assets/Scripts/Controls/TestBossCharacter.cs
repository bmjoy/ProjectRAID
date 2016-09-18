﻿using System.Collections.Generic;

public class TestBossCharacter : BaseMeeleCharacter
{
    /// <summary>
    /// Initializes the balancing parameter.
    /// </summary>
    public override void InitializeBalancingParameter()
    {
        base.InitializeBalancingParameter();

        m_CharacterId = "TestBossCharacter";

        m_InteractionTarget = InteractionTarget.Boss;
        m_PossibleInteractionTargets = new HashSet<InteractionTarget>
        {
            InteractionTarget.Mage,
            InteractionTarget.Rogue,
            InteractionTarget.Tank,
            InteractionTarget.Heal
        };

        m_MovementSpeed = BaseBalancing.m_EnemyMovementSpeed;

        m_AutoInteractionCd = BaseBalancing.m_TestBossAutoAttackCd;
        m_AutoInteractionMaxRange = BaseBalancing.m_TestBossAutoAttackMaxRange;

        m_StatManagement.Initialize(BaseBalancing.m_TestBossBaseMaxHealth);
    }

    /// <summary>
    /// Called when an automatic interaction was triggered.
    /// </summary>
    /// <param name="targetToInteractWith">The target to interact with.</param>
    protected override void OnAutoInteractionTriggered(BaseCharacter targetToInteractWith)
    {
        base.OnAutoInteractionTriggered(targetToInteractWith);

        targetToInteractWith.m_StatManagement.ChangeHealth(-BaseBalancing.m_TestBossAutoAttackDamage);
    }
}