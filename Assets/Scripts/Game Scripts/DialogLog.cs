using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogLog
{
    public delegate void NewDialog(DialogLog dialog);
    public static event NewDialog newDialogEvent;

    Queue<Dialog> dialogs = new Queue<Dialog>();

    public Queue<Dialog> Dialogs
    {
        get
        {
            return dialogs;
        }
    }

    public void AddDialog(Dialog dialog)
    {
        dialogs.Enqueue(dialog);
        if (newDialogEvent != null)
            newDialogEvent(this);
    }
}
