using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;



/*
 * CLASSE: DraggableImage
 * RESPONSABILIDADE: Cria uma que pode ser arrastado pela UI
 * ATRIBUTOS:
 *           - picker - instancia do selecionador de slides 
 */
public class DraggableSlide : MonoBehaviour,IBeginDragHandler, IDragHandler, IEndDragHandler
{

   
    [SerializeField] private SlidePicker picker;
    private bool _isPicked = false;
    private bool _dragActive = false;


    private void Start() 
    {
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if(_isPicked == true )
        {
            _isPicked = false;
            picker.RemoveSlide();
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if(_dragActive)
        {
            transform.position = Input.mousePosition;
        }       
    }
    
    public void OnEndDrag(PointerEventData eventData)
    { 
        RectTransform rectTransform = picker.transform as RectTransform;
        //Se o mouse tiver no slide picker

        if(RectTransformUtility.RectangleContainsScreenPoint(rectTransform, Input.mousePosition))
        {    
            _isPicked = true;
            picker.ChangeSlide(this);
            DialogueManager.instance.TriggerNextDialogue();
            SetDragActive(false);
        }
        else
        {
            GetComponent<RectTransform>().anchoredPosition = Vector3.zero; 
        }
    }
    /*
     * RETURN TO INVENTORY
     *      - retorna o slide ao seu estado no iventário. 
     */
    public void ReturnToIventory()
    {
        transform.localPosition = Vector3.zero;
        _isPicked = false;
    }

    public void SetDragActive(bool status){
        _dragActive = status;
    }
}
