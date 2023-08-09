using System;
using UnityEngine;
using QFramework;

namespace QFramework.FlappyBird
{
	public partial class Bg : ViewController
	{
		void Start()
		{
			// Code Here
		}

		private void Update()
		{
			//背景的移动
			transform.Translate(-1f*Time.deltaTime,0,0);
			//两个背景板相互交替出现
			if (transform.localPosition.x < -20)
			{
				transform.LocalPositionX(20);
			}
		}
	}
}
