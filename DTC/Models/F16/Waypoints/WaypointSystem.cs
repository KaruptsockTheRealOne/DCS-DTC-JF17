﻿using System.Collections.Generic;

namespace DTC.Models.F16.Waypoints
{
	public class WaypointSystem
	{
		public List<Waypoint> Waypoints { get; set; }
		public int SteerpointStart { get; set; }
		public int SteerpointEnd { get; set; }
		public bool EnableUpload { get; set; }

		public WaypointSystem()
		{
			Waypoints = new List<Waypoint>();
			SteerpointStart = 1;
			SteerpointEnd = 20;
			EnableUpload = true;
		}

		public Waypoint Add(Waypoint wpt)
		{
			var seq = Waypoints.Count + 1;
			wpt.Sequence = seq;
			Waypoints.Add(wpt);
			return wpt;
		}

		public void SetSteerpointStart(int v)
		{
			if (v >= 1 && v <= SteerpointEnd)
			{
				SteerpointStart = v;
			}
		}

		public void SetSteerpointEnd(int v)
		{
			if (v >= SteerpointStart && v <= 127)
			{
				SteerpointEnd = v;
			}
		}

		public void Remove(Waypoint wpt)
		{
			Waypoints.Remove(wpt);
			RecalculateSequence();
		}

		public void Reorder(int idxFrom, int idxTo)
		{
			var wpt = Waypoints[idxFrom];
			Waypoints.Remove(wpt);
			Waypoints.Insert(idxTo, wpt);
			RecalculateSequence();
		}

		private void RecalculateSequence()
		{
			for (int i = 0; i < Waypoints.Count; i++)
			{
				Waypoint wpt = Waypoints[i];
				wpt.Sequence = i + 1;
			}
		}
	}
}
