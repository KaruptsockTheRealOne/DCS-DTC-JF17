﻿using System.Text;

namespace DTC.Models.DCS
{
	public abstract class BaseBuilder
	{
		protected IAircraftDeviceManager _aircraft;
		private StringBuilder _sb;

		public BaseBuilder(IAircraftDeviceManager aircraft, StringBuilder sb)
		{
			_aircraft = aircraft;
			_sb = sb;
		}

		public abstract void Build();

		protected void AppendCommand(string s)
		{
			_sb.Append(s);
		}

		protected static string BuildDigits(Device d, string s)
		{
			StringBuilder sb = new StringBuilder();

			foreach (var c in s.ToCharArray())
			{
				sb.Append(d.GetCommand(c.ToString()));
			}

			return sb.ToString();
		}

		protected static string Wait()
		{
			var str = "{'device':'wait', 'delay': 200},";
			return str.Replace("'", "\"");
		}

		protected static string StartCondition(string condition)
		{
			var str = "{'start_condition': '" + condition + "'},";
			return str.Replace("'", "\"");
		}

		protected static string EndCondition(string condition)
		{
			var str = "{'end_condition': '" + condition + "'},";
			return str.Replace("'", "\"");
		}

		protected static string DeleteLeadingZeros(string s)
		{
			while (s.StartsWith("0"))
			{
				s = s.Remove(0, 1);
			}
			if (s == "") s = "0";
			return s;
		}

		protected static string RemoveSeparators(string s)
		{
			return s.Replace(",", "").Replace(".", "");
		}
	}
}
