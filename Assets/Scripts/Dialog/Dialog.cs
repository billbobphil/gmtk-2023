using System;
using UnityEngine;

namespace Dialog
{
    [Serializable]
    public class Dialog
    {
        [SerializeField] private string message;
        [SerializeField] private DialogActors actor;

        public string GetMessage()
        {
            return message;
        }

        public DialogActors GetActor()
        {
            return actor;
        }
    }
}