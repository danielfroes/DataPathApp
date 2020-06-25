using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
public class TweenControler : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    

    public void HighlightComponent(GameObject component)
    {   
        component.GetComponent<Image>().DOColor(Color.red, 1f);
    }

    public void UnhighlightComponent(GameObject component)
    {
        Color color;
        if(ColorUtility.TryParseHtmlString("#444671", out color))
            component.GetComponent<Image>().DOColor(color , 0.5f);
    }

    public void PopupComponent(GameObject component)
    {
        Vector2 bufferScale = component.transform.localScale;
        component.transform.localScale = Vector3.zero;

        if(!component.activeInHierarchy)
            component.SetActive(true);

        component.transform.DOScale(bufferScale, 0.5f);
    }

    public void PopdownComponent(GameObject component)
    {
        component.transform.DOScale(Vector3.zero, 0.5f).OnComplete(()=>component.SetActive(false));

    }

    public void ActivateDrag(GameObject component)
    {
        Color color;
        if(ColorUtility.TryParseHtmlString("#444671", out color))
            component.GetComponent<Image>().DOColor(color , 0.5f);

        component.GetComponent<DraggableSlide>().SetDragActive(true);

        component.transform.DOPunchScale(component.transform.localScale * 0.1f, 1f, 1, 0.5f);
    }

}
