using System;
using UnityEngine;
using QFramework;

namespace QFramework.FlappyBird
{
	public partial class Pipe : ViewController
	{
		public float Speed = 3;
		private bool mScoreAdded = false;
		void Start()
		{
			// Code Here
		}

		private void FixedUpdate()
		{

			transform.LocalPositionX(transform.localPosition.x - Speed * Time.fixedDeltaTime);
			
			//进行积分
			if (transform.localPosition.x < -1.8f)
			{
				if (!mScoreAdded)
				{
					FlappyBird.Score.Value++;
					mScoreAdded = !mScoreAdded;
					AudioKit.PlaySound("Score");
				}
			}
			
			if (transform.localPosition.x < -20f)
			{
				PipeGenerator.PipePool.Recycle(this);
			}
			
		}

		public void ResetData()
		{
			mScoreAdded = false;
			this.Hide();
		}
		
	}
}
