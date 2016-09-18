﻿public class TestBossSkill1Projectile : BaseProjectile
{
    /// <summary>
    /// Initializes the parameters.
    /// </summary>
    public override void InitializeBalancingParameter()
    {
        base.InitializeBalancingParameter();

        m_MinHitDistance = BaseBalancing.m_TestBossSkill1CollisionDistance;
        m_ProjectileSpeed = BaseBalancing.m_TestBossSkill1ProjectileSpeed;
    }

    /// <summary>
    /// Called when a target has been hit.
    /// </summary>
    /// <param name="hitTargetCharacter">The hit target character.</param>
    protected override void OnTargetHit(BaseCharacter hitTargetCharacter)
    {
        base.OnTargetHit(hitTargetCharacter);

        Destroy(this.gameObject);
        hitTargetCharacter.m_StatManagement.ChangeHealth(-BaseBalancing.m_TestBossSkill1Damage);
    }
}
