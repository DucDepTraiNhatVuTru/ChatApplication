namespace PhoneCall.UI
{
    partial class CallView
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this._panelLocalVideo = new System.Windows.Forms.Panel();
            this._flpRemoteVideo = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // _panelLocalVideo
            // 
            this._panelLocalVideo.Location = new System.Drawing.Point(702, 375);
            this._panelLocalVideo.Name = "_panelLocalVideo";
            this._panelLocalVideo.Size = new System.Drawing.Size(69, 62);
            this._panelLocalVideo.TabIndex = 1;
            // 
            // _flpRemoteVideo
            // 
            this._flpRemoteVideo.Location = new System.Drawing.Point(0, 3);
            this._flpRemoteVideo.Name = "_flpRemoteVideo";
            this._flpRemoteVideo.Size = new System.Drawing.Size(696, 434);
            this._flpRemoteVideo.TabIndex = 2;
            // 
            // CallView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this._flpRemoteVideo);
            this.Controls.Add(this._panelLocalVideo);
            this.Name = "CallView";
            this.Size = new System.Drawing.Size(774, 440);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel _panelLocalVideo;
        private System.Windows.Forms.FlowLayoutPanel _flpRemoteVideo;
    }
}
