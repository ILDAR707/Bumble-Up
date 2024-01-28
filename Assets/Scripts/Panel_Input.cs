using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Panel_Input : MonoBehaviour, IEndDragHandler, IDragHandler, IPointerClickHandler, IBeginDragHandler
{
	public Moving moving;
    float xStart;
	
    public TranslateSpawn spawn1;
    public TranslateSpawn spawn2;
    private void Start()
    {
        MyEventManager.eventPlayerDead += EnableFalse;
    }

    private void OnDestroy()
    {
        MyEventManager.eventPlayerDead -= EnableFalse;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
		if(eventData.position.x - xStart > 0)
		{
			moving.MoveRight();
		}
		else if(eventData.position.x - xStart < 0)
        {
			moving.MoveLeft();
        }
    }
    
    public void OnPointerClick(PointerEventData eventData)
    {
        if(eventData.delta.x == 0) 
        {
            MyEventManager.CallIncreaseScore();
            moving.MoveUp();

            spawn1.SpawnTranslate();
            spawn2.SpawnTranslate();
        }
    }

    public void OnDrag(PointerEventData eventData){}

    void EnableFalse()
    {
        this.enabled = false;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        xStart = eventData.position.x;
    }
}