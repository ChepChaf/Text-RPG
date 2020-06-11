using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Entity", menuName = "Entities/New Entity")]
public class Entity : ScriptableObject
{
    public Dialog[] dialogs;

    public Dialog nextDialog()
    {
        return dialogs[0];
    }
}