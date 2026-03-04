using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace RomanceHotel.GUI
{
    public partial class FormSaoLuuPhucHoi : Form
    {
        private FormMain formMain;

        public FormSaoLuuPhucHoi(FormMain formMain)
        {
            InitializeComponent();
            this.formMain = formMain;
        }

        // Lấy connection string từ DBConnection.txt
        private string GetConnectionStringFromFile()
        {
            try
            {
                if (File.Exists("DBConnection.txt"))
                {
                    string[] lines = File.ReadAllLines("DBConnection.txt");
                    if (lines.Length >= 2)
                    {
                        string server = lines[0];
                        string database = lines[1];
                        return $"Data Source={server};Initial Catalog={database};Integrated Security=True;";
                    }
                }
            }
            catch { }

            return @"data source=(LocalDB)\MSSQLLocalDB;attachdbfilename=|DataDirectory|\Database\RomanceHotel.mdf;integrated security=True;";
        }

        // ============================
        //   MỞ FOLDER DIALOG TỰ PHÓNG TO (Cách 2)
        // ============================
        private void btnBrowseBackupPath_Click(object sender, EventArgs e)
        {
            string selectedPath = "";
            Thread t = new Thread(() =>
            {
                using (FolderBrowserDialog folder = new FolderBrowserDialog())
                {
                    folder.Description = "Chọn thư mục sao lưu (.bak)";
                    folder.RootFolder = Environment.SpecialFolder.Desktop;
                    folder.ShowNewFolderButton = true;

                    DialogResult dr = folder.ShowDialog();
                    if (dr == DialogResult.OK)
                        selectedPath = folder.SelectedPath;
                }
            });

            t.SetApartmentState(ApartmentState.STA);
            t.Start();
            t.Join();

            if (!string.IsNullOrEmpty(selectedPath))
            {
                txtBackupPath.Text = selectedPath;
            }
        }

        private void btnBrowseRestoreFile_Click(object sender, EventArgs e)
        {
            string selectedFile = "";
            Thread t = new Thread(() =>
            {
                using (OpenFileDialog open = new OpenFileDialog())
                {
                    open.Filter = "Backup Files (*.bak)|*.bak";
                    open.Title = "Chọn file sao lưu";

                    if (open.ShowDialog() == DialogResult.OK)
                        selectedFile = open.FileName;
                }
            });

            t.SetApartmentState(ApartmentState.STA);
            t.Start();
            t.Join();

            if (!string.IsNullOrEmpty(selectedFile))
            {
                txtRestoreFile.Text = selectedFile;
            }
        }

        // ============================
        //   SAO LƯU
        // ============================
        private void btnBackup_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtBackupPath.Text))
            {
                MessageBox.Show("Vui lòng chọn thư mục sao lưu!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string connectionString = GetConnectionStringFromFile();
                string backupFile = $"Backup_{DateTime.Now:yyyyMMdd_HHmmss}.bak";
                string fullPath = Path.Combine(txtBackupPath.Text, backupFile);

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string dbName = conn.Database;

                    string query = $"BACKUP DATABASE [{dbName}] TO DISK='{fullPath}'";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.CommandTimeout = 0;
                        cmd.ExecuteNonQuery();
                    }
                }

                progressBar.Value = 100;
                labelStatus.Text = "Sao lưu thành công!";
                MessageBox.Show($"Đã sao lưu thành công!\nFile: {fullPath}",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                progressBar.Value = 0;
                MessageBox.Show("Lỗi sao lưu:\n" + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ============================
        //   PHỤC HỒI
        // ============================
        private void btnRestore_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtRestoreFile.Text))
            {
                MessageBox.Show("Vui lòng chọn file .bak để phục hồi!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                string restoreFile = txtRestoreFile.Text;
                string currentConn = GetConnectionStringFromFile();

                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(currentConn);
                string dbName = builder.InitialCatalog;

                builder.InitialCatalog = "master";
                string masterConn = builder.ConnectionString;

                SqlConnection.ClearAllPools();

                using (SqlConnection conn = new SqlConnection(masterConn))
                {
                    conn.Open();

                    // Kill connection
                    string killQuery = $@"
DECLARE @kill VARCHAR(8000)='';
SELECT @kill = @kill + 'KILL ' + CONVERT(VARCHAR(5), session_id) + ';'
FROM sys.dm_exec_sessions 
WHERE database_id = DB_ID('{dbName}');
EXEC(@kill);";

                    new SqlCommand(killQuery, conn).ExecuteNonQuery();

                    // Restore
                    string restoreQuery = $@"
RESTORE DATABASE [{dbName}] 
FROM DISK = N'{restoreFile}' 
WITH REPLACE;";

                    SqlCommand restoreCmd = new SqlCommand(restoreQuery, conn);
                    restoreCmd.CommandTimeout = 0;
                    restoreCmd.ExecuteNonQuery();
                }

                progressBar.Value = 100;
                labelStatus.Text = "Phục hồi thành công!";
                MessageBox.Show("Phục hồi dữ liệu thành công!",
                    "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                progressBar.Value = 0;
                MessageBox.Show("Lỗi phục hồi:\n" + ex.Message,
                    "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
