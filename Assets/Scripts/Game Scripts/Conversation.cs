
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using UnityEngine;

public class Conversation
{
    public delegate void NewMessage(Dialog message);
    public static event NewMessage newMessageEvent;

    List<Entity> m_participants = new List<Entity>();

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
        if (newMessageEvent != null)
            newMessageEvent(dialog);
    }

    public bool ContainsAll(Dialog[] dialogs)
    {
        List<string> dialogContents = m_dialogs.Select(x => x.content).ToList();

        foreach (Dialog dialog in dialogs)
        {
            // TODO: Expand this to the Entity who made the Dialog
            if (!dialogContents.Contains(dialog.content))
                return false;
        }

        return true;
    }

    public void AddParticipant(Entity newParticipant)
    {
        if (newParticipant != null)
            m_participants.Add(newParticipant);
    }

    public void TransmitMessage(Entity emiterEntity, Dialog message)
    {
        AddDialog(message);

        foreach (Entity entity in m_participants)
        {
            if (entity == emiterEntity)
                continue;
            Dialog nextMessage = entity.nextDialog(this);

            if (nextMessage != null)
            {
                TransmitMessage(entity, nextMessage);
            }
        }

    }
}
