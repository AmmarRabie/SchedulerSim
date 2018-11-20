using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace SchedulingSim
{
    public partial class MainForm : Form
    {
        string solverFileName;
        string pythonLocation;

        enum SchedulingAlgo : int
        {
            HPF,
            FCFS,
            RR,
            SRTN,
            COUNT,
        }
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            string[] alogrithms = loadAlgos();
            comboBox1.DataSource = alogrithms;

            if (!File.Exists("config.txt"))
            {
                pythonLocation = "python.exe";
                solverFileName = "Scheduler";
                return;
            }
            string[] configLines = File.ReadAllLines("config.txt");
            if (configLines.Length < 1)
            {
                MessageBox.Show("config files should have 2 lines (first is solverName, scd is python location)");
                Close();
                return;
            }
            solverFileName = configLines[0].Trim();
            pythonLocation = configLines[1].Trim();
            if (!(File.Exists(solverFileName + ".py") || File.Exists(solverFileName + ".exe")) || !File.Exists(pythonLocation))
            {
                MessageBox.Show("config files pathes is incorrect");
                Close();
            }
            pythonLocation = '"' + pythonLocation + '"';
        }

        private string[] loadAlgos()
        {
            string[] algos = new String[(int)SchedulingAlgo.COUNT];
            for (int algo = 0; algo < (int) SchedulingAlgo.COUNT; algo++)
                algos[algo] = ((SchedulingAlgo)algo).ToString();
            return algos;
        }

        private void btn_run_Click(object sender, EventArgs e)
        {
            string algo = comboBox1.SelectedItem.ToString();
            if(pb_graph.Image != null)
                pb_graph.Image.Dispose();
            executeSolverProgram(algo, tb_inputPath.Text.ToString(), this.tb_st.Text, tb_quantum.Text);
        }

        private void onSelctionChanged(object sender, EventArgs e)
        {
            const int RRIndex = (int)SchedulingAlgo.RR;
            int selected = comboBox1.SelectedIndex;
            this.tb_quantum.Enabled = selected == RRIndex;
            if (selected != RRIndex) {
                this.tb_quantum.Text = "";
            }
        }

        private void btn_browse_Click(object sender, EventArgs e)
        {
            string file = chooseFile();
            if (file.Length <= 1) return;
            tb_inputPath.Text = file;
        }

        private string chooseFile()
        {
            var openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "In files|*.in";
            openFileDialog.Title = "Select a proccesses File";
            string fileName = "";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                fileName = openFileDialog.FileName;
            }
            return fileName;
        }

        private void executeSolverProgram(string algoName, string fileName, string switchingtime, string q = "")
        {
            string ext = cb_pyExtension.Checked ? ".py" : ".exe";
            string strCmdText = solverFileName + ext;

            string strCommandParameters = algoName += " ";
            strCommandParameters += '"' + fileName + '"' + " ";
            strCommandParameters += switchingtime += " ";
            strCommandParameters += q;

            string[] outpuots = runProcess(strCmdText, strCommandParameters);
            if (outpuots == null) return;
            using (FileStream stream = new FileStream(outpuots[0], FileMode.Open, FileAccess.Read))
            {
                pb_graph.Image = Image.FromStream(stream);
            }
            //pb_graph.Image = Image.FromFile(outpuots[0]);
            Process.Start("notepad", outpuots[1]);
            lbl_avgTAT.Text = outpuots[2];
            lbl_avgWTAT.Text = outpuots[3];
        }

        private string[] runProcess(string filePath, string args)
        {
            ProcessStartInfo start = new ProcessStartInfo();
            string extension = Path.GetExtension(filePath);
            switch (extension)
            {
                case ".exe":
                    start.FileName = filePath;
                    start.Arguments = args;
                    break;
                case ".py":
                    // start.FileName = @"C:\Data\Anaconda3\python.exe";
                    start.FileName = pythonLocation;
                    start.Arguments = string.Format("\"{0}\" {1}", filePath, args);
                    break;
                default:
                    throw new Exception("solver file extension not supported, only exe or py");
            }
            start.UseShellExecute = false;// Do not use OS shell
            start.CreateNoWindow = true; // We don't need new window
            start.RedirectStandardOutput = true;// Any output, generated by application will be redirected back
            start.RedirectStandardError = true; // Any error in standard output will be redirected back (for example exceptions)

            Process process = Process.Start(start);
            string stdError = process.StandardError.ReadToEnd();
            if (stdError.Length > 0)
            {
                MessageBox.Show(stdError);
                return null;
            }
            string resultString = process.StandardOutput.ReadToEnd().Split('\r')[0];
            lbl_outArgs.Text = resultString;
            string[] res = resultString.Split(' ');
            return res;
        }

        private void Generate_Click(object sender, EventArgs e)
        {
            string input = tb_generatorIn.Text.ToString();
            string output = tb_generatorOut.Text.ToString();
            string ext = cb_pyExtension.Checked ? ".py" : ".exe";
            string[] result = runProcess("Generator" + ext, input + " " + output);
            if (result == null) return;
            tb_inputPath.Text = output;
        }
    }
}
