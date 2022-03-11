using DTC.Models.DCS;
using DTC.Models.JF17.Waypoints;
using System.Text;

namespace DTC.Models.JF17.Upload
{
	public class WaypointBuilder : BaseBuilder
	{
		private JF17Configuration _cfg;

		public WaypointBuilder(JF17Configuration cfg, IAircraftDeviceManager aircraft, StringBuilder sb) : base(aircraft, sb)
		{
			_cfg = cfg;
		}

		public override void Build()
		{
			var wpts = _cfg.Waypoints.Waypoints;
			var wptStart = _cfg.Waypoints.SteerpointStart;
			var wptEnd = _cfg.Waypoints.SteerpointEnd;

			if (wpts.Count == 0)
			{
				return;
			}

			var wptDiff = wptEnd - wptStart + 1;

			var ufc = _aircraft.GetDevice("UFC");
			var leftMFD = _aircraft.GetDevice("LMFD");

			for (var i = 0; i < wptDiff; i++)
			{
				Waypoint wpt;
				if (i < wpts.Count)
				{
					wpt = wpts[i];
				}
				else
				{
					//Repeats the last waypoint till it fills
					wpt = wpts[wpts.Count - 1];
				}

				if (wpt.Blank)
				{
					continue;
				}
				AppendCommand(ufc.GetCommand("4"));
				AppendCommand(ufc.GetCommand("R1"));
				if ((i + wptStart) < 10)
				{
					var tempstring = "0" + (i + wptStart).ToString();
					AppendCommand(BuildDigits(ufc, tempstring));
				}
				else
				{
					AppendCommand(BuildDigits(ufc, (i + wptStart).ToString()));
				}

				AppendCommand(BuildDigits(ufc, (i + wptStart).ToString()));
				AppendCommand(ufc.GetCommand("R1"));	
				
				AppendCommand(ufc.GetCommand("L2"));
				AppendCommand(BuildCoordinate(ufc, wpt.Latitude));
				AppendCommand(ufc.GetCommand("L2"));

				AppendCommand(ufc.GetCommand("L3"));
				AppendCommand(BuildCoordinate(ufc, wpt.Longitude));
				AppendCommand(ufc.GetCommand("L3"));
				
			}

		}

		private string BuildCoordinate(Device ufc, string coord)
		{
			var sb = new StringBuilder();

			var latStr = RemoveSeparators(coord.Replace(" ", ""));

			foreach (var c in latStr.ToCharArray())
			{
				if (c == 'N')
				{
					//sb.Append(ufc.GetCommand("0"));
				}
				else if (c == 'S')
				{
					sb.Append(ufc.GetCommand("0"));
				}
				else if (c == 'E')
				{
					//sb.Append(ufc.GetCommand("0"));
				}
				else if (c == 'W')
				{
					sb.Append(ufc.GetCommand("0"));
				}
				else
				{
					sb.Append(ufc.GetCommand(c.ToString()));
				}
			}

			return sb.ToString();
		}
	}
}
