using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Architectures.ScriptableObjects
{
    [CreateAssetMenu(menuName = "Managers/VFX Manager", fileName = "VFX Manager")]
    public class VFXManagerSO : ScriptableObject
    {
        [SerializeField]
        private List<ParticleSystem> vfxPrefabs = new List<ParticleSystem>();
        [SerializeField]
        private List<string> vfxNames = new List<string>();

        public void PlaySFXClip(string vfxName, Vector3 spawnPos)
        {
            var index = vfxNames.IndexOf(vfxName);

            if (index == -1)
            {
                Debug.Log("Prefab " + vfxName + " doesn't exist");
                return;
            }

            var vfx = Instantiate(vfxPrefabs[index], spawnPos, Quaternion.identity);
            vfx.Play();
        }
    }
}