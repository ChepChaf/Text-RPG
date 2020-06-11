
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conversation
{
    public delegate void NewMessage(Dialog message);
    public static event NewMessage newMessageEvent;

    List<Entity> m_participants = new List<Entity>();

    public void AddParticipant(Entity newParticipant)
    {
        if (newParticipant != null)
            m_participants.Add(newParticipant);
    }

    public void TransmitMessage(Entity emiterEntity, string message)
    {
        foreach (Entity entity in m_participants)
        {
            if (entity == emiterEntity)
                continue;
            Dialog nextMessage = entity.nextDialog();

            if (newMessageEvent != null && nextMessage != null)
                newMessageEvent(nextMessage);
        }
        
    }
}
