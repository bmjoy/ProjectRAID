﻿using UnityEngine;

public class BaseRangeCharacter : BaseCharacter
{
    [Header("BaseRange")]

    [SerializeField]
    protected Transform m_autoInteractionProjectileStartPosition;

    [SerializeField]
    protected GameObject m_autoInteractionProjectilePrefab;

    /// <summary>
    /// Called when the automatic interaction happened.
    /// </summary>
    /// <param name="targetToInteractWith"></param>
    protected override void OnAutoInteractionTriggered(BaseCharacter targetToInteractWith)
    {
        base.OnAutoInteractionTriggered(targetToInteractWith);

        GameObject projectileGameobject = Instantiate(m_autoInteractionProjectilePrefab, m_autoInteractionProjectileStartPosition.position, Quaternion.identity) as GameObject;

        if (projectileGameobject != null)
        {
            BaseProjectile projectileScript = projectileGameobject.GetComponent<BaseProjectile>();

            if (projectileScript != null)
            {
                projectileScript.InitializeBalancingParameter();
                projectileScript.FlyTowardsTarget(targetToInteractWith, this);
            }
        }
    }
}
