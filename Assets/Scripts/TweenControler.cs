using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class TweenControler : MonoBehaviour
{

    private List<GameObject> bufferHighlighted;
    private List<GameObject> bufferPopup;    
    public static TweenControler instance;
    public Image TransitionPanel;

    // Start is called before the first frame update
    private void Awake() {
        bufferPopup = new List<GameObject>();
        bufferHighlighted = new List<GameObject>();

        if(instance == null)
            instance = this;
        else if(instance != this)
            Destroy(this);   
    }


    private void Start() {
        TransitionPanel.gameObject.SetActive(true);
        TransitionPanel.DOFade(0,1).OnComplete(() =>{

            if(DialogueManager.instance != null)
                DialogueManager.instance.TriggerInitialDialogue();
            
            TransitionPanel.gameObject.SetActive(false);
        });

    }

    
    // Update is called once per frame
    void Update()
    {
         
    }
    

    public void HighlightComponent(GameObject component)
    {   
        bufferHighlighted.Add(component);
        component.GetComponent<Image>().DOColor(Color.red, 1f);
    }

    public void UnhighlightComponent(GameObject component)
    {
        Color color;
        
        if(ColorUtility.TryParseHtmlString("#444671", out color))
        {
            Image tmp = component.GetComponent<Image>();
            tmp.DOKill();
            tmp.DOColor(color , 0.5f);
        }
    }

    public void PopupComponent(GameObject component)
    {
        Vector2 bufferScale = component.transform.localScale;
        component.transform.localScale = Vector3.zero;

        if(!component.activeInHierarchy)
            component.SetActive(true);

        component.transform.DOScale(bufferScale, 0.5f);

        bufferPopup.Add(component);
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


        DraggableSlide tmp = component.GetComponent<DraggableSlide>();

        tmp.SetDragActive(true);
        PopupComponent(tmp.picker.gameObject);
        component.transform.DOPunchScale(component.transform.localScale * 0.1f, 1f, 1, 0.5f);
       

        DialogueManager.instance.NextButton.SetActive(false);
        DialogueManager.instance.WaitButton.SetActive(true);



    }

    public void PopDownAll()
    {
        foreach(GameObject component in bufferPopup )
        {
            PopdownComponent(component);
            
        }
        bufferPopup.Clear();
    }

    public void UnhighligthAll()
    {
        foreach(GameObject component in bufferHighlighted )
        {
            UnhighlightComponent(component);
        }

        bufferHighlighted.Clear();
    }


    public void LoadLevel(string name){
        TransitionPanel.gameObject.SetActive(true);
        TransitionPanel.DOFade(1,1).OnComplete(() =>{
            SceneManager.LoadScene(name);
        });
    }
}
