using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Entity", menuName = "Entities/New Entity")]
public class Entity : ScriptableObject
{
    public Dialog[] dialogs;
    private Dictionary<Dialog, bool> doneDialogs = new Dictionary<Dialog, bool>();

    public void Init()
    {
        foreach(Dialog dialog in dialogs)
        {
            doneDialogs[dialog] = false;
        }
    }
    public Dialog nextDialog(Conversation log)
    {
        foreach(Dialog dialog in dialogs)
        {
            if (log.ContainsAll(dialog.requiredDialogs))
            {
                if (!doneDialogs[dialog])
                {
                    doneDialogs[dialog] = true;
                    return dialog;
                }
            }
        }

        return null;
    }
}