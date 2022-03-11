using DTC.Models.JF17.CMS;
using DTC.Models.JF17.MFD;
using DTC.Models.JF17.Waypoints;
using DTC.Models.JF17.Radios;
using Newtonsoft.Json;
using DTC.Models.Base;
using DTC.Models.JF17.HARMHTS;
using DTC.Models.JF17.Misc;

namespace DTC.Models.JF17
{
	public class JF17Configuration : IConfiguration
	{
		public WaypointSystem Waypoints = new WaypointSystem();
		public RadioSystem Radios = new RadioSystem();
		public CMSystem CMS = new CMSystem();
		public MFDSystem MFD = new MFDSystem();
		public HARMSystem HARM = new HARMSystem();
		public HTSSystem HTS = new HTSSystem();
		public MiscSystem Misc = new MiscSystem();

		public string ToJson()
		{
			var json = JsonConvert.SerializeObject(this);
			return json;
		}

		public string ToCompressedString()
		{
			var json = ToJson();
			return StringCompressor.CompressString(json);
		}

		public static JF17Configuration FromJson(string s)
		{
			try
			{
				var cfg = JsonConvert.DeserializeObject<JF17Configuration>(s);
				cfg.AfterLoadFromJson();
				return cfg;
			}
			catch
			{
				return null;
			}
		}

		public void AfterLoadFromJson()
		{
			if (CMS != null)
			{
				CMS.AfterLoadFromJson();
			}
		}

		public static JF17Configuration FromCompressedString(string s)
		{
			try
			{
				var json = StringCompressor.DecompressString(s);
				var cfg = FromJson(json);
				return cfg;
			}
			catch
			{
				return null;
			}
		}

		public JF17Configuration Clone()
		{
			var json = ToJson();
			var cfg = FromJson(json);
			return cfg;
		}

		public void CopyConfiguration(JF17Configuration cfg)
		{
			if (cfg.Waypoints != null)
			{
				Waypoints = cfg.Waypoints;
			}
			if (cfg.CMS != null)
			{
				CMS = cfg.CMS;
			}
			if (cfg.Radios != null)
			{
				Radios = cfg.Radios;
			}
			if (cfg.MFD != null)
			{
				MFD = cfg.MFD;
			}
			if (cfg.HARM != null)
			{
				HARM = cfg.HARM;
			}
			if (cfg.HTS != null)
			{
				HTS = cfg.HTS;
			}
			if (cfg.Misc != null)
			{
				Misc = cfg.Misc;
			}
		}

		IConfiguration IConfiguration.Clone()
		{
			return Clone();
		}
	}
}
