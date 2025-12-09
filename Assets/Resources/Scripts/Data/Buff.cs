using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BuffBase
{
    protected BuffController buffcontroller;

    public void Init(BuffController buffController)
    {
        this.buffcontroller = buffController;
    }

    public abstract void SetupBuff(object buffs);
    public abstract void RemoveBuff(object buffs);
}

public abstract class Buff<TTarget> : BuffBase
{
    public abstract void Apply(TTarget typesname, int value);
    public abstract void Clear(TTarget typesname, int value);
}

public class DrawBuff : Buff<PlayerData>
{
    public int buffvalue;

    public override void Apply(PlayerData player, int value)
    {
        buffvalue = value;
        player.drawCount = player.drawCount + buffvalue;
    }

    public override void Clear(PlayerData player, int value)
    {
        buffvalue = value;
        player.drawCount = player.drawCount - buffvalue;
    }

    public override void SetupBuff(object buffs)
    {
        SetupBuff((PlayerData)buffs);
    }

    public void SetupBuff(PlayerData player)
    {
        buffcontroller.buffs.AddLast(this);
    }

    public override void RemoveBuff(object buffs)
    {
        RemoveBuff((PlayerData)buffs);
    }

    public void RemoveBuff(PlayerData player)
    {
        buffcontroller.buffs.Remove(this);
    }
}

public class HpBuff : Buff<Ship>
{
    public int buffvalue;

    public override void Apply(Ship ship, int value)
    {
        buffvalue = value;
        ship.Hull = ship.Hull + buffvalue;
    }

    public override void Clear(Ship ship, int value)
    {
        buffvalue = value;
        ship.Hull = ship.Hull - buffvalue;
    }


    public override void SetupBuff(object buffs)
    {
        SetupBuff((Ship)buffs);
    }
    public void SetupBuff(PlayerData player)
    {
        buffcontroller.buffs.AddLast(this);
    }

    public override void RemoveBuff(object buffs)
    {
        RemoveBuff((PlayerData)buffs);
    }

    public void RemoveBuff(PlayerData player)
    {
        buffcontroller.buffs.Remove(this);
    }
}
