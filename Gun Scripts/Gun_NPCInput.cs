using UnityEngine;
using System.Collections;

namespace S3
{
	public class Gun_NPCInput : MonoBehaviour {

        private Gun_Master gunMaster;
        private Transform myTransform;
        private RaycastHit hit;
        public LayerMask layersToDamage;

        private NPC_Master npcMaster;
        private NPC_StatePattern npcStatePattern;

        void OnEnable()
		{
            SetInitialReferences();
            gunMaster.EventNpcInput += NpcFireGun;

            if (npcMaster != null)
            {
                npcMaster.EventNPCRelationsChange += ApplyLayersToDamage;
            }

            Invoke("ObtainLayersToDamage", 0.3f);
        }

        void OnDisable()
		{
            gunMaster.EventNpcInput -= NpcFireGun;

            if (npcMaster != null)
            {
                npcMaster.EventNPCRelationsChange -= ApplyLayersToDamage;
            }
        }

		void SetInitialReferences()
		{
            gunMaster = GetComponent<Gun_Master>();
            myTransform = transform;

            if (transform.root.GetComponent<NPC_Master>() != null)
            {
                npcMaster = transform.root.GetComponent<NPC_Master>();
            }

            if (transform.root.GetComponent<NPC_StatePattern>() != null)
            {
                npcStatePattern = transform.root.GetComponent<NPC_StatePattern>();
            }
        }

        void NpcFireGun(float randomness)
        {
            Vector3 startPosition = new Vector3(Random.Range(-randomness, randomness), Random.Range(-randomness, randomness), 0.5f);

            if (Physics.Raycast(myTransform.TransformPoint(startPosition), myTransform.forward, out hit, GetComponent<Gun_Shoot>().range, layersToDamage))
            {
                if (hit.transform.GetComponent<NPC_TakeDamage>() != null ||
                    hit.transform == GameManager_References._player.transform)
                {
                    gunMaster.CallEventShotEnemy(hit, hit.transform);
                }

                else
                {
                    gunMaster.CallEventShotDefault(hit, hit.transform);
                }
            }
        }

        void ApplyLayersToDamage()
        {
            Invoke("ObtainLayersToDamage", 0.3f);
        }

        void ObtainLayersToDamage()
        {
            if (npcStatePattern != null)
            {
                layersToDamage = npcStatePattern.myEnemyLayers;
            }
        }

    }
}


