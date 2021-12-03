using UnityEngine;

namespace CommonTool
{
    public class ParticleHelper : MonoBehaviour
    {
        ParticleSystem[] ps;
        public float psScaleFloat = 0.5f;

        private void Start()
        {
            foreach (var item in transform.GetComponentsInChildren<ParticleSystem>())
            {
                var main = item.main;
                main.scalingMode = ParticleSystemScalingMode.Local;
                item.transform.localScale = new Vector3(psScaleFloat, psScaleFloat, psScaleFloat);
            }
        }
    }
}