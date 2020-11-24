using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProtoBuf;
using System;


namespace Me.DerangedSenators.CopsAndRobbers
{
    [Serializable]
    [ProtoContract]
    public class Players
    {
        [ProtoMember(1)]
        public string TeamName;
        [ProtoMember(2)]
        public Player[] Team;
        [ProtoMember(3)]
        public static int value = 1;

        public int getValue()
        {
            return value;
        }
        public void setValue(int val)
        {
            value = val;
        }
        
        public int[] getPlayersHit() 
        {
            if (Team[0] != null) {
                return Team[0].playersHit;
            }
            int[] emptyArr = { -1 };
            return emptyArr;
        }

        public Player GetPlayerFromArray(int index) {
            return Team[index];
        }
        

    }


    /*
    [Serializable]
    [ProtoContract]
    public class Player
    {
        [ProtoMember(1)]
        public string Name;
        [ProtoMember(2)]
        public int Age;
        [ProtoMember(3)]
        public Vector3 position;

        //GameObject playerObject;

        void Start() 
        {
            //playerObject = GameObject.Find("Player");
        }

        void Update()
        {
            //position = playerObject.transform.position;
        }

        public void SetPosition(Vector3 NewPosition) 
        {
            position = NewPosition;
        }
    }
    */
}