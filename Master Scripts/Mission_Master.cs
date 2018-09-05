using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace S3
{
	public class Mission_Master : MonoBehaviour {

        public Mission_DestroyGameObjects[] scriptsMissionDestroyGameObjects;
        public GameObject missionUIPanel;
        public GameObject objectiveUIPanel;
        public Text missionOutcomeText;
        public string missionAccomplished = "Mission Accomplished!";

        public delegate void GeneralEventHandler();
        public event GeneralEventHandler EventObjectiveComplete;


		void Start () 
		{
            CaptureAllObjectives();
		}

        void CaptureAllObjectives()
        {
            scriptsMissionDestroyGameObjects = GetComponents<Mission_DestroyGameObjects>();
        }

        public void CallEventObjectiveComplete()
        {
            if (EventObjectiveComplete != null)
            {
                EventObjectiveComplete();
            }

            CheckIfAllDestroyObjectivesComplete();
        }

        void CheckIfAllDestroyObjectivesComplete()
        {
            if (scriptsMissionDestroyGameObjects.Length == 0)
            {
                //Debug.Log("ran length 0");
                return;
            }

            foreach (Mission_DestroyGameObjects obejctive in scriptsMissionDestroyGameObjects)
            {
                if (!obejctive.isComplete)
                {
                    //Debug.Log("not all missions complete");
                    return;
                }               
            }

            ActivateMissionComplete();
        }

        void ActivateMissionComplete()
        {
            missionUIPanel.SetActive(true);
            objectiveUIPanel.SetActive(false);
            missionOutcomeText.text = missionAccomplished;
        }
	}
}


