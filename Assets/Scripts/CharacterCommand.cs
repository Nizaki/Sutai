using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CharacterCommand
{
    protected GameObject owner;

    public CharacterCommand(GameObject owner)
    {
        this.owner = owner;
    }

    public virtual void OnEnter()
    {
    }

    public virtual void OnExit()
    {
    }

    public abstract IEnumerator Excecute();
}