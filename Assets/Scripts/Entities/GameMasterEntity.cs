using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMasterEntity : Entity
{
    public override string nextAction(string lastMessage)
    {
        string message = null;
        if (lastMessage == "Hello")
        {
            message = "Hi I'm the Game Master, welcome to the best game ever!";
        }

        return message;
    }
}
