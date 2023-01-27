using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    public GameObject Player;
    public Slider slider;
    public Gradient gradient;
    public Image fill;
    public void SetMaxHealth ()
    {
        slider.maxValue = this.Player.GetComponent<PlayerCombat>().HP;
        slider.value = this.Player.GetComponent<PlayerCombat>().HitPoints;

        fill.color = gradient.Evaluate(1f);
    }
    private void Update() {
        slider.value = this.Player.GetComponent<PlayerCombat>().HitPoints;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    public void SetHealth()
    {
        
    }
}
