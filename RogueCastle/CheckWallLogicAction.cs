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
	public class CheckWallLogicAction : LogicAction
	{
		private EnemyObj m_obj;
		public override void Execute()
		{
			if (ParentLogicSet != null && ParentLogicSet.IsActive)
			{
				m_obj = (ParentLogicSet.ParentGameObj as EnemyObj);
				SequenceType = Types.Sequence.Serial;
				base.Execute();
			}
		}
		public override void Update(GameTime gameTime)
		{
			ExecuteNext();
			base.Update(gameTime);
		}
		public override void ExecuteNext()
		{
			base.ExecuteNext();
		}
		public override object Clone()
		{
			return new CheckWallLogicAction();
		}
		public override void Dispose()
		{
			if (!IsDisposed)
			{
				m_obj = null;
				base.Dispose();
			}
		}
	}
}
