/*
  Rogue Legacy Enhanced

  This project is based on modified disassembly of Rogue Legacy's engine, with permission to do so by its creators..
  Therefore, former creators copyright notice applies to the original disassembly and its modifications. 

  Copyright(C) 2011-2015, Cellar Door Games Inc.
  Rogue Legacy(TM) is a trademark or registered trademark of Cellar Door Games Inc. All Rights Reserved.
*/

using System;
using DS2DEngine;

namespace RogueCastle
{
	public class DialogueObj : IDisposableObj
	{
		private bool m_isDisposed;
		public string[] Speakers
		{
			get;
			set;
		}
		public string[] Dialogue
		{
			get;
			set;
		}
		public bool IsDisposed
		{
			get
			{
				return m_isDisposed;
			}
		}
		public DialogueObj(string[] speakers, string[] dialogue)
		{
			if (speakers.Length != dialogue.Length)
			{
				throw new Exception("Cannot create dialogue obj with mismatching speakers and dialogue");
			}
			Speakers = speakers;
			Dialogue = dialogue;
		}
		public void Dispose()
		{
			if (!m_isDisposed)
			{
				Array.Clear(Dialogue, 0, Dialogue.Length);
				Dialogue = null;
				Array.Clear(Speakers, 0, Speakers.Length);
				Speakers = null;
				m_isDisposed = true;
			}
		}
	}
}
