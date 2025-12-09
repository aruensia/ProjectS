using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;


public class BuffController : MonoBehaviour
{
    public LinkedList<BuffBase> buffs = new LinkedList<BuffBase>();

    public TBuff CreateBuff<TBuff, TTarget>() where TBuff : Buff<TTarget>, new()
    {
        TBuff buff = new TBuff();
        buff.Init(this);
        return new TBuff();
    }

    public void ApplyBuff<TBuff, TTarget>(TTarget target, int value) where TBuff : Buff<TTarget>, new()
    {
        TBuff buff = new TBuff();
        buff.Apply(target, value);
    }
}
