namespace SunService
{
    partial class ProjectInstaller
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.SunServiceProcessInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            this.SunService = new System.ServiceProcess.ServiceInstaller();
            // 
            // SunServiceProcessInstaller
            // 
            this.SunServiceProcessInstaller.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.SunServiceProcessInstaller.Password = null;
            this.SunServiceProcessInstaller.Username = null;
            // 
            // SunService
            // 
            this.SunService.Description = "定时任务";
            this.SunService.ServiceName = "MyService";
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.SunServiceProcessInstaller,
            this.SunService});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller SunServiceProcessInstaller;
        private System.ServiceProcess.ServiceInstaller SunService;
    }
}