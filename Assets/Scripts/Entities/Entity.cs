using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity
{
    public abstract string nextAction(string lastMessage);
}