using UnityEngine;
using System.Collections;
using UnityStandardAssets.Vehicles.Car;

namespace S3
{
	public class Vehicle_Master : MonoBehaviour {

        public delegate void GeneralEventHandler();
        public event GeneralEventHandler EventExitVehicle;

        public delegate void VehicleEventHandler(GameObject driverGO, string driverTag, LayerMask driverLayer);
        public event VehicleEventHandler EventEnterVehicle;

        public bool isVehicleOccupied;
        public string defaultTag = "Untagged";
        public string exitButton = "PickUpItem";
        public int defaultLayerNumber;
        public LayerMask defaultLayer;
        public GameObject cameraMultipurpose;     
        public Transform cabin;
        public GameObject vehicleCamera;
        public Transform cameraTarget;
        
        [HideInInspector]
        public GameObject driver;

        void Start()
        {
            ApplyDefaultLayer();
        }

        void ApplyDefaultLayer()
        {
            defaultLayerNumber = gameObject.layer;
        }

        public void CallEventExitVehicle()
        {
            if (EventExitVehicle != null)
            {
                EventExitVehicle();
            }
        }

        public void CallEventEnterVehicle(GameObject driverGo, string dTag, LayerMask dLayer)
        {
            if (EventEnterVehicle != null)
            {
                EventEnterVehicle(driverGo, dTag, dLayer);
            }
        }
	}
}


