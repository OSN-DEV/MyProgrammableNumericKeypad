namespace MyProgrammableTenkey.UI.Main {
    partial class MyProgrammableNumericKeypadMain {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MyProgrammableNumericKeypadMain));
            this.MainMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.Notify = new System.Windows.Forms.NotifyIcon(this.components);
            this.MainMenuObserve = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenuLoadKeymapping = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenuShowKeymapping = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.MainMenuQuit = new System.Windows.Forms.ToolStripMenuItem();
            this.MainMenu.SuspendLayout();
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MainMenuObserve,
            this.toolStripSeparator2,
            this.MainMenuLoadKeymapping,
            this.MainMenuShowKeymapping,
            this.toolStripSeparator1,
            this.MainMenuQuit});
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(171, 104);
            // 
            // Notify
            // 
            this.Notify.ContextMenuStrip = this.MainMenu;
            this.Notify.Icon = ((System.Drawing.Icon)(resources.GetObject("Notify.Icon")));
            this.Notify.Text = "MPNO";
            this.Notify.Visible = true;
            // 
            // MainMenuObserve
            // 
            this.MainMenuObserve.CheckOnClick = true;
            this.MainMenuObserve.Name = "MainMenuObserve";
            this.MainMenuObserve.Size = new System.Drawing.Size(170, 22);
            this.MainMenuObserve.Text = "observe";
            // 
            // MainMenuLoadKeymapping
            // 
            this.MainMenuLoadKeymapping.Name = "MainMenuLoadKeymapping";
            this.MainMenuLoadKeymapping.Size = new System.Drawing.Size(170, 22);
            this.MainMenuLoadKeymapping.Text = "load keymapping";
            // 
            // MainMenuShowKeymapping
            // 
            this.MainMenuShowKeymapping.Name = "MainMenuShowKeymapping";
            this.MainMenuShowKeymapping.Size = new System.Drawing.Size(170, 22);
            this.MainMenuShowKeymapping.Text = "show keymapping";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(167, 6);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(167, 6);
            // 
            // MainMenuQuit
            // 
            this.MainMenuQuit.Name = "MainMenuQuit";
            this.MainMenuQuit.Size = new System.Drawing.Size(170, 22);
            this.MainMenuQuit.Text = "quit";
            this.MainMenu.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip MainMenu;
        private System.Windows.Forms.NotifyIcon Notify;
        private System.Windows.Forms.ToolStripMenuItem MainMenuObserve;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem MainMenuLoadKeymapping;
        private System.Windows.Forms.ToolStripMenuItem MainMenuShowKeymapping;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem MainMenuQuit;
    }
}
