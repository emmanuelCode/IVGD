using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
	//This contain the amount of remaining health
    [SerializeField]
	float health = 100;
    [SerializeField]
    float poison;
    [SerializeField]
    float healthMax = 100;

    void Start()
    {
        health = Mathf.Clamp(health, 0, healthMax);
    }

	//This function is called by other object to give us damage
	void SetDamage(float damage)
	{
		//We decrese the amount of remaining health by damage value
		health -= damage;
		//If we are out of health
		if(health <= 0)
		{
			//We reset it to zero so we never have a negaive amount of health
			health = 0;
			//We then send message "OnNoMoreHealth" to all our siblings. Maybe another script will intercept that message
			BroadcastMessage("OnNoMoreHealth", SendMessageOptions.DontRequireReceiver);
		}
	}

	public void SetHealth(float pHealth)
	{
		//This function sets the amounth of remaining health
		health = pHealth;
	}

    public float GetHealthRatio()
    {
        if (healthMax > 0)
            return health / healthMax;
        else
            return -1;
    }

    public void Heal(float pHeallingAmount)
    {
        health = Mathf.Min(healthMax, health + pHeallingAmount);
    }

    public void SetPoison(float pPoison)
    {
        poison = pPoison;
    }

    void Update()
    {
        if (poison > 0)
            SetDamage(poison * Time.deltaTime);
    }
}
