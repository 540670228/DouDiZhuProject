using System;
using System.Collections;
using System.Collections.Generic;
using ET;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ns
{
	public class PokerListener : MonoBehaviour,IPointerDownHandler,IPointerUpHandler,IPointerEnterHandler
	{
		public event Action onPointerDown;
		public event Action onPointerUp;
		public event Action onPointerEnter;
		public event Action onPointerSlider;

		public bool isDown = false;
		
		//1s内不重复进行操作
		private float sliderTime = 0.5f;

		public void RemoveAllListener()
		{
			Log.Warning("移除监听器");
			this.onPointerDown = null;
			this.onPointerUp = null;
			this.onPointerSlider = null;
			this.onPointerEnter = null;
		}
		
		private void Update()
		{
			if (Input.GetMouseButton(0))
				this.isDown = true;
			else this.isDown = false;
			this.sliderTime += Time.deltaTime;
		}

		public void OnPointerDown(PointerEventData eventData)
		{
			sliderTime = 0;
			this.onPointerDown?.Invoke();
			this.onPointerSlider?.Invoke();
		}

		public void OnPointerUp(PointerEventData eventData)
		{
			this.onPointerUp?.Invoke();
		}

		//只会回调一次
		public void OnPointerEnter(PointerEventData eventData)
		{
			if (this.sliderTime > 0.5)
			{
				this.sliderTime = 0;
				this.onPointerEnter?.Invoke();
				if(this.isDown)
					this.onPointerSlider?.Invoke();
			}
			
		}
		
		
	}
}
