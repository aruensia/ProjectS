using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ISubInterface
{
    public interface IUnit
    {
        public void Attack();
        public void Move();
        public void Die();
    }

    public interface IUseble
    {
        public void Use();
    }

    public interface IDrow
    {
        public void drow();
    }
}
