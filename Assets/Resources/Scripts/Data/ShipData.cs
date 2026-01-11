using SubInterface;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ShipClass
{
    fighter, destroyer, cruiser, battleship, aircraftcarrier
}

public class ShipData : Unit , IUnit
{
    public ShipClass shipClass;
    int armmor;
    int hull;
    int shield;
    int damage;
    float attackspeed;
    float attackrange;
    float movespeed;

    public int Armmor
    {
        get { return armmor; }
        set
        {
            if (armmor <= 0)
            {
                armmor = 1;
            }
            else
            {
                armmor = value;
            }
        }
    }

    public int Hull
    {
        get { return hull; }
        set
        {
            if(hull <= 0)
            {
                Die();
            }
            else
            {
                hull = value;
            }
        }
    }

    public int Shild
    {
        get { return shield; }
        set
        {
            if (shield <= 0)
            {
                
            }
            else
            {
                shield = value;
            }
        }
    }

    public int Damage
    {
        get { return damage; }
        set
        {
            if (damage <= 0)
            {
                
            }
            else
            {
                damage = value;
            }
        }
    }

    public float AttackSpeed
    {
        get { return attackspeed; }
        set
        {
            if (attackspeed <= 0)
            {

            }
            else
            {
                attackspeed = value;
            }
        }
    }

    public float AttackRange
    {
        get { return attackrange; }
        set
        {
            if (attackrange <= 0)
            {

            }
            else
            {
                attackrange = value;
            }
        }
    }

    public float MoveSpeed
    {
        get { return movespeed; }
        set
        {
            if (movespeed <= 0)
            {

            }
            else
            {
                movespeed = value;
            }
        }
    }

    public void Die()
    {
        
    }

    public void Attack()
    {
        
    }

    void IUnit.Move()
    {
        
    }


}