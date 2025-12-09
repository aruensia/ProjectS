using ISubInterface;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ShipClass
{
    destroyer, cruiser, battleship, aircraftcarrier
}

public class Ship : Unit , IUnit
{
    public ShipClass shipClass;
    int armmor;
    int hull;
    int shield;

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