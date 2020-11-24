using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace Me.DerangedSenators.CopsAndRobbers
{
    public class PlayerIdentifier : MonoBehaviour
    {
        private bool hasBeenChanged = false;

        private int playerID;

        // Start is called before the first frame update
        void Start()
        {
            playerID = 2;
        }

        // Update is called once per frame
        void Update()
        {

        }
        public int GetPlayerID()
        {
            return playerID;
        }

        public void SetPlayerID(int number)
        {
            if (!hasBeenChanged)
            {
                playerID = number;
                hasBeenChanged = true;
            }
        }

    }
}