using DTC.Models.Presets;
using DTC.Models.Base;
using DTC.UI.Base.Controls;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using DTC.Models.F16;
using DTC.Models.JF17;


namespace DTC.UI.CommonPages
{
	public partial class AircraftPage : Page
	{
		protected readonly Aircraft _aircraft;
		protected readonly Preset _preset;

		public override string PageTitle
		{
			get { return _preset.Name; }
		}

		public AircraftPage(Aircraft aircraft, Preset preset)
		{
			InitializeComponent();
			_aircraft = aircraft;
			_preset = preset;

			RefreshPages();
		}

		private AircraftSettingPage[] GetPages(IConfiguration configuration)
		{
			if (_aircraft.Model == AircraftModel.F16C)
			{
				var cfg = (F16Configuration)configuration;
				return new AircraftSettingPage[]
				{
					new Aircrafts.F16.UploadToJetPage(this, cfg),
					new Aircrafts.F16.LoadSavePage(this, cfg),
					new Aircrafts.F16.WaypointsPage(this, cfg.Waypoints),
					new Aircrafts.F16.CMSPage(this, cfg.CMS),
					new Aircrafts.F16.RadioPage(this, cfg.Radios),
					new Aircrafts.F16.MFDPage(this, cfg.MFD),
					new Aircrafts.F16.HARMPage(this, cfg.HARM),
					new Aircrafts.F16.HTSPage(this, cfg.HTS),
					new Aircrafts.F16.MiscPage(this, cfg.Misc)
				};
			}
			else if (_aircraft.Model == AircraftModel.JF17)
			{
				var cfg = (JF17Configuration)configuration;
				return new AircraftSettingPage[]
				{
					new Aircrafts.JF17.UploadToJetPage(this, cfg),
					new Aircrafts.JF17.LoadSavePage(this, cfg),
					new Aircrafts.JF17.WaypointsPage(this, cfg.Waypoints),
					new Aircrafts.JF17.CMSPage(this, cfg.CMS),
					new Aircrafts.JF17.RadioPage(this, cfg.Radios),
					new Aircrafts.JF17.MFDPage(this, cfg.MFD),
					new Aircrafts.JF17.HARMPage(this, cfg.HARM),
					new Aircrafts.JF17.HTSPage(this, cfg.HTS),
					new Aircrafts.JF17.MiscPage(this, cfg.Misc)
				};
			}

			throw new Exception();
		}

		private void SetPage(AircraftSettingPage page)
		{
			foreach (AircraftSettingPage ctl in pnlMain.Controls)
			{
				ctl.Visible = false;
			}
			page.Visible = true;
		}

		public void ToggleEnabled()
		{
			pnlLeft.Enabled = !pnlLeft.Enabled;
		}

		public void DataChangedCallback()
		{
			PresetsStore.PresetChanged(_aircraft, _preset);
		}

		internal void RefreshPages()
		{
			var pages = GetPages(_preset.Configuration);

			var lst = new List<AircraftSettingPage>(pages);
			lst.Reverse();

			pnlMain.Controls.Clear();
			pnlLeft.Controls.Clear();

			foreach (var page in lst)
			{
				page.Visible = false;
				var btn = new DTCButton();
				btn.Text = page.GetPageTitle();
				btn.Dock = DockStyle.Top;
				btn.Click += (object sender, EventArgs e) =>
				{
					SetPage(page);
				};

				page.Dock = DockStyle.Fill;
				page.Visible = false;
				pnlMain.Controls.Add(page);
				pnlLeft.Controls.Add(btn);
			}
		}
	}
}