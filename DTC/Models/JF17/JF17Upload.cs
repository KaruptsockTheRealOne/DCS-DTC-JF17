using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using DTC.Models.JF17;
using DTC.Models.Base;
using DTC.Models.JF17.Upload;

namespace DTC.Models
{
	public class JF17Upload
	{
		private int tcpPort = 42070;

		private JF17Configuration _cfg;
		private JF17Commands JF17 = new JF17Commands();

		public JF17Upload(JF17Configuration cfg)
		{
			tcpPort = Settings.TCPSendPort;

			_cfg = cfg;
		}

		public void Load()
		{
			var sb = new StringBuilder();

			if (_cfg.Waypoints.EnableUpload)
			{
				var waypointBuilder = new WaypointBuilder(_cfg, JF17, sb);
				waypointBuilder.Build();
			}

			if (_cfg.Radios.EnableUpload)
			{
				var radioBuilder = new RadioBuilder(_cfg, JF17, sb);
				radioBuilder.Build();
			}

			if (_cfg.CMS.EnableUpload)
			{
				var cmsBuilder = new CMSBuilder(_cfg, JF17, sb);
				cmsBuilder.Build();
			}

			if (_cfg.Misc.EnableUpload)
			{
				var miscBuilder = new MiscBuilder(_cfg, JF17, sb);
				miscBuilder.Build();
			}

			if (_cfg.MFD.EnableUpload)
			{
				var mfdBuilder = new MFDBuilder(_cfg, JF17, sb);
				mfdBuilder.Build();
			}

			if (_cfg.HARM.EnableUpload)
			{
				var harmBuilder = new HARMBuilder(_cfg, JF17, sb);
				harmBuilder.Build();
			}

			if (_cfg.HTS.EnableUpload)
			{
				var htsBuilder = new HTSBuilder(_cfg, JF17, sb);
				htsBuilder.Build();
			}

			if (sb.Length > 0)
			{
				sb.Remove(sb.Length - 1, 1);
			}

			var str = sb.ToString();

			if (str != "")
			{
				using (var tcpClient = new TcpClient("127.0.0.1", tcpPort))
				using (var ns = tcpClient.GetStream())
				using (var sw = new StreamWriter(ns))
				{
					var data = "[" + str + "]";
					Console.WriteLine(data);

					sw.WriteLine(data);
					sw.Flush();
				}
			}
		}
	}
}
