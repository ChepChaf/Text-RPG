using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    Conversation m_currentConversation = null;
    DialogLog m_dialogLog = null;

    [SerializeField]
    InputField m_textInput = null;
    // Start is called before the first frame update

    PlayerEntity m_playerEntity = null;

    void Start()
    {
        m_playerEntity = new PlayerEntity();

        m_dialogLog = new DialogLog();

        m_currentConversation = new Conversation();
        m_currentConversation.AddParticipant(new GameMasterEntity());
        m_currentConversation.AddParticipant(m_playerEntity);
    }

    private void OnEnable()
    {
        Conversation.newMessageEvent += NewDialog;
    }

    private void OnDisable()
    {
        Conversation.newMessageEvent -= NewDialog;
    }

    void NewDialog(string message)
    {
        m_dialogLog.AddDialog(message);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (m_textInput.text.Length > 0)
            {
                NewDialog(m_textInput.text);
                m_currentConversation.TransmitMessage(m_playerEntity, m_textInput.text);
                m_textInput.text = "";
            }
        }
    }
}
