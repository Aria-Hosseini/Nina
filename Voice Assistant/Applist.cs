using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Microsoft.Win32;
using InstalledPrograms; 

namespace InstalledPrograms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SetupListView();
            LoadInstalledPrograms();
        }

        private void SetupListView()
        {
            listViewPrograms.View = View.Details;
            listViewPrograms.FullRowSelect = true;
            listViewPrograms.Columns.Add("نام برنامه", 300);
            listViewPrograms.Columns.Add("نسخه", 100);
        }

        private void LoadInstalledPrograms()
        {
            listViewPrograms.Items.Clear();
            List<(string Name, string Version)> programs = GetInstalledPrograms();

            foreach (var program in programs)
            {
                ListViewItem item = new ListViewItem(program.Name);
                item.SubItems.Add(program.Version);
                listViewPrograms.Items.Add(item);
            }
        }

        private List<(string, string)> GetInstalledPrograms()
        {
            List<(string, string)> programs = new List<(string, string)>();
            string registryKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Uninstall";

            using (RegistryKey key = Registry.LocalMachine.OpenSubKey(registryKey))
            {
                if (key != null)
                {
                    foreach (string subKeyName in key.GetSubKeyNames())
                    {
                        using (RegistryKey subKey = key.OpenSubKey(subKeyName))
                        {
                            string displayName = subKey?.GetValue("DisplayName") as string;
                            string displayVersion = subKey?.GetValue("DisplayVersion") as string ?? "نامشخص";

                            if (!string.IsNullOrEmpty(displayName))
                            {
                                programs.Add((displayName, displayVersion));
                            }
                        }
                    }
                }
            }
            return programs.OrderBy(p => p.Item1).ToList();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadInstalledPrograms();
        }

        private void btnRefresh_Click_1(object sender, EventArgs e)
        {

        }

        private void btncloseapp_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnminapp_Click(object sender, EventArgs e)
        {
            this.WindowState = (FormWindowState.Minimized);
        }
    }
}
