using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Dialog", menuName = "Dialogs/New Dialog")]
public class Dialog : ScriptableObject
{
    [Header("Content")]
    public string content;
}
