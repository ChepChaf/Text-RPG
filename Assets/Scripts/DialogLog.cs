using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogLog
{
    public delegate void NewDialog(DialogLog dialog);
    public static event NewDialog newDialogEvent;

    Queue<string> dialogs = new Queue<string>();

    public Queue<string> Dialogs
    {
        get
        {
            return dialogs;
        }
    }

    public void AddDialog(string dialog)
    {
        dialogs.Enqueue(dialog);
        if (newDialogEvent != null)
            newDialogEvent(this);
    }
}
