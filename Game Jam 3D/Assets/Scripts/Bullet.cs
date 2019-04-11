using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Team
{
    TeamOne,
    TeamTwo
};

public class Bullet : MonoBehaviour
{
    public int m_damage;
    public Team m_team;
    public float m_lifeTime = 20;

    private float m_timer;

	// Use this for initialization
	void Start ()
    {
        m_timer = m_lifeTime;
	}
	
	// Update is called once per frame
	void Update ()
    {
        m_timer -= Time.deltaTime;

        if (m_timer <= 0)
            Destroy(gameObject);
	}
}
