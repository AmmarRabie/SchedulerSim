namespace SchedulingSim
{
    partial class MainForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_run = new System.Windows.Forms.Button();
            this.tb_quantum = new System.Windows.Forms.TextBox();
            this.lbl_inputPath = new System.Windows.Forms.Label();
            this.btn_browse = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.tb_st = new System.Windows.Forms.TextBox();
            this.Generate = new System.Windows.Forms.Button();
            this.pb_graph = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_avgTAT = new System.Windows.Forms.Label();
            this.lbl_avgWTAT = new System.Windows.Forms.Label();
            this.lbl_outArgs = new System.Windows.Forms.Label();
            this.tb_generatorIn = new System.Windows.Forms.TextBox();
            this.tb_generatorOut = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_inputPath = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cb_pyExtension = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pb_graph)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_run
            // 
            this.btn_run.Location = new System.Drawing.Point(12, 30);
            this.btn_run.Name = "btn_run";
            this.btn_run.Size = new System.Drawing.Size(75, 52);
            this.btn_run.TabIndex = 0;
            this.btn_run.Text = "Run";
            this.btn_run.UseVisualStyleBackColor = true;
            this.btn_run.Click += new System.EventHandler(this.btn_run_Click);
            // 
            // tb_quantum
            // 
            this.tb_quantum.Location = new System.Drawing.Point(202, 82);
            this.tb_quantum.Name = "tb_quantum";
            this.tb_quantum.Size = new System.Drawing.Size(100, 22);
            this.tb_quantum.TabIndex = 2;
            this.tb_quantum.Text = "Q";
            // 
            // lbl_inputPath
            // 
            this.lbl_inputPath.AutoSize = true;
            this.lbl_inputPath.Location = new System.Drawing.Point(12, 9);
            this.lbl_inputPath.Name = "lbl_inputPath";
            this.lbl_inputPath.Size = new System.Drawing.Size(484, 17);
            this.lbl_inputPath.TabIndex = 4;
            this.lbl_inputPath.Text = "check this to run the program faster from python script named Scheduler.py";
            // 
            // btn_browse
            // 
            this.btn_browse.Location = new System.Drawing.Point(775, 42);
            this.btn_browse.Name = "btn_browse";
            this.btn_browse.Size = new System.Drawing.Size(62, 26);
            this.btn_browse.TabIndex = 5;
            this.btn_browse.Text = "Browse";
            this.btn_browse.UseVisualStyleBackColor = true;
            this.btn_browse.Click += new System.EventHandler(this.btn_browse_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "arguments";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(96, 44);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 24);
            this.comboBox1.TabIndex = 8;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.onSelctionChanged);
            // 
            // tb_st
            // 
            this.tb_st.Location = new System.Drawing.Point(96, 82);
            this.tb_st.Name = "tb_st";
            this.tb_st.Size = new System.Drawing.Size(100, 22);
            this.tb_st.TabIndex = 9;
            this.tb_st.Text = "switching time";
            // 
            // Generate
            // 
            this.Generate.Location = new System.Drawing.Point(20, 78);
            this.Generate.Name = "Generate";
            this.Generate.Size = new System.Drawing.Size(152, 43);
            this.Generate.TabIndex = 10;
            this.Generate.Text = "Generate random";
            this.Generate.UseVisualStyleBackColor = true;
            this.Generate.Click += new System.EventHandler(this.Generate_Click);
            // 
            // pb_graph
            // 
            this.pb_graph.Location = new System.Drawing.Point(12, 160);
            this.pb_graph.Name = "pb_graph";
            this.pb_graph.Size = new System.Drawing.Size(1080, 371);
            this.pb_graph.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pb_graph.TabIndex = 11;
            this.pb_graph.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 553);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(99, 17);
            this.label2.TabIndex = 12;
            this.label2.Text = "average TAT: ";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(475, 553);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 17);
            this.label3.TabIndex = 13;
            this.label3.Text = "average WTAT: ";
            // 
            // lbl_avgTAT
            // 
            this.lbl_avgTAT.AutoSize = true;
            this.lbl_avgTAT.Location = new System.Drawing.Point(118, 553);
            this.lbl_avgTAT.Name = "lbl_avgTAT";
            this.lbl_avgTAT.Size = new System.Drawing.Size(42, 17);
            this.lbl_avgTAT.TabIndex = 14;
            this.lbl_avgTAT.Text = "None";
            // 
            // lbl_avgWTAT
            // 
            this.lbl_avgWTAT.AutoSize = true;
            this.lbl_avgWTAT.Location = new System.Drawing.Point(593, 553);
            this.lbl_avgWTAT.Name = "lbl_avgWTAT";
            this.lbl_avgWTAT.Size = new System.Drawing.Size(42, 17);
            this.lbl_avgWTAT.TabIndex = 15;
            this.lbl_avgWTAT.Text = "None";
            // 
            // lbl_outArgs
            // 
            this.lbl_outArgs.AutoSize = true;
            this.lbl_outArgs.Location = new System.Drawing.Point(12, 581);
            this.lbl_outArgs.Name = "lbl_outArgs";
            this.lbl_outArgs.Size = new System.Drawing.Size(42, 17);
            this.lbl_outArgs.TabIndex = 16;
            this.lbl_outArgs.Text = "None";
            // 
            // tb_generatorIn
            // 
            this.tb_generatorIn.Location = new System.Drawing.Point(972, 33);
            this.tb_generatorIn.Name = "tb_generatorIn";
            this.tb_generatorIn.Size = new System.Drawing.Size(100, 22);
            this.tb_generatorIn.TabIndex = 17;
            this.tb_generatorIn.Text = "generator.in";
            // 
            // tb_generatorOut
            // 
            this.tb_generatorOut.Location = new System.Drawing.Point(63, 50);
            this.tb_generatorOut.Name = "tb_generatorOut";
            this.tb_generatorOut.Size = new System.Drawing.Size(100, 22);
            this.tb_generatorOut.TabIndex = 18;
            this.tb_generatorOut.Text = "generator.out";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(936, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 17);
            this.label4.TabIndex = 19;
            this.label4.Text = "in";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(27, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(28, 17);
            this.label5.TabIndex = 20;
            this.label5.Text = "out";
            // 
            // tb_inputPath
            // 
            this.tb_inputPath.Location = new System.Drawing.Point(314, 44);
            this.tb_inputPath.Name = "tb_inputPath";
            this.tb_inputPath.Size = new System.Drawing.Size(467, 22);
            this.tb_inputPath.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(223, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 17);
            this.label6.TabIndex = 22;
            this.label6.Text = "with input file";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.tb_generatorOut);
            this.groupBox1.Controls.Add(this.Generate);
            this.groupBox1.Location = new System.Drawing.Point(909, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(209, 139);
            this.groupBox1.TabIndex = 23;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Generator";
            // 
            // cb_pyExtension
            // 
            this.cb_pyExtension.AutoSize = true;
            this.cb_pyExtension.Location = new System.Drawing.Point(502, 8);
            this.cb_pyExtension.Name = "cb_pyExtension";
            this.cb_pyExtension.Size = new System.Drawing.Size(49, 21);
            this.cb_pyExtension.TabIndex = 24;
            this.cb_pyExtension.Text = ".py";
            this.cb_pyExtension.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1121, 617);
            this.Controls.Add(this.cb_pyExtension);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btn_browse);
            this.Controls.Add(this.tb_inputPath);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tb_generatorIn);
            this.Controls.Add(this.lbl_outArgs);
            this.Controls.Add(this.lbl_avgWTAT);
            this.Controls.Add(this.lbl_avgTAT);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pb_graph);
            this.Controls.Add(this.tb_st);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_inputPath);
            this.Controls.Add(this.tb_quantum);
            this.Controls.Add(this.btn_run);
            this.Controls.Add(this.groupBox1);
            this.Name = "MainForm";
            this.Text = "GUI for scheduler solver and generator";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pb_graph)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_run;
        private System.Windows.Forms.TextBox tb_quantum;
        private System.Windows.Forms.Label lbl_inputPath;
        private System.Windows.Forms.Button btn_browse;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox tb_st;
        private System.Windows.Forms.Button Generate;
        private System.Windows.Forms.PictureBox pb_graph;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_avgTAT;
        private System.Windows.Forms.Label lbl_avgWTAT;
        private System.Windows.Forms.Label lbl_outArgs;
        private System.Windows.Forms.TextBox tb_generatorIn;
        private System.Windows.Forms.TextBox tb_generatorOut;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_inputPath;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox cb_pyExtension;
    }
}

