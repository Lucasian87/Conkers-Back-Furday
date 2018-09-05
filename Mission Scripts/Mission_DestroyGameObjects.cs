using UnityEngine;
using System.Collections;
using UnityEngine.UI;

namespace S3
{
	public class Mission_DestroyGameObjects : MonoBehaviour {

        private Mission_Master missionMaster;

        public bool isComplete;
        public string nameOfObjective;    
        public GameObject[] objectsToDestroy;
        public GameObject textPrefab;
        public GameObject contentUI;
        public GameObject objectiveMarker;
        private Text objectiveTextField;
        private float nextCheckTime = 5;
        private float checkRate = 2;

		void Start () 
		{
            SetInitialReferences();
            CreateUIText();
		}
	
		void Update () 
		{
            CheckIfObjectiveCompleted();
		}

		void SetInitialReferences()
		{
            missionMaster = GetComponent<Mission_Master>();
		}

        void CreateUIText()
        {
            if (objectsToDestroy.Length == 0)
            {
                Debug.LogWarning("No objectives have been assigned to Mission_DestroyGameObjects.");
                return;
            }

            GameObject go = (GameObject)Instantiate(textPrefab);
            go.transform.SetParent(contentUI.transform, false);

            objectiveTextField = go.GetComponent<Text>();
            objectiveTextField.text = nameOfObjective;
        }

        void CheckIfObjectiveCompleted()
        {
            if (Time.time < nextCheckTime)
            {
                return;
            }

            nextCheckTime = Time.time + checkRate;

            foreach (GameObject obj in objectsToDestroy)
            {
                if (obj != null)
                {
                    return;
                }
            }

            isComplete = true;

            if (objectiveMarker != null)
            {
                objectiveMarker.SetActive(false);
            }

            objectiveTextField.text = "(Complete) " + nameOfObjective;
            objectiveTextField.color = Color.green;
            missionMaster.CallEventObjectiveComplete();
        }
	}
}


