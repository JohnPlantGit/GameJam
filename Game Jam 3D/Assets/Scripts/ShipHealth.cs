using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipHealth : MonoBehaviour
{
    public int m_maxHealth = 100;
    public Team m_team;

    private int m_health;

    public int Health
    {
        get { return m_health; }
        set
        {
            m_health = value;

            if (m_health < 0)
                m_health = 0;
            if (m_health > m_maxHealth)
                m_health = m_maxHealth;
        }
    }

	// Use this for initialization
	void Start ()
    {
        m_health = m_maxHealth;
	}

    public void TakeDamage(int amount)
    {
        m_health -= amount;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet")
        {
            Bullet bullet = other.GetComponent<Bullet>();
            if (bullet)
            {
                if (bullet.m_team != m_team)
                    TakeDamage(bullet.m_damage);
            }
        }
    }
}
