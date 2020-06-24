using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;




/*
 * CLASSE: SlidePicker
 * RESPONSABILIDADE: Selecionar a lâminas que serão colocadas na lente.
 * ATRIBUTOS:
 *           - _lensSlide - lamina que está sendo mostrada na lente
 *           - _claw - transform da garra que é rotacionada na animação de abrir o seletor 
 *           - _openAngle - o tamanho do angulo de abertura que a garra vai rotacionar
 *           - _smooth - a suavidade dos LERPS
 *           - _slideContainer - a posição em que a imagem do slide ficara posicionada
 */
public class SlidePicker : MonoBehaviour
{
    [SerializeField] private float _smooth;
    [SerializeField] private Transform _slideContainer;
    private Quaternion _newClawRotation;
    private Vector3 _newSlidePosition;
    private DraggableSlide _currentSlide = null;
    
    
    

    private void Start() 
    {
    }

    private void Update() {


        if(_currentSlide != null)
        {
            _currentSlide.transform.position = Vector3.Lerp( _currentSlide.transform.position, _slideContainer.position , _smooth) ;
        }
    }


    /*
     * Change Slide:
     *              - Coloca uma nova lâmina na lente e no seletor
     * 
     */
    public void ChangeSlide(DraggableSlide newSlide)
    {
        if(_currentSlide != null)
        {
            _currentSlide.ReturnToIventory();
        }
        
        _currentSlide = newSlide;
       
    }

    /* 
     * Remove Slide:
     *               - Remove a lâmina atual da lente e do seletor
     */
    public void RemoveSlide()
    {
        _currentSlide.ReturnToIventory();
        _currentSlide = null; 
    }

    

}
