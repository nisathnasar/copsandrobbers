﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Me.DerangedSenators.CopsAndRobbers
{
    public class RoundBreakTimeManager : MonoBehaviour
    {
        private float currentTime = 0f;
        private float startingTime = 30f;

        public Button continueButton;
        

        [SerializeField] Text countdownText;

        void Start()
        {
            currentTime = startingTime;
            continueButton.enabled = false;
        }

        void Update()
        {
            currentTime -= 1 * Time.deltaTime;
            string minutes = Mathf.Floor(currentTime / 60).ToString("00");
            string seconds = Mathf.RoundToInt(currentTime % 60).ToString("00");

            countdownText.text = minutes + ":" + seconds;
            if (currentTime <= 0)
            {
                //load roundbreak scene
                //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                continueButton.enabled = true;
            }
        }

        /// <summary>
        /// Call this method to force-end the timer + move to next scene. 
        /// </summary>
        public void EndTimer()
        {
            currentTime = startingTime;
        }
    }
}