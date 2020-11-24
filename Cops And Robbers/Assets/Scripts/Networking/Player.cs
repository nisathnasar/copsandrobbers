using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProtoBuf;

namespace Me.DerangedSenators.CopsAndRobbers
{
    [SerializeField]
    [ProtoContract]
    public class Player
    {
        [ProtoMember(1)]
        public int playerID;
        [ProtoMember(2)]
        public Vector3 position;
        [ProtoMember(3)]
        public int[] playersHit;
        [ProtoMember(4)]
        public int moneyBagPicked = 0;
        [ProtoMember(5)]
        public Team team;
        [ProtoMember(6)]
        public float playerCurrentHealth;

        /*
         * checking speed, attack radius, current weopen equipped, attack who's attacking who for attack animation
        */

        public enum Team
        {
            COP, ROBBER
        }

        GameObject playerObject;
        PlayerAttack playerAttack;
        PlayerHealth playerHealth;

        void Start()
        {
            playerObject = GameObject.Find("Player");
            
            playerAttack = playerObject.GetComponent<PlayerAttack>();

            playerHealth = playerObject.GetComponent<PlayerHealth>();
        }

        void Update()
        {
            position = playerObject.transform.position;

            playersHit = playerAttack.getPlayersHit();

            playerCurrentHealth = playerHealth.GetCurrentHealth();
        }

        public void SetPosition(Vector3 NewPosition)
        {
            position = NewPosition;
        }
    }
}