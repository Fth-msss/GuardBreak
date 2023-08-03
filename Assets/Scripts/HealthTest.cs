using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthTest : MonoBehaviour
{
    [SerializeField]
    float hp;
    //float maxhp;

    public float Hp 
    {
        get {  return hp; }
        set { hp = value;hpChange?.Invoke(hp); }
    
    }

    public delegate void HealthChangeHandler(float health);
    public event HealthChangeHandler hpChange;

    // Update is called only for debug

   public bool Takedamage = false;
   public bool Heal = false;
    void Update()
    {
        if(Takedamage) { Takedamage = false; Hp -= 1; }

        if(Heal) {Heal = false; Hp += 1; }
    }
}
