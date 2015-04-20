/*
  Rogue Legacy Enhanced

  This project is based on modified disassembly of Rogue Legacy's engine, with permission to do so by its creators..
  Therefore, former creators copyright notice applies to the original disassembly and its modifications. 

  Copyright(C) 2011-2015, Cellar Door Games Inc.
  Rogue Legacy(TM) is a trademark or registered trademark of Cellar Door Games Inc. All Rights Reserved.
*/

using DS2DEngine;
using Microsoft.Xna.Framework;

namespace RogueCastle
{
	public class KingObj : PhysicsObj
	{
		private bool m_wasHit;
		public bool WasHit
		{
			get
			{
				return m_wasHit;
			}
		}
		public KingObj(string spriteName) : base(spriteName, null)
		{
		}
		public override void CollisionResponse(CollisionBox thisBox, CollisionBox otherBox, int collisionResponseType)
		{
			IPhysicsObj physicsObj = otherBox.AbsParent as IPhysicsObj;
			if (collisionResponseType == 2 && physicsObj.CollisionTypeTag == 2 && !m_wasHit)
			{
				SoundManager.Play3DSound(this, Game.ScreenManager.Player, new string[]
				{
					"EnemyHit1",
					"EnemyHit2",
					"EnemyHit3",
					"EnemyHit4",
					"EnemyHit5",
					"EnemyHit6"
				});
				SoundManager.PlaySound("Boss_Title_Exit");
				SoundManager.PlaySound("Player_Death_Grunt");
				Point center = Rectangle.Intersect(thisBox.AbsRect, otherBox.AbsRect).Center;
				if (thisBox.AbsRotation != 0f || otherBox.AbsRotation != 0f)
				{
					center = Rectangle.Intersect(thisBox.AbsParent.Bounds, otherBox.AbsParent.Bounds).Center;
				}
				Vector2 position = new Vector2(center.X, center.Y);
				(otherBox.AbsParent as PlayerObj).AttachedLevel.ImpactEffectPool.DisplayEnemyImpactEffect(position);
				m_wasHit = true;
			}
			base.CollisionResponse(thisBox, otherBox, collisionResponseType);
		}
		protected override GameObj CreateCloneInstance()
		{
			return new KingObj(SpriteName);
		}
	}
}
