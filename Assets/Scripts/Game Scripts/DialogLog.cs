using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogLog
{
    public delegate void NewDialog(DialogLog dialog);
    public static event NewDialog newDialogEvent;

    Queue<Dialog> m_dialogs = new Queue<Dialog>();

    public Queue<Dialog> Dialogs
    {
        get
        {
            return m_dialogs;
        }
    }

    public void AddDialog(Dialog dialog)
    {
        m_dialogs.Enqueue(dialog);
        if (newDialogEvent != null)
            newDialogEvent(this);
    }

    public bool ContainsAll(Dialog[] dialogs)
    {
        foreach(Dialog dialog in dialogs)
        {
            if (!m_dialogs.Contains(dialog))
                return false;
        }

        return true;
    }
}
