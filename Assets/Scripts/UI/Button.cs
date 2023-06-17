using MoreMountains.Feedbacks;
using UnityEngine;
using UnityEngine.EventSystems;

namespace UI
{
    public class Button : MonoBehaviour, ISelectHandler, IPointerEnterHandler, IPointerExitHandler
    {
        [SerializeField] private MMFeedbacks highlightedFb;
        [SerializeField] private MMFeedbacks unhighlightedFb;
        [SerializeField] private MMFeedbacks selectedFb;
        
        public void OnPointerEnter(PointerEventData eventData)
        {
            highlightedFb.PlayFeedbacks();
        }
        
        public void OnPointerExit(PointerEventData eventData)
        {
            unhighlightedFb.PlayFeedbacks();
        }

        public void OnSelect(BaseEventData eventData)
        {
            selectedFb.PlayFeedbacks();
        }


    }
}
