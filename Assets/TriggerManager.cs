// %BANNER_BEGIN%
// ---------------------------------------------------------------------
// %COPYRIGHT_BEGIN%
//
// Copyright (c) 2018 Magic Leap, Inc. All Rights Reserved.
// Use of this file is governed by the Creator Agreement, located
// here: https://id.magicleap.com/creator-terms
//
// %COPYRIGHT_END%
// ---------------------------------------------------------------------
// %BANNER_END%

using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.XR.MagicLeap;

    /// <summary>
    /// This class provides examples of how you can use haptics and LEDs
    /// on the Control.
    /// </summary>
    [RequireComponent(typeof(ControllerConnectionHandler))]
    public class TriggerManager : MonoBehaviour
    {
        #region Private Variables
        private ControllerConnectionHandler _controllerConnectionHandler;

        [SerializeField]
        private UnityEvent[] triggers;
        
        private int index;
        #endregion

        #region Const Variables
        private const float TRIGGER_DOWN_MIN_VALUE = 0.2f;

        #endregion

        #region Unity Methods
        /// <summary>
        /// Initialize variables, callbacks and check null references.
        /// </summary>
        void Start()
        {
            _controllerConnectionHandler = GetComponent<ControllerConnectionHandler>();

            MLInput.OnTriggerDown += HandleOnTriggerDown;
        }

        /// <summary>
        /// Update controller input based feedback.
        /// </summary>
        void Update()
        {
        }

        /// <summary>
        /// Stop input api and unregister callbacks.
        /// </summary>
        void OnDestroy()
        {
            if (MLInput.IsStarted)
            {
                MLInput.OnTriggerDown -= HandleOnTriggerDown;
            }
        }
        #endregion

        #region Private Methods

        #endregion

        #region Event Handlers
        /// <summary>
        /// Handles the event for trigger down.
        /// </summary>
        /// <param name="controller_id">The id of the controller.</param>
        /// <param name="value">The value of the trigger button.</param>
        private void HandleOnTriggerDown(byte controllerId, float value)
        {
            MLInputController controller = _controllerConnectionHandler.ConnectedController;
            if (controller != null && controller.Id == controllerId)
            {
                if (index < triggers.Length)
                {
                    triggers[index].Invoke();
                    index++;
                }

                MLInputControllerFeedbackIntensity intensity = (MLInputControllerFeedbackIntensity)((int)(value * 2.0f));
                controller.StartFeedbackPatternVibe(MLInputControllerFeedbackPatternVibe.Buzz, intensity);
            }
        }
        #endregion
    }
