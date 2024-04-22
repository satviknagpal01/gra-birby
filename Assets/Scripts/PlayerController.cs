using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float m_speed = 5.0f;
    [SerializeField] private float m_jumpForce = 5.0f;
    
    [SerializeField] private float m_jetPackForce = 10f;
    [SerializeField] private float m_jetPackFuel = 100f;
    [SerializeField] private float m_jetPackFuelBurnRate = 10f;
    [SerializeField] private float m_jetPackFuelRegenRate = 2f;

    [SerializeField] private float m_gravity = 9.81f;

    [SerializeField] private float m_health = 100f;
    [SerializeField] private float m_maxHealth = 100f;
    [SerializeField] private float m_JetPackHealth = 100f;
    [SerializeField] private float m_maxJetPackHealth = 100f;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
}
