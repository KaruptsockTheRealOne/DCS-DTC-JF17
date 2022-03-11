﻿using DTC.Models;
using DTC.Models.JF17;
using DTC.UI.CommonPages;
using System;

namespace DTC.UI.Aircrafts.JF17
{
	public partial class UploadToJetPage : AircraftSettingPage
	{
		private JF17Upload _jetInterface;
		private readonly JF17Configuration _cfg;

		public UploadToJetPage(AircraftPage parent, JF17Configuration cfg) : base(parent)
		{
			InitializeComponent();
			_jetInterface = new JF17Upload(cfg);

			txtWaypointStart.LostFocus += TxtWaypointStart_LostFocus;
			txtWaypointEnd.LostFocus += TxtWaypointEnd_LostFocus;
			txtWaypointStart.Text = cfg.Waypoints.SteerpointStart.ToString();
			txtWaypointEnd.Text = cfg.Waypoints.SteerpointEnd.ToString();
			_cfg = cfg;

			chkWaypoints.Checked = _cfg.Waypoints.EnableUpload;
			chkCMS.Checked = _cfg.CMS.EnableUpload;
			chkRadios.Checked = _cfg.Radios.EnableUpload;
			chkMisc.Checked = _cfg.Misc.EnableUpload;
			chkMFDs.Checked = _cfg.MFD.EnableUpload;
			chkHARM.Checked = _cfg.HARM.EnableUpload;
			chkHTS.Checked = _cfg.HTS.EnableUpload;

			CheckUploadButtonEnabled();
		}

		private void CheckUploadButtonEnabled()
		{
			btnUpload.Enabled = (_cfg.Waypoints.EnableUpload || _cfg.CMS.EnableUpload || _cfg.Radios.EnableUpload || _cfg.Misc.EnableUpload || _cfg.MFD.EnableUpload || _cfg.HARM.EnableUpload || _cfg.HTS.EnableUpload);
		}

		public override string GetPageTitle()
		{
			return "Upload to Jet";
		}

		private void TxtWaypointEnd_LostFocus(object sender, EventArgs e)
		{
			if (int.TryParse(txtWaypointEnd.Text, out int n))
			{
				_cfg.Waypoints.SetSteerpointEnd(n);
				_parent.DataChangedCallback();
			}

			txtWaypointEnd.Text = _cfg.Waypoints.SteerpointEnd.ToString();
		}

		private void TxtWaypointStart_LostFocus(object sender, EventArgs e)
		{
			if (int.TryParse(txtWaypointStart.Text, out int n))
			{
				_cfg.Waypoints.SetSteerpointStart(n);
				_parent.DataChangedCallback();
			}

			txtWaypointStart.Text = _cfg.Waypoints.SteerpointStart.ToString();
		}

		private void btnUpload_Click(object sender, EventArgs e)
		{
			_jetInterface.Load();
		}

		private void chkWaypoints_CheckedChanged(object sender, EventArgs e)
		{
			txtWaypointStart.Enabled = chkWaypoints.Checked;
			txtWaypointEnd.Enabled = chkWaypoints.Checked;
			_cfg.Waypoints.EnableUpload = chkWaypoints.Checked;
			_parent.DataChangedCallback();
			CheckUploadButtonEnabled();
		}

		private void chkCMS_CheckedChanged(object sender, EventArgs e)
		{
			_cfg.CMS.EnableUpload = chkCMS.Checked;
			_parent.DataChangedCallback();
			CheckUploadButtonEnabled();
		}

		private void chkRadios_CheckedChanged(object sender, EventArgs e)
		{
			_cfg.Radios.EnableUpload = chkRadios.Checked;
			_parent.DataChangedCallback();
			CheckUploadButtonEnabled();
		}

		private void chkMisc_CheckedChanged(object sender, EventArgs e)
		{
			_cfg.Misc.EnableUpload = chkMisc.Checked;
			_parent.DataChangedCallback();
			CheckUploadButtonEnabled();
		}

		private void chkMFDs_CheckedChanged(object sender, EventArgs e)
		{
			_cfg.MFD.EnableUpload = chkMFDs.Checked;
			_parent.DataChangedCallback();
			CheckUploadButtonEnabled();
		}

        private void chkHARM_CheckedChanged(object sender, EventArgs e)
        {
			_cfg.HARM.EnableUpload = chkHARM.Checked;
			_parent.DataChangedCallback();
			CheckUploadButtonEnabled();
		}

        private void chkHTS_CheckedChanged(object sender, EventArgs e)
        {
			_cfg.HTS.EnableUpload = chkHTS.Checked;
			_parent.DataChangedCallback();
			CheckUploadButtonEnabled();
		}
    }
}
