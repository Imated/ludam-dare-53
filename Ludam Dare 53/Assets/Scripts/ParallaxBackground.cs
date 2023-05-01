using UnityEngine;

namespace LunarJam
{
    public class ParallaxBackground : MonoBehaviour
    {
        [SerializeField] private float parallaxSpeed = 0.5f;
        [SerializeField] private float resetYPosition  = -20f;

        private Vector3 _originalPosition;

        private void Awake()
        {
            _originalPosition = transform.position;
        }

        private void Update()
        {
            var xDelta = Time.deltaTime * -parallaxSpeed;
            var yDelta = Time.deltaTime * -parallaxSpeed;
            transform.position += new Vector3(xDelta, yDelta, 0f);
            if (transform.position.y <= resetYPosition)
                transform.position = _originalPosition;
        }
    }
}