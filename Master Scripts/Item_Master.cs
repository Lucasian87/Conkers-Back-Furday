﻿using UnityEngine;
using System.Collections;

namespace S3
{
	public class Item_Master : MonoBehaviour {

        private Player_Master playerMaster;

        public delegate void GeneralEventHandler();
        public event GeneralEventHandler EventObjectThrow;
        public event GeneralEventHandler EventObjectPickup;

        public delegate void PickupActionEventHandler(Transform item);
        public event PickupActionEventHandler EventPickupAction;

        private bool isOnPlayer;

        void Start()
        {
            SetInitialReferences();
            CheckIfOnPlayer();
        }

        public void CallEventObjectThrow()
        {
            if (EventObjectThrow != null)
            {
                EventObjectThrow();
                
            }

            if (isOnPlayer)
            {
                playerMaster.CallEventHandsEmpty();
                playerMaster.CallEventInventoryChanged();
                CheckIfOnPlayer();
            }
        }

        public void CallEventObjectPickup()
        {
            if (EventObjectPickup != null)
            {
                EventObjectPickup();               
            }

            if (!isOnPlayer)
            {
                playerMaster.CallEventInventoryChanged();
                CheckIfOnPlayer();
            }
        }

        public void CallEvenPickupAction(Transform item)
        {
            if (EventPickupAction != null)
            {
                EventPickupAction(item);
            }
        }

		void SetInitialReferences()
		{
            if (GameManager_References._player != null)
            {
                playerMaster = GameManager_References._player.GetComponent<Player_Master>();
            }
		}

        void CheckIfOnPlayer()
        {
            if (transform.root == GameManager_References._player.transform)
            {
                isOnPlayer = true;
            }
            else
            {
                isOnPlayer = false;
            }
        }
    }
}


