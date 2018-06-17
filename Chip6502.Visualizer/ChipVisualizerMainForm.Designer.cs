namespace Chip6502.Visualizer
{
    partial class ChipVisualizerMainForm
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
            this.LoadButton = new System.Windows.Forms.Button();
            this.NegativeFlagCheck = new System.Windows.Forms.CheckBox();
            this.PCNumInput = new System.Windows.Forms.NumericUpDown();
            this.PCMemoryText = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.StackMemoryText = new System.Windows.Forms.RichTextBox();
            this.RunButton = new System.Windows.Forms.Button();
            this.StepButton = new System.Windows.Forms.Button();
            this.SpeedNumInput = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SPNumInput = new System.Windows.Forms.NumericUpDown();
            this.AccNumInput = new System.Windows.Forms.NumericUpDown();
            this.XRegNumInput = new System.Windows.Forms.NumericUpDown();
            this.YRegNumInput = new System.Windows.Forms.NumericUpDown();
            this.OverflowFlagCheck = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.BreakFlagCheck = new System.Windows.Forms.CheckBox();
            this.CarryFlagCheck = new System.Windows.Forms.CheckBox();
            this.ZeroFlagCheck = new System.Windows.Forms.CheckBox();
            this.InterruptFlagCheck = new System.Windows.Forms.CheckBox();
            this.DecimalFlagCheck = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.LastMemoryReadText = new System.Windows.Forms.RichTextBox();
            this.HistoryText = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.ResetButton = new System.Windows.Forms.Button();
            this.BreakPCCheck = new System.Windows.Forms.CheckBox();
            this.BreakPCNumInput = new System.Windows.Forms.NumericUpDown();
            this.BreakMemSetCheck = new System.Windows.Forms.CheckBox();
            this.BreakMemSetNumInput = new System.Windows.Forms.NumericUpDown();
            this.StopButton = new System.Windows.Forms.Button();
            this.LastMemoryWrittenText = new System.Windows.Forms.RichTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.BreakMemReadNumInput = new System.Windows.Forms.NumericUpDown();
            this.BreakMemReadCheck = new System.Windows.Forms.CheckBox();
            this.LimitCheck = new System.Windows.Forms.CheckBox();
            this.NextLineText = new System.Windows.Forms.TextBox();
            this.DecodedText = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.PCNumInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpeedNumInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SPNumInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AccNumInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.XRegNumInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.YRegNumInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BreakPCNumInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BreakMemSetNumInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BreakMemReadNumInput)).BeginInit();
            this.SuspendLayout();
            // 
            // LoadButton
            // 
            this.LoadButton.Location = new System.Drawing.Point(16, 15);
            this.LoadButton.Margin = new System.Windows.Forms.Padding(4);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(235, 28);
            this.LoadButton.TabIndex = 0;
            this.LoadButton.Text = "Load";
            this.LoadButton.UseVisualStyleBackColor = true;
            this.LoadButton.Click += new System.EventHandler(this.LoadButton_Click);
            // 
            // NegativeFlagCheck
            // 
            this.NegativeFlagCheck.AutoSize = true;
            this.NegativeFlagCheck.Location = new System.Drawing.Point(500, 60);
            this.NegativeFlagCheck.Margin = new System.Windows.Forms.Padding(4);
            this.NegativeFlagCheck.Name = "NegativeFlagCheck";
            this.NegativeFlagCheck.Size = new System.Drawing.Size(40, 21);
            this.NegativeFlagCheck.TabIndex = 9;
            this.NegativeFlagCheck.Text = "N";
            this.NegativeFlagCheck.UseVisualStyleBackColor = true;
            this.NegativeFlagCheck.CheckedChanged += new System.EventHandler(this.NegativeFlagCheck_CheckedChanged);
            // 
            // PCNumInput
            // 
            this.PCNumInput.Hexadecimal = true;
            this.PCNumInput.Location = new System.Drawing.Point(56, 57);
            this.PCNumInput.Margin = new System.Windows.Forms.Padding(4);
            this.PCNumInput.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.PCNumInput.Name = "PCNumInput";
            this.PCNumInput.Size = new System.Drawing.Size(85, 22);
            this.PCNumInput.TabIndex = 4;
            this.PCNumInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.PCNumInput.ValueChanged += new System.EventHandler(this.PCNumInput_ValueChanged);
            // 
            // PCMemoryText
            // 
            this.PCMemoryText.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PCMemoryText.Location = new System.Drawing.Point(16, 105);
            this.PCMemoryText.Margin = new System.Windows.Forms.Padding(4);
            this.PCMemoryText.Name = "PCMemoryText";
            this.PCMemoryText.ReadOnly = true;
            this.PCMemoryText.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.PCMemoryText.Size = new System.Drawing.Size(457, 73);
            this.PCMemoryText.TabIndex = 3;
            this.PCMemoryText.TabStop = false;
            this.PCMemoryText.Text = "---- 00 01 02 03 04 05 06 07 08 09 10 0A 0B 0C 0D 0E 0F\n0000\n0001\n0002";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 59);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "PC:";
            // 
            // StackMemoryText
            // 
            this.StackMemoryText.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StackMemoryText.Location = new System.Drawing.Point(16, 230);
            this.StackMemoryText.Margin = new System.Windows.Forms.Padding(4);
            this.StackMemoryText.Name = "StackMemoryText";
            this.StackMemoryText.ReadOnly = true;
            this.StackMemoryText.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.StackMemoryText.Size = new System.Drawing.Size(457, 74);
            this.StackMemoryText.TabIndex = 5;
            this.StackMemoryText.TabStop = false;
            this.StackMemoryText.Text = "---- 00 01 02 03 04 05 06 07 08 09 10 0A 0B 0C 0D 0E 0F\n0000\n0001\n0002";
            // 
            // RunButton
            // 
            this.RunButton.Location = new System.Drawing.Point(492, 117);
            this.RunButton.Margin = new System.Windows.Forms.Padding(4);
            this.RunButton.Name = "RunButton";
            this.RunButton.Size = new System.Drawing.Size(123, 28);
            this.RunButton.TabIndex = 16;
            this.RunButton.Text = "Run";
            this.RunButton.UseVisualStyleBackColor = true;
            this.RunButton.Click += new System.EventHandler(this.RunButton_Click);
            // 
            // StepButton
            // 
            this.StepButton.Location = new System.Drawing.Point(492, 153);
            this.StepButton.Margin = new System.Windows.Forms.Padding(4);
            this.StepButton.Name = "StepButton";
            this.StepButton.Size = new System.Drawing.Size(256, 28);
            this.StepButton.TabIndex = 18;
            this.StepButton.Text = "Step";
            this.StepButton.UseVisualStyleBackColor = true;
            this.StepButton.Click += new System.EventHandler(this.StepButton_Click);
            // 
            // SpeedNumInput
            // 
            this.SpeedNumInput.Location = new System.Drawing.Point(657, 18);
            this.SpeedNumInput.Margin = new System.Windows.Forms.Padding(4);
            this.SpeedNumInput.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.SpeedNumInput.Name = "SpeedNumInput";
            this.SpeedNumInput.Size = new System.Drawing.Size(91, 22);
            this.SpeedNumInput.TabIndex = 3;
            this.SpeedNumInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.SpeedNumInput.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(569, 21);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "Speed (Hz)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 85);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 17);
            this.label3.TabIndex = 12;
            this.label3.Text = "Memory around PC:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 201);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(47, 17);
            this.label4.TabIndex = 13;
            this.label4.Text = "Stack:";
            // 
            // SPNumInput
            // 
            this.SPNumInput.Hexadecimal = true;
            this.SPNumInput.Location = new System.Drawing.Point(64, 198);
            this.SPNumInput.Margin = new System.Windows.Forms.Padding(4);
            this.SPNumInput.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.SPNumInput.Name = "SPNumInput";
            this.SPNumInput.Size = new System.Drawing.Size(85, 22);
            this.SPNumInput.TabIndex = 8;
            this.SPNumInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.SPNumInput.ValueChanged += new System.EventHandler(this.SPNumInput_ValueChanged);
            // 
            // AccNumInput
            // 
            this.AccNumInput.Hexadecimal = true;
            this.AccNumInput.Location = new System.Drawing.Point(201, 57);
            this.AccNumInput.Margin = new System.Windows.Forms.Padding(4);
            this.AccNumInput.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.AccNumInput.Name = "AccNumInput";
            this.AccNumInput.Size = new System.Drawing.Size(49, 22);
            this.AccNumInput.TabIndex = 5;
            this.AccNumInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.AccNumInput.ValueChanged += new System.EventHandler(this.AccNumInput_ValueChanged);
            // 
            // XRegNumInput
            // 
            this.XRegNumInput.Hexadecimal = true;
            this.XRegNumInput.Location = new System.Drawing.Point(295, 57);
            this.XRegNumInput.Margin = new System.Windows.Forms.Padding(4);
            this.XRegNumInput.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.XRegNumInput.Name = "XRegNumInput";
            this.XRegNumInput.Size = new System.Drawing.Size(49, 22);
            this.XRegNumInput.TabIndex = 6;
            this.XRegNumInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.XRegNumInput.ValueChanged += new System.EventHandler(this.XRegNumInput_ValueChanged);
            // 
            // YRegNumInput
            // 
            this.YRegNumInput.Hexadecimal = true;
            this.YRegNumInput.Location = new System.Drawing.Point(391, 57);
            this.YRegNumInput.Margin = new System.Windows.Forms.Padding(4);
            this.YRegNumInput.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.YRegNumInput.Name = "YRegNumInput";
            this.YRegNumInput.Size = new System.Drawing.Size(49, 22);
            this.YRegNumInput.TabIndex = 7;
            this.YRegNumInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.YRegNumInput.ValueChanged += new System.EventHandler(this.YRegNumInput_ValueChanged);
            // 
            // OverflowFlagCheck
            // 
            this.OverflowFlagCheck.AutoSize = true;
            this.OverflowFlagCheck.Location = new System.Drawing.Point(553, 60);
            this.OverflowFlagCheck.Margin = new System.Windows.Forms.Padding(4);
            this.OverflowFlagCheck.Name = "OverflowFlagCheck";
            this.OverflowFlagCheck.Size = new System.Drawing.Size(39, 21);
            this.OverflowFlagCheck.TabIndex = 10;
            this.OverflowFlagCheck.Text = "V";
            this.OverflowFlagCheck.UseVisualStyleBackColor = true;
            this.OverflowFlagCheck.CheckedChanged += new System.EventHandler(this.OverflowFlagCheck_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(171, 59);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 17);
            this.label5.TabIndex = 19;
            this.label5.Text = "A:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(264, 59);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 17);
            this.label6.TabIndex = 20;
            this.label6.Text = "X:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(360, 59);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(21, 17);
            this.label7.TabIndex = 21;
            this.label7.Text = "Y:";
            // 
            // BreakFlagCheck
            // 
            this.BreakFlagCheck.AutoSize = true;
            this.BreakFlagCheck.Location = new System.Drawing.Point(652, 60);
            this.BreakFlagCheck.Margin = new System.Windows.Forms.Padding(4);
            this.BreakFlagCheck.Name = "BreakFlagCheck";
            this.BreakFlagCheck.Size = new System.Drawing.Size(39, 21);
            this.BreakFlagCheck.TabIndex = 11;
            this.BreakFlagCheck.Text = "B";
            this.BreakFlagCheck.UseVisualStyleBackColor = true;
            this.BreakFlagCheck.CheckedChanged += new System.EventHandler(this.BreakFlagCheck_CheckedChanged);
            // 
            // CarryFlagCheck
            // 
            this.CarryFlagCheck.AutoSize = true;
            this.CarryFlagCheck.Location = new System.Drawing.Point(652, 89);
            this.CarryFlagCheck.Margin = new System.Windows.Forms.Padding(4);
            this.CarryFlagCheck.Name = "CarryFlagCheck";
            this.CarryFlagCheck.Size = new System.Drawing.Size(39, 21);
            this.CarryFlagCheck.TabIndex = 15;
            this.CarryFlagCheck.Text = "C";
            this.CarryFlagCheck.UseVisualStyleBackColor = true;
            this.CarryFlagCheck.CheckedChanged += new System.EventHandler(this.CarryFlagCheck_CheckedChanged);
            // 
            // ZeroFlagCheck
            // 
            this.ZeroFlagCheck.AutoSize = true;
            this.ZeroFlagCheck.Location = new System.Drawing.Point(605, 89);
            this.ZeroFlagCheck.Margin = new System.Windows.Forms.Padding(4);
            this.ZeroFlagCheck.Name = "ZeroFlagCheck";
            this.ZeroFlagCheck.Size = new System.Drawing.Size(39, 21);
            this.ZeroFlagCheck.TabIndex = 14;
            this.ZeroFlagCheck.Text = "Z";
            this.ZeroFlagCheck.UseVisualStyleBackColor = true;
            this.ZeroFlagCheck.CheckedChanged += new System.EventHandler(this.ZeroFlagCheck_CheckedChanged);
            // 
            // InterruptFlagCheck
            // 
            this.InterruptFlagCheck.AutoSize = true;
            this.InterruptFlagCheck.Location = new System.Drawing.Point(553, 89);
            this.InterruptFlagCheck.Margin = new System.Windows.Forms.Padding(4);
            this.InterruptFlagCheck.Name = "InterruptFlagCheck";
            this.InterruptFlagCheck.Size = new System.Drawing.Size(33, 21);
            this.InterruptFlagCheck.TabIndex = 13;
            this.InterruptFlagCheck.Text = "I";
            this.InterruptFlagCheck.UseVisualStyleBackColor = true;
            this.InterruptFlagCheck.CheckedChanged += new System.EventHandler(this.InterruptFlagCheck_CheckedChanged);
            // 
            // DecimalFlagCheck
            // 
            this.DecimalFlagCheck.AutoSize = true;
            this.DecimalFlagCheck.Location = new System.Drawing.Point(500, 89);
            this.DecimalFlagCheck.Margin = new System.Windows.Forms.Padding(4);
            this.DecimalFlagCheck.Name = "DecimalFlagCheck";
            this.DecimalFlagCheck.Size = new System.Drawing.Size(40, 21);
            this.DecimalFlagCheck.TabIndex = 12;
            this.DecimalFlagCheck.Text = "D";
            this.DecimalFlagCheck.UseVisualStyleBackColor = true;
            this.DecimalFlagCheck.CheckedChanged += new System.EventHandler(this.DecimalFlagCheck_CheckedChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 325);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(306, 17);
            this.label8.TabIndex = 28;
            this.label8.Text = "Memory around last read before last command:";
            // 
            // LastMemoryReadText
            // 
            this.LastMemoryReadText.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LastMemoryReadText.Location = new System.Drawing.Point(16, 345);
            this.LastMemoryReadText.Margin = new System.Windows.Forms.Padding(4);
            this.LastMemoryReadText.Name = "LastMemoryReadText";
            this.LastMemoryReadText.ReadOnly = true;
            this.LastMemoryReadText.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.LastMemoryReadText.Size = new System.Drawing.Size(457, 106);
            this.LastMemoryReadText.TabIndex = 29;
            this.LastMemoryReadText.TabStop = false;
            this.LastMemoryReadText.Text = "---- 00 01 02 03 04 05 06 07 08 09 10 0A 0B 0C 0D 0E 0F\n0000\n0001\n0002\n0003\n0004\n" +
    "0005\n0006\n0007\n0008\n0009\n000A\n000B\n000C\n000D\n000E\n000F";
            // 
            // HistoryText
            // 
            this.HistoryText.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HistoryText.Location = new System.Drawing.Point(492, 213);
            this.HistoryText.Margin = new System.Windows.Forms.Padding(4);
            this.HistoryText.Multiline = true;
            this.HistoryText.Name = "HistoryText";
            this.HistoryText.ReadOnly = true;
            this.HistoryText.Size = new System.Drawing.Size(255, 184);
            this.HistoryText.TabIndex = 30;
            this.HistoryText.TabStop = false;
            this.HistoryText.Text = "-0B\r\n-0A\r\n-09 ADD 0000\r\n-08\r\n-07\r\n-06\r\n-05\r\n-04\r\n-03\r\n-02\r\n-01\r\nNEXT\r\n+01\r\n+02\r\n+" +
    "03\r\n+04\r\n+05\r\n+06\r\n+07\r\n+08\r\n+09\r\n+0A\r\n+0B";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(488, 193);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(121, 17);
            this.label9.TabIndex = 31;
            this.label9.Text = "Operation history:";
            // 
            // ResetButton
            // 
            this.ResetButton.Location = new System.Drawing.Point(259, 15);
            this.ResetButton.Margin = new System.Windows.Forms.Padding(4);
            this.ResetButton.Name = "ResetButton";
            this.ResetButton.Size = new System.Drawing.Size(216, 28);
            this.ResetButton.TabIndex = 1;
            this.ResetButton.Text = "Reset";
            this.ResetButton.UseVisualStyleBackColor = true;
            this.ResetButton.Click += new System.EventHandler(this.ResetButton_Click);
            // 
            // BreakPCCheck
            // 
            this.BreakPCCheck.AutoSize = true;
            this.BreakPCCheck.Location = new System.Drawing.Point(16, 609);
            this.BreakPCCheck.Margin = new System.Windows.Forms.Padding(4);
            this.BreakPCCheck.Name = "BreakPCCheck";
            this.BreakPCCheck.Size = new System.Drawing.Size(144, 21);
            this.BreakPCCheck.TabIndex = 19;
            this.BreakPCCheck.Text = "Break when PC is:";
            this.BreakPCCheck.UseVisualStyleBackColor = true;
            this.BreakPCCheck.CheckedChanged += new System.EventHandler(this.BreakPCCheck_CheckedChanged);
            // 
            // BreakPCNumInput
            // 
            this.BreakPCNumInput.Hexadecimal = true;
            this.BreakPCNumInput.Location = new System.Drawing.Point(259, 608);
            this.BreakPCNumInput.Margin = new System.Windows.Forms.Padding(4);
            this.BreakPCNumInput.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.BreakPCNumInput.Name = "BreakPCNumInput";
            this.BreakPCNumInput.Size = new System.Drawing.Size(85, 22);
            this.BreakPCNumInput.TabIndex = 20;
            this.BreakPCNumInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.BreakPCNumInput.ValueChanged += new System.EventHandler(this.BreakPCNumInput_ValueChanged);
            // 
            // BreakMemSetCheck
            // 
            this.BreakMemSetCheck.AutoSize = true;
            this.BreakMemSetCheck.Location = new System.Drawing.Point(16, 667);
            this.BreakMemSetCheck.Margin = new System.Windows.Forms.Padding(4);
            this.BreakMemSetCheck.Name = "BreakMemSetCheck";
            this.BreakMemSetCheck.Size = new System.Drawing.Size(237, 21);
            this.BreakMemSetCheck.TabIndex = 23;
            this.BreakMemSetCheck.Text = "Break when Address is changed:";
            this.BreakMemSetCheck.UseVisualStyleBackColor = true;
            this.BreakMemSetCheck.CheckedChanged += new System.EventHandler(this.BreakMemSetCheck_CheckedChanged);
            // 
            // BreakMemSetNumInput
            // 
            this.BreakMemSetNumInput.Hexadecimal = true;
            this.BreakMemSetNumInput.Location = new System.Drawing.Point(259, 666);
            this.BreakMemSetNumInput.Margin = new System.Windows.Forms.Padding(4);
            this.BreakMemSetNumInput.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.BreakMemSetNumInput.Name = "BreakMemSetNumInput";
            this.BreakMemSetNumInput.Size = new System.Drawing.Size(85, 22);
            this.BreakMemSetNumInput.TabIndex = 24;
            this.BreakMemSetNumInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.BreakMemSetNumInput.ValueChanged += new System.EventHandler(this.BreakMemSetNumInput_ValueChanged);
            // 
            // StopButton
            // 
            this.StopButton.Enabled = false;
            this.StopButton.Location = new System.Drawing.Point(623, 117);
            this.StopButton.Margin = new System.Windows.Forms.Padding(4);
            this.StopButton.Name = "StopButton";
            this.StopButton.Size = new System.Drawing.Size(125, 28);
            this.StopButton.TabIndex = 17;
            this.StopButton.Text = "Stop";
            this.StopButton.UseVisualStyleBackColor = true;
            this.StopButton.Click += new System.EventHandler(this.StopButton_Click);
            // 
            // LastMemoryWrittenText
            // 
            this.LastMemoryWrittenText.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LastMemoryWrittenText.Location = new System.Drawing.Point(16, 482);
            this.LastMemoryWrittenText.Margin = new System.Windows.Forms.Padding(4);
            this.LastMemoryWrittenText.Name = "LastMemoryWrittenText";
            this.LastMemoryWrittenText.ReadOnly = true;
            this.LastMemoryWrittenText.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.LastMemoryWrittenText.Size = new System.Drawing.Size(457, 106);
            this.LastMemoryWrittenText.TabIndex = 39;
            this.LastMemoryWrittenText.TabStop = false;
            this.LastMemoryWrittenText.Text = "---- 00 01 02 03 04 05 06 07 08 09 10 0A 0B 0C 0D 0E 0F\n0000\n0001\n0002\n0003\n0004\n" +
    "0005\n0006\n0007\n0008\n0009\n000A\n000B\n000C\n000D\n000E\n000F";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 463);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(306, 17);
            this.label10.TabIndex = 38;
            this.label10.Text = "Memory around last written after last command:";
            // 
            // BreakMemReadNumInput
            // 
            this.BreakMemReadNumInput.Hexadecimal = true;
            this.BreakMemReadNumInput.Location = new System.Drawing.Point(259, 636);
            this.BreakMemReadNumInput.Margin = new System.Windows.Forms.Padding(4);
            this.BreakMemReadNumInput.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.BreakMemReadNumInput.Name = "BreakMemReadNumInput";
            this.BreakMemReadNumInput.Size = new System.Drawing.Size(85, 22);
            this.BreakMemReadNumInput.TabIndex = 22;
            this.BreakMemReadNumInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.BreakMemReadNumInput.ValueChanged += new System.EventHandler(this.BreakMemReadNumInput_ValueChanged);
            // 
            // BreakMemReadCheck
            // 
            this.BreakMemReadCheck.AutoSize = true;
            this.BreakMemReadCheck.Location = new System.Drawing.Point(16, 638);
            this.BreakMemReadCheck.Margin = new System.Windows.Forms.Padding(4);
            this.BreakMemReadCheck.Name = "BreakMemReadCheck";
            this.BreakMemReadCheck.Size = new System.Drawing.Size(211, 21);
            this.BreakMemReadCheck.TabIndex = 21;
            this.BreakMemReadCheck.Text = "Break when Address is read:";
            this.BreakMemReadCheck.UseVisualStyleBackColor = true;
            this.BreakMemReadCheck.CheckedChanged += new System.EventHandler(this.BreakMemReadCheck_CheckedChanged);
            // 
            // LimitCheck
            // 
            this.LimitCheck.AutoSize = true;
            this.LimitCheck.Location = new System.Drawing.Point(500, 18);
            this.LimitCheck.Margin = new System.Windows.Forms.Padding(4);
            this.LimitCheck.Name = "LimitCheck";
            this.LimitCheck.Size = new System.Drawing.Size(63, 21);
            this.LimitCheck.TabIndex = 2;
            this.LimitCheck.Text = "Limit:";
            this.LimitCheck.UseVisualStyleBackColor = true;
            // 
            // NextLineText
            // 
            this.NextLineText.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NextLineText.Location = new System.Drawing.Point(492, 421);
            this.NextLineText.Margin = new System.Windows.Forms.Padding(4);
            this.NextLineText.Name = "NextLineText";
            this.NextLineText.ReadOnly = true;
            this.NextLineText.Size = new System.Drawing.Size(255, 24);
            this.NextLineText.TabIndex = 43;
            this.NextLineText.TabStop = false;
            this.NextLineText.Text = "-0B\r\n-0A\r\n-09 ADD 0000\r\n-08\r\n-07\r\n-06\r\n-05\r\n-04\r\n-03\r\n-02\r\n-01\r\nNEXT\r\n+01\r\n+02\r\n+" +
    "03\r\n+04\r\n+05\r\n+06\r\n+07\r\n+08\r\n+09\r\n+0A\r\n+0B";
            // 
            // DecodedText
            // 
            this.DecodedText.Font = new System.Drawing.Font("Consolas", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DecodedText.Location = new System.Drawing.Point(492, 469);
            this.DecodedText.Margin = new System.Windows.Forms.Padding(4);
            this.DecodedText.Multiline = true;
            this.DecodedText.Name = "DecodedText";
            this.DecodedText.ReadOnly = true;
            this.DecodedText.Size = new System.Drawing.Size(255, 184);
            this.DecodedText.TabIndex = 44;
            this.DecodedText.TabStop = false;
            this.DecodedText.Text = "-0B\r\n-0A\r\n-09 ADD 0000\r\n-08\r\n-07\r\n-06\r\n-05\r\n-04\r\n-03\r\n-02\r\n-01\r\nNEXT\r\n+01\r\n+02\r\n+" +
    "03\r\n+04\r\n+05\r\n+06\r\n+07\r\n+08\r\n+09\r\n+0A\r\n+0B";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(488, 401);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(40, 17);
            this.label11.TabIndex = 45;
            this.label11.Text = "Next:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(488, 449);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(137, 17);
            this.label12.TabIndex = 46;
            this.label12.Text = "Operations after PC:";
            // 
            // ChipVisualizerMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 699);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.DecodedText);
            this.Controls.Add(this.NextLineText);
            this.Controls.Add(this.LimitCheck);
            this.Controls.Add(this.BreakMemReadNumInput);
            this.Controls.Add(this.BreakMemReadCheck);
            this.Controls.Add(this.LastMemoryWrittenText);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.StopButton);
            this.Controls.Add(this.BreakMemSetNumInput);
            this.Controls.Add(this.BreakMemSetCheck);
            this.Controls.Add(this.BreakPCNumInput);
            this.Controls.Add(this.BreakPCCheck);
            this.Controls.Add(this.ResetButton);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.HistoryText);
            this.Controls.Add(this.LastMemoryReadText);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.CarryFlagCheck);
            this.Controls.Add(this.ZeroFlagCheck);
            this.Controls.Add(this.InterruptFlagCheck);
            this.Controls.Add(this.DecimalFlagCheck);
            this.Controls.Add(this.BreakFlagCheck);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.OverflowFlagCheck);
            this.Controls.Add(this.YRegNumInput);
            this.Controls.Add(this.XRegNumInput);
            this.Controls.Add(this.AccNumInput);
            this.Controls.Add(this.SPNumInput);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SpeedNumInput);
            this.Controls.Add(this.StepButton);
            this.Controls.Add(this.RunButton);
            this.Controls.Add(this.StackMemoryText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PCMemoryText);
            this.Controls.Add(this.PCNumInput);
            this.Controls.Add(this.NegativeFlagCheck);
            this.Controls.Add(this.LoadButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "ChipVisualizerMainForm";
            this.Text = "Chip 6502 Emulator Visualizer";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PCNumInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SpeedNumInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SPNumInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AccNumInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.XRegNumInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.YRegNumInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BreakPCNumInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BreakMemSetNumInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BreakMemReadNumInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button LoadButton;
        private System.Windows.Forms.CheckBox NegativeFlagCheck;
        private System.Windows.Forms.NumericUpDown PCNumInput;
        private System.Windows.Forms.RichTextBox PCMemoryText;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox StackMemoryText;
        private System.Windows.Forms.Button RunButton;
        private System.Windows.Forms.Button StepButton;
        private System.Windows.Forms.NumericUpDown SpeedNumInput;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown SPNumInput;
        private System.Windows.Forms.NumericUpDown AccNumInput;
        private System.Windows.Forms.NumericUpDown XRegNumInput;
        private System.Windows.Forms.NumericUpDown YRegNumInput;
        private System.Windows.Forms.CheckBox OverflowFlagCheck;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox BreakFlagCheck;
        private System.Windows.Forms.CheckBox CarryFlagCheck;
        private System.Windows.Forms.CheckBox ZeroFlagCheck;
        private System.Windows.Forms.CheckBox InterruptFlagCheck;
        private System.Windows.Forms.CheckBox DecimalFlagCheck;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RichTextBox LastMemoryReadText;
        private System.Windows.Forms.TextBox HistoryText;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button ResetButton;
        private System.Windows.Forms.CheckBox BreakPCCheck;
        private System.Windows.Forms.NumericUpDown BreakPCNumInput;
        private System.Windows.Forms.CheckBox BreakMemSetCheck;
        private System.Windows.Forms.NumericUpDown BreakMemSetNumInput;
        private System.Windows.Forms.Button StopButton;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown BreakMemReadNumInput;
        private System.Windows.Forms.CheckBox BreakMemReadCheck;
        private System.Windows.Forms.RichTextBox LastMemoryWrittenText;
        private System.Windows.Forms.CheckBox LimitCheck;
        private System.Windows.Forms.TextBox NextLineText;
        private System.Windows.Forms.TextBox DecodedText;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
    }
}

