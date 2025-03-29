using System;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
        [SerializeField] private InventoryParameters inventoryParameters;
        [SerializeField] private GameObject hammerPrefab;

        public void Update()
        {
                if (Input.GetKeyDown(KeyCode.A))
                {
                        inventoryParameters.AddItem(new Hammer(), hammerPrefab);
                }
        }
}