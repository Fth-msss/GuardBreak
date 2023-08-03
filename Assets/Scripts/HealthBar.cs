using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{
    public Slider slider;

    public HealthTest playerhp;

    // Start is called before the first frame update
    void Start()
    {
        slider.minValue = 0;
        
        slider.maxValue = playerhp.Hp;

        playerhp.hpChange += OnHpChange;
    }

    void OnHpChange(float currenthp) 
    {
    slider.value = currenthp;
    }
   

    // Update is called once per frame
    void Update()
    {
        
    }
}
