using UnityEngine;
using System.Collections;

namespace S3
{
	public class VehicleCamera_Master : MonoBehaviour {

        public delegate void CameraTargetEventHandler(Transform targetTransform);
        public event CameraTargetEventHandler EventAssignCameraTarget;

        public void CallEventAssignCameraTarget(Transform targTransform)
        {
            if (EventAssignCameraTarget != null)
            {
                EventAssignCameraTarget(targTransform);
            }
        }
	}
}


