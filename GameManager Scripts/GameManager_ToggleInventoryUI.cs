using UnityEngine;
using System.Collections;

namespace S3
{
    public class GameManager_ToggleInventoryUI : MonoBehaviour
    {
        [Tooltip("Does this game mode have an inventory? Set to true if that is the case")]
        public bool hasInventory;
        public GameObject inventoryUI;
        public string toggleInventoryButton;
        private GameManager_Master gameManagerMaster;

        // Use this for initialization
        void Start()
        {
            SetInitialReferences();
        }

        // Update is called once per frame
        void Update()
        {
            CheckForInventoryUIToggleRequest();
        }

        void SetInitialReferences()
        {
            gameManagerMaster = GetComponent<GameManager_Master>();

            if (toggleInventoryButton == "")
            {
                Debug.LogWarning("Please type in the name of the button used to toggle the inventory in " +
                    "GameManager_ToggleInventoryUI");
                this.enabled = false;
            }
        }

        void CheckForInventoryUIToggleRequest()
        {
            if (Input.GetButtonUp(toggleInventoryButton) && !gameManagerMaster.isMenuOn &&
                !gameManagerMaster.isGameOver && hasInventory && GameManager_References._player.activeSelf)
            {
                ToggleInventoryUI();
            }
        }

        public void ToggleInventoryUI()
        {
            if (inventoryUI != null)
            {
                inventoryUI.SetActive(!inventoryUI.activeSelf);
                gameManagerMaster.isInventoryUIOn = !gameManagerMaster.isInventoryUIOn;
                gameManagerMaster.CallEventInventoryUIToggle();
            }
        }
    }
}


