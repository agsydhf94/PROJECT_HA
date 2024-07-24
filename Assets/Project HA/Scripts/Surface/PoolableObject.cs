using UnityEngine;
using UnityEngine.Pool;

namespace HA
{
    public class PoolableObject : MonoBehaviour
    {
        public ObjectPool<GameObject> Parent;

        private void OnDisable()
        {
            if (Parent != null)
            {
                Parent.Release(gameObject);
            }
        }
    }
}
