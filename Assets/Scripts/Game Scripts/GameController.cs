using System.Collections;
using System.Collections.Generic;

using TMPro;

using UnityEngine;
using UnityEngine.UI;

public class GameController : Singleton<GameController>
{
    Conversation m_currentConversation = null;

    [SerializeField]
    InputField m_textInput = null;
    // Start is called before the first frame update

    [SerializeField]
    Entity m_playerEntity = null;

    [SerializeField]
    Entity m_gameMasterEntity = null;

    void Start()
    {
        m_gameMasterEntity.Init();
        m_playerEntity.Init();

        m_currentConversation = new Conversation();
        m_currentConversation.AddParticipant(m_gameMasterEntity);
        m_currentConversation.AddParticipant(m_playerEntity);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (m_textInput.text.Length > 0)
            {
                Dialog playerDialog = ScriptableObject.CreateInstance<Dialog>();
                playerDialog.content = m_textInput.text;

                m_currentConversation.TransmitMessage(m_playerEntity, playerDialog);
                m_textInput.text = "";
            }
        }
    }
}
