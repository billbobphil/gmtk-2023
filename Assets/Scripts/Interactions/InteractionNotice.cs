using Effects;
using UnityEngine;

namespace Interactions
{
    public class InteractionNotice : MonoBehaviour
    {
        [SerializeField] private Float floatEffect;
        private SpriteRenderer _spriteRenderer;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _spriteRenderer.enabled = false;
        }

        public void Show()
        {
            floatEffect.Reset();
            _spriteRenderer.enabled = true;
            floatEffect.StartFloating();
        }

        public void Hide()
        {
            _spriteRenderer.enabled = false;
            floatEffect.StopFloating();
        }
    }
}
