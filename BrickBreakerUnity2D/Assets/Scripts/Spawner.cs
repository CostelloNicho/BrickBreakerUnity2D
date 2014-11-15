// Copyright 2014 Nicholas Costello <NicholasJCostello@gmail.com>

using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class Spawner : Singleton<Spawner>
    {
        // prefab to spawn
        //buffer around the edge of the screen where nothing can spawn
        private const float EdgeBufferZone = 0.5f;
        public GameObject MousePrefab;

        // Use this for initialization
        protected void Start()
        {
            SpawnMouse();
        }

        /// <summary>
        /// Spawn Mouse
        ///     Spawn a mouse within the camera's view
        /// </summary>
        public void SpawnMouse()
        {
            float x = Random.Range(
                -(ResolutionManager.HalfWidth - EdgeBufferZone),
                (ResolutionManager.HalfWidth - EdgeBufferZone)
                );
            float y = Random.Range(
                -(ResolutionManager.HalfHeight - EdgeBufferZone),
                ResolutionManager.HalfHeight - EdgeBufferZone
                );
            x = Mathf.Round(x*2)/2;
            y = Mathf.Round(y*2)/2;
            var spawnLocation = new Vector3(x, y, 0f);
            Instantiate(MousePrefab, spawnLocation, Quaternion.identity);
        }
    }
}