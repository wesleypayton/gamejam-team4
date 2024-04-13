using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float Health, MaxHealth;

    [SerializeField]
    
    private HealthBarUI healthBar;
    // Start is called before the first frame update
    void Start()
    {
        healthBar.SetMaxHealth(MaxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("m")) {
            SetHealth(-2.5f);
        }

        if (Input.GetKeyDown("n")) {
            SetHealth(2.5f);
        }
        
    }

    public void SetHealth(float healthChange) {
        Health += healthChange;
        Health = Mathf.Clamp(Health, 0, MaxHealth);
        healthBar.SetHealth(Health);
    }
    
}
