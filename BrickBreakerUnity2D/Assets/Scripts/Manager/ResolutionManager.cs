
using UnityEngine;

namespace Assets.Scripts.Managers
{
    public static class ResolutionManager
    {
        // maximum x position an object can spawn
        public static float HalfWidth
        {
            get { return Camera.main.aspect * Camera.main.orthographicSize; }
        }
        //maximum y position an object can spawn
        public static float HalfHeight
        {
            get { return Camera.main.orthographicSize; }
        }
    }
}
