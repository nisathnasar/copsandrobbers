﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mirror;
using UnityEngine.SceneManagement;
using UnityEngine;


namespace Me.DerangedSenators.CopsAndRobbers
{
    class GameNetworkManager : MonoBehaviour
    {
        public GameObject moneyBagPrefab;

        private void Start()
        {
            SpawnMoneyBags();
            //SceneManager.sceneLoaded += delegate { SpawnMoneyBags(); };
        }

        public void ClientConnect() 
        {
            ClientScene.RegisterPrefab(moneyBagPrefab);
            NetworkClient.RegisterHandler<ConnectMessage>(OnClientConnect);
            NetworkClient.Connect("localhost");
        }

        void OnClientConnect(NetworkConnection nc, ConnectMessage cm)
        {
            Debug.Log("Connected to server: " + nc);
        }

        public void ServerListen()
        {
            NetworkServer.RegisterHandler<ConnectMessage>(OnServerConnect);
            NetworkServer.RegisterHandler<ReadyMessage>(OnClientReady);

            // start listening, and allow up to 4 connections
            NetworkServer.Listen(4);
        }

        private void OnClientReady(NetworkConnection arg1, ReadyMessage arg2)
        {
            Debug.Log("Client is ready to start: " + arg1);
            NetworkServer.SetClientReady(arg1);
            SpawnMoneyBags();
            //throw new NotImplementedException()
        }

        void SpawnMoneyBags()
        {
            int x = 0;
            for (int i = 0; i < 5; ++i)
            {
                GameObject moneyBagGo = Instantiate(moneyBagPrefab, new Vector3(x++, 0, 0), Quaternion.identity);
                NetworkServer.Spawn(moneyBagGo);
            }
        }

        void OnServerConnect(NetworkConnection nc, ConnectMessage cm)
        {
            Debug.Log("New client connected: " + nc);
        }

    }
}