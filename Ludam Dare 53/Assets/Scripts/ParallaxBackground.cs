using UnityEngine;

namespace LunarJam
{
    public class ParallaxBackground : MonoBehaviour
    {
        [SerializeField] private float scrollSpeed = 0.5f;
        [SerializeField] private float backgroundWidth = 25f;
        [SerializeField] private float resetPos = 7f;

        private void Update()
        {
            transform.position += new Vector3(-scrollSpeed * Time.deltaTime, 0);
            if (transform.position.x < -backgroundWidth)
                transform.position = new Vector3(resetPos, transform.position.y);
        }
    }
}