using System;
using System.Collections;
using UnityEngine;
using QFramework;

namespace QFramework.FlappyBird
{
	/// <summary>
	/// @author：TonyChang
	/// @Date:2023年8月8日
	/// </summary>
	public partial class Player : ViewController
	{
		private Rigidbody2D mRigidbody2D;
		private float JumpSpeed;
		private SpriteRenderer mSpriteRenderer;
		private bool mCheckPlayerInScreen = false;
		IEnumerator Start()
		{
			mRigidbody2D = GetComponent<Rigidbody2D>();
			JumpSpeed = 5.0f;
			mSpriteRenderer = GetComponent<SpriteRenderer>();
			//等一帧 再开始进行 结束判断
			yield return new WaitForEndOfFrame();
			
			mCheckPlayerInScreen = true;

			//游戏未开始时候小鸟一直正常飞行（小球不受重力）
			FlappyBird.GameState.RegisterWithInitValue(
				state =>
				{
					if (state == GameStates.NotStart)
					{
						mRigidbody2D.bodyType = RigidbodyType2D.Static;
					}
					else
					{
						mRigidbody2D.bodyType = RigidbodyType2D.Dynamic;
					}
					
				}
			).UnRegisterWhenGameObjectDestroyed(gameObject);
			
		}

		private void Update()
		{
			if (Input.GetMouseButtonDown(0))
			{
				//第一次点击屏幕则开始游戏
				if (FlappyBird.GameState.Value == GameStates.NotStart)
				{
					FlappyBird.GameState.Value = GameStates.Started;
				}

				if (FlappyBird.GameState.Value == GameStates.Started)
				{
					mRigidbody2D.velocity = Vector2.up * JumpSpeed;
					AudioKit.PlaySound("fly");
				}
				
			}
			
			//飞行时候进行倾斜位置
			if (mRigidbody2D.velocity.y > 0)
			{
				var angleZ = Mathf.Lerp(0, 30, mRigidbody2D.velocity.y / 5);
				transform.localEulerAngles = new Vector3(0, 0, angleZ);
			}
			else
			{
				var angleZ = Mathf.Lerp(0, -30, Mathf.Abs(mRigidbody2D.velocity.y / 5));
				transform.localEulerAngles = new Vector3(0, 0, angleZ);
			}
			//游戏结束的判断 进行
			if (mCheckPlayerInScreen&&!mSpriteRenderer.isVisible)
			{
				GameOver();
			}
		}

		private void OnCollisionEnter2D(Collision2D other)
		{
			AudioKit.PlaySound("collision");
			GameOver();
		}

		private void GameOver()
		{
			if (FlappyBird.GameState.Value == GameStates.Started)
			{
				FlappyBird.GameState.Value = GameStates.GameOver;
			}
		}
		
	}
}
