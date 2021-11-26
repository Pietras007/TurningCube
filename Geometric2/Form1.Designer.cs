
namespace Geometric2
{
    partial class Form1
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
            this.glControl1 = new OpenTK.GLControl();
            this.loadModelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip2 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cameraLightCheckBox = new System.Windows.Forms.CheckBox();
            this.startSimulationButton = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.displayWallsCheckBox = new System.Windows.Forms.CheckBox();
            this.applyConditionsButton = new System.Windows.Forms.Button();
            this.integrationStepNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.angularVelocityNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.cubeDeviationNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.cubeDensityNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.cubeEdgeLengthNumericUpDown = new System.Windows.Forms.NumericUpDown();
            this.integrationstepLabel = new System.Windows.Forms.Label();
            this.angularVelocityLabel = new System.Windows.Forms.Label();
            this.cubeDeviationLabel = new System.Windows.Forms.Label();
            this.cubeDensityLabel = new System.Windows.Forms.Label();
            this.pathLengthUpDown = new System.Windows.Forms.NumericUpDown();
            this.displayPlaneCheckBox = new System.Windows.Forms.CheckBox();
            this.displayDiagonalCheckBox = new System.Windows.Forms.CheckBox();
            this.displayPathCheckBox = new System.Windows.Forms.CheckBox();
            this.displayCubeCheckBox = new System.Windows.Forms.CheckBox();
            this.pathLengthLabel = new System.Windows.Forms.Label();
            this.cubeEdgeLengthLabel = new System.Windows.Forms.Label();
            this.gravityOnCheckBox = new System.Windows.Forms.CheckBox();
            this.otherLabel = new System.Windows.Forms.Label();
            this.visualizationLabel = new System.Windows.Forms.Label();
            this.initialConditionsLabel = new System.Windows.Forms.Label();
            this.endSimulationButton = new System.Windows.Forms.Button();
            this.menuStrip2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.integrationStepNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.angularVelocityNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cubeDeviationNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cubeDensityNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cubeEdgeLengthNumericUpDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pathLengthUpDown)).BeginInit();
            this.SuspendLayout();
            // 
            // glControl1
            // 
            this.glControl1.BackColor = System.Drawing.Color.Black;
            this.glControl1.Location = new System.Drawing.Point(12, 24);
            this.glControl1.Name = "glControl1";
            this.glControl1.Size = new System.Drawing.Size(1280, 896);
            this.glControl1.TabIndex = 0;
            this.glControl1.VSync = false;
            this.glControl1.Load += new System.EventHandler(this.glControl1_Load);
            this.glControl1.Paint += new System.Windows.Forms.PaintEventHandler(this.glControl1_Paint);
            this.glControl1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.glControl1_KeyDown);
            this.glControl1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.glControl1_KeyPress);
            this.glControl1.KeyUp += new System.Windows.Forms.KeyEventHandler(this.glControl1_KeyUp);
            this.glControl1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.glControl1_MouseDown);
            this.glControl1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.glControl1_MouseMove);
            this.glControl1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.glControl1_MouseUp);
            this.glControl1.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.glControl1_PreviewKeyDown);
            // 
            // loadModelToolStripMenuItem
            // 
            this.loadModelToolStripMenuItem.Name = "loadModelToolStripMenuItem";
            this.loadModelToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // menuStrip2
            // 
            this.menuStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip2.Location = new System.Drawing.Point(0, 0);
            this.menuStrip2.Name = "menuStrip2";
            this.menuStrip2.Size = new System.Drawing.Size(1562, 24);
            this.menuStrip2.TabIndex = 2;
            this.menuStrip2.Text = "menuStrip2";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.clearToolStripMenuItem,
            this.loadToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(101, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(101, 22);
            this.clearToolStripMenuItem.Text = "Clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(101, 22);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // cameraLightCheckBox
            // 
            this.cameraLightCheckBox.AutoSize = true;
            this.cameraLightCheckBox.Location = new System.Drawing.Point(134, 588);
            this.cameraLightCheckBox.Name = "cameraLightCheckBox";
            this.cameraLightCheckBox.Size = new System.Drawing.Size(88, 17);
            this.cameraLightCheckBox.TabIndex = 4;
            this.cameraLightCheckBox.Text = "Camera Light";
            this.cameraLightCheckBox.UseVisualStyleBackColor = true;
            this.cameraLightCheckBox.CheckedChanged += new System.EventHandler(this.cameraLightCheckBox_CheckedChanged);
            // 
            // startSimulationButton
            // 
            this.startSimulationButton.Location = new System.Drawing.Point(21, 22);
            this.startSimulationButton.Name = "startSimulationButton";
            this.startSimulationButton.Size = new System.Drawing.Size(98, 53);
            this.startSimulationButton.TabIndex = 5;
            this.startSimulationButton.Text = "Start Simulation";
            this.startSimulationButton.UseVisualStyleBackColor = true;
            this.startSimulationButton.Click += new System.EventHandler(this.startSimulationButton_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.displayWallsCheckBox);
            this.panel1.Controls.Add(this.applyConditionsButton);
            this.panel1.Controls.Add(this.integrationStepNumericUpDown);
            this.panel1.Controls.Add(this.angularVelocityNumericUpDown);
            this.panel1.Controls.Add(this.cubeDeviationNumericUpDown);
            this.panel1.Controls.Add(this.cubeDensityNumericUpDown);
            this.panel1.Controls.Add(this.cubeEdgeLengthNumericUpDown);
            this.panel1.Controls.Add(this.integrationstepLabel);
            this.panel1.Controls.Add(this.angularVelocityLabel);
            this.panel1.Controls.Add(this.cubeDeviationLabel);
            this.panel1.Controls.Add(this.cubeDensityLabel);
            this.panel1.Controls.Add(this.pathLengthUpDown);
            this.panel1.Controls.Add(this.displayPlaneCheckBox);
            this.panel1.Controls.Add(this.displayDiagonalCheckBox);
            this.panel1.Controls.Add(this.displayPathCheckBox);
            this.panel1.Controls.Add(this.displayCubeCheckBox);
            this.panel1.Controls.Add(this.pathLengthLabel);
            this.panel1.Controls.Add(this.cubeEdgeLengthLabel);
            this.panel1.Controls.Add(this.gravityOnCheckBox);
            this.panel1.Controls.Add(this.otherLabel);
            this.panel1.Controls.Add(this.visualizationLabel);
            this.panel1.Controls.Add(this.initialConditionsLabel);
            this.panel1.Controls.Add(this.endSimulationButton);
            this.panel1.Controls.Add(this.startSimulationButton);
            this.panel1.Controls.Add(this.cameraLightCheckBox);
            this.panel1.Location = new System.Drawing.Point(1298, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(252, 885);
            this.panel1.TabIndex = 6;
            // 
            // displayWallsCheckBox
            // 
            this.displayWallsCheckBox.AutoSize = true;
            this.displayWallsCheckBox.Checked = true;
            this.displayWallsCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.displayWallsCheckBox.Location = new System.Drawing.Point(21, 492);
            this.displayWallsCheckBox.Name = "displayWallsCheckBox";
            this.displayWallsCheckBox.Size = new System.Drawing.Size(117, 17);
            this.displayWallsCheckBox.TabIndex = 28;
            this.displayWallsCheckBox.Text = "Display Cube Walls";
            this.displayWallsCheckBox.UseVisualStyleBackColor = true;
            this.displayWallsCheckBox.CheckedChanged += new System.EventHandler(this.displayWallsCheckBox_CheckedChanged);
            // 
            // applyConditionsButton
            // 
            this.applyConditionsButton.Location = new System.Drawing.Point(21, 339);
            this.applyConditionsButton.Name = "applyConditionsButton";
            this.applyConditionsButton.Size = new System.Drawing.Size(215, 34);
            this.applyConditionsButton.TabIndex = 27;
            this.applyConditionsButton.Text = "Apply Conditions";
            this.applyConditionsButton.UseVisualStyleBackColor = true;
            this.applyConditionsButton.Click += new System.EventHandler(this.applyConditionsButton_Click);
            // 
            // integrationStepNumericUpDown
            // 
            this.integrationStepNumericUpDown.DecimalPlaces = 5;
            this.integrationStepNumericUpDown.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.integrationStepNumericUpDown.Location = new System.Drawing.Point(123, 294);
            this.integrationStepNumericUpDown.Maximum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.integrationStepNumericUpDown.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            327680});
            this.integrationStepNumericUpDown.Name = "integrationStepNumericUpDown";
            this.integrationStepNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.integrationStepNumericUpDown.TabIndex = 26;
            this.integrationStepNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.integrationStepNumericUpDown.ValueChanged += new System.EventHandler(this.integrationStepNumericUpDown_ValueChanged);
            // 
            // angularVelocityNumericUpDown
            // 
            this.angularVelocityNumericUpDown.DecimalPlaces = 2;
            this.angularVelocityNumericUpDown.Location = new System.Drawing.Point(123, 256);
            this.angularVelocityNumericUpDown.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.angularVelocityNumericUpDown.Name = "angularVelocityNumericUpDown";
            this.angularVelocityNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.angularVelocityNumericUpDown.TabIndex = 25;
            this.angularVelocityNumericUpDown.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.angularVelocityNumericUpDown.ValueChanged += new System.EventHandler(this.angularVelocityNumericUpDown_ValueChanged);
            // 
            // cubeDeviationNumericUpDown
            // 
            this.cubeDeviationNumericUpDown.DecimalPlaces = 2;
            this.cubeDeviationNumericUpDown.Location = new System.Drawing.Point(123, 214);
            this.cubeDeviationNumericUpDown.Maximum = new decimal(new int[] {
            360,
            0,
            0,
            0});
            this.cubeDeviationNumericUpDown.Name = "cubeDeviationNumericUpDown";
            this.cubeDeviationNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.cubeDeviationNumericUpDown.TabIndex = 24;
            this.cubeDeviationNumericUpDown.Value = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.cubeDeviationNumericUpDown.ValueChanged += new System.EventHandler(this.cubeDeviationNumericUpDown_ValueChanged);
            // 
            // cubeDensityNumericUpDown
            // 
            this.cubeDensityNumericUpDown.DecimalPlaces = 2;
            this.cubeDensityNumericUpDown.Location = new System.Drawing.Point(123, 173);
            this.cubeDensityNumericUpDown.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.cubeDensityNumericUpDown.Name = "cubeDensityNumericUpDown";
            this.cubeDensityNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.cubeDensityNumericUpDown.TabIndex = 23;
            this.cubeDensityNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.cubeDensityNumericUpDown.ValueChanged += new System.EventHandler(this.cubeDensityNumericUpDown_ValueChanged);
            // 
            // cubeEdgeLengthNumericUpDown
            // 
            this.cubeEdgeLengthNumericUpDown.DecimalPlaces = 2;
            this.cubeEdgeLengthNumericUpDown.Location = new System.Drawing.Point(123, 136);
            this.cubeEdgeLengthNumericUpDown.Name = "cubeEdgeLengthNumericUpDown";
            this.cubeEdgeLengthNumericUpDown.Size = new System.Drawing.Size(120, 20);
            this.cubeEdgeLengthNumericUpDown.TabIndex = 22;
            this.cubeEdgeLengthNumericUpDown.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.cubeEdgeLengthNumericUpDown.ValueChanged += new System.EventHandler(this.cubeEdgeLengthNumericUpDown_ValueChanged);
            // 
            // integrationstepLabel
            // 
            this.integrationstepLabel.AutoSize = true;
            this.integrationstepLabel.Location = new System.Drawing.Point(18, 296);
            this.integrationstepLabel.Name = "integrationstepLabel";
            this.integrationstepLabel.Size = new System.Drawing.Size(85, 13);
            this.integrationstepLabel.TabIndex = 21;
            this.integrationstepLabel.Text = "Integration Step:";
            // 
            // angularVelocityLabel
            // 
            this.angularVelocityLabel.AutoSize = true;
            this.angularVelocityLabel.Location = new System.Drawing.Point(18, 258);
            this.angularVelocityLabel.Name = "angularVelocityLabel";
            this.angularVelocityLabel.Size = new System.Drawing.Size(86, 13);
            this.angularVelocityLabel.TabIndex = 20;
            this.angularVelocityLabel.Text = "Angular Velocity:";
            // 
            // cubeDeviationLabel
            // 
            this.cubeDeviationLabel.AutoSize = true;
            this.cubeDeviationLabel.Location = new System.Drawing.Point(18, 216);
            this.cubeDeviationLabel.Name = "cubeDeviationLabel";
            this.cubeDeviationLabel.Size = new System.Drawing.Size(83, 13);
            this.cubeDeviationLabel.TabIndex = 19;
            this.cubeDeviationLabel.Text = "Cube Deviation:";
            // 
            // cubeDensityLabel
            // 
            this.cubeDensityLabel.AutoSize = true;
            this.cubeDensityLabel.Location = new System.Drawing.Point(18, 175);
            this.cubeDensityLabel.Name = "cubeDensityLabel";
            this.cubeDensityLabel.Size = new System.Drawing.Size(70, 13);
            this.cubeDensityLabel.TabIndex = 18;
            this.cubeDensityLabel.Text = "CubeDensity:";
            // 
            // pathLengthUpDown
            // 
            this.pathLengthUpDown.Location = new System.Drawing.Point(112, 425);
            this.pathLengthUpDown.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.pathLengthUpDown.Name = "pathLengthUpDown";
            this.pathLengthUpDown.Size = new System.Drawing.Size(120, 20);
            this.pathLengthUpDown.TabIndex = 17;
            this.pathLengthUpDown.Value = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.pathLengthUpDown.ValueChanged += new System.EventHandler(this.pathLengthUpDown_ValueChanged);
            // 
            // displayPlaneCheckBox
            // 
            this.displayPlaneCheckBox.AutoSize = true;
            this.displayPlaneCheckBox.Checked = true;
            this.displayPlaneCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.displayPlaneCheckBox.Location = new System.Drawing.Point(146, 492);
            this.displayPlaneCheckBox.Name = "displayPlaneCheckBox";
            this.displayPlaneCheckBox.Size = new System.Drawing.Size(90, 17);
            this.displayPlaneCheckBox.TabIndex = 16;
            this.displayPlaneCheckBox.Text = "Display Plane";
            this.displayPlaneCheckBox.UseVisualStyleBackColor = true;
            this.displayPlaneCheckBox.CheckedChanged += new System.EventHandler(this.displayPlaneCheckBox_CheckedChanged);
            // 
            // displayDiagonalCheckBox
            // 
            this.displayDiagonalCheckBox.AutoSize = true;
            this.displayDiagonalCheckBox.Checked = true;
            this.displayDiagonalCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.displayDiagonalCheckBox.Location = new System.Drawing.Point(21, 515);
            this.displayDiagonalCheckBox.Name = "displayDiagonalCheckBox";
            this.displayDiagonalCheckBox.Size = new System.Drawing.Size(105, 17);
            this.displayDiagonalCheckBox.TabIndex = 15;
            this.displayDiagonalCheckBox.Text = "Display Diagonal";
            this.displayDiagonalCheckBox.UseVisualStyleBackColor = true;
            this.displayDiagonalCheckBox.CheckedChanged += new System.EventHandler(this.displayDiagonalCheckBox_CheckedChanged);
            // 
            // displayPathCheckBox
            // 
            this.displayPathCheckBox.AutoSize = true;
            this.displayPathCheckBox.Checked = true;
            this.displayPathCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.displayPathCheckBox.Location = new System.Drawing.Point(146, 469);
            this.displayPathCheckBox.Name = "displayPathCheckBox";
            this.displayPathCheckBox.Size = new System.Drawing.Size(85, 17);
            this.displayPathCheckBox.TabIndex = 14;
            this.displayPathCheckBox.Text = "Display Path";
            this.displayPathCheckBox.UseVisualStyleBackColor = true;
            this.displayPathCheckBox.CheckedChanged += new System.EventHandler(this.displayPathCheckBox_CheckedChanged);
            // 
            // displayCubeCheckBox
            // 
            this.displayCubeCheckBox.AutoSize = true;
            this.displayCubeCheckBox.Checked = true;
            this.displayCubeCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.displayCubeCheckBox.Location = new System.Drawing.Point(21, 469);
            this.displayCubeCheckBox.Name = "displayCubeCheckBox";
            this.displayCubeCheckBox.Size = new System.Drawing.Size(121, 17);
            this.displayCubeCheckBox.TabIndex = 13;
            this.displayCubeCheckBox.Text = "Display Cube Edges";
            this.displayCubeCheckBox.UseVisualStyleBackColor = true;
            this.displayCubeCheckBox.CheckedChanged += new System.EventHandler(this.displayCubeCheckBox_CheckedChanged);
            // 
            // pathLengthLabel
            // 
            this.pathLengthLabel.AutoSize = true;
            this.pathLengthLabel.Location = new System.Drawing.Point(18, 427);
            this.pathLengthLabel.Name = "pathLengthLabel";
            this.pathLengthLabel.Size = new System.Drawing.Size(68, 13);
            this.pathLengthLabel.TabIndex = 12;
            this.pathLengthLabel.Text = "Path Length:";
            // 
            // cubeEdgeLengthLabel
            // 
            this.cubeEdgeLengthLabel.AutoSize = true;
            this.cubeEdgeLengthLabel.Location = new System.Drawing.Point(18, 138);
            this.cubeEdgeLengthLabel.Name = "cubeEdgeLengthLabel";
            this.cubeEdgeLengthLabel.Size = new System.Drawing.Size(99, 13);
            this.cubeEdgeLengthLabel.TabIndex = 11;
            this.cubeEdgeLengthLabel.Text = "Cube Edge Length:";
            // 
            // gravityOnCheckBox
            // 
            this.gravityOnCheckBox.AutoSize = true;
            this.gravityOnCheckBox.Location = new System.Drawing.Point(21, 588);
            this.gravityOnCheckBox.Name = "gravityOnCheckBox";
            this.gravityOnCheckBox.Size = new System.Drawing.Size(76, 17);
            this.gravityOnCheckBox.TabIndex = 10;
            this.gravityOnCheckBox.Text = "Gravity On";
            this.gravityOnCheckBox.UseVisualStyleBackColor = true;
            this.gravityOnCheckBox.CheckedChanged += new System.EventHandler(this.gravityOnCheckBox_CheckedChanged);
            // 
            // otherLabel
            // 
            this.otherLabel.AutoSize = true;
            this.otherLabel.Location = new System.Drawing.Point(99, 543);
            this.otherLabel.Name = "otherLabel";
            this.otherLabel.Size = new System.Drawing.Size(48, 13);
            this.otherLabel.TabIndex = 9;
            this.otherLabel.Text = "OTHER:";
            // 
            // visualizationLabel
            // 
            this.visualizationLabel.AutoSize = true;
            this.visualizationLabel.Location = new System.Drawing.Point(79, 395);
            this.visualizationLabel.Name = "visualizationLabel";
            this.visualizationLabel.Size = new System.Drawing.Size(91, 13);
            this.visualizationLabel.TabIndex = 8;
            this.visualizationLabel.Text = "VISUALIZATION:";
            // 
            // initialConditionsLabel
            // 
            this.initialConditionsLabel.AutoSize = true;
            this.initialConditionsLabel.Location = new System.Drawing.Point(65, 108);
            this.initialConditionsLabel.Name = "initialConditionsLabel";
            this.initialConditionsLabel.Size = new System.Drawing.Size(117, 13);
            this.initialConditionsLabel.TabIndex = 7;
            this.initialConditionsLabel.Text = "INITIAL CONDITIONS:";
            // 
            // endSimulationButton
            // 
            this.endSimulationButton.Enabled = false;
            this.endSimulationButton.Location = new System.Drawing.Point(134, 22);
            this.endSimulationButton.Name = "endSimulationButton";
            this.endSimulationButton.Size = new System.Drawing.Size(98, 53);
            this.endSimulationButton.TabIndex = 6;
            this.endSimulationButton.Text = "End Simulation";
            this.endSimulationButton.UseVisualStyleBackColor = true;
            this.endSimulationButton.Click += new System.EventHandler(this.endSimulationButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1562, 932);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.glControl1);
            this.Controls.Add(this.menuStrip2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip2.ResumeLayout(false);
            this.menuStrip2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.integrationStepNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.angularVelocityNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cubeDeviationNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cubeDensityNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cubeEdgeLengthNumericUpDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pathLengthUpDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private OpenTK.GLControl glControl1;
        private System.Windows.Forms.ToolStripMenuItem loadModelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip2;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.CheckBox cameraLightCheckBox;
        private System.Windows.Forms.Button startSimulationButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label integrationstepLabel;
        private System.Windows.Forms.Label angularVelocityLabel;
        private System.Windows.Forms.Label cubeDeviationLabel;
        private System.Windows.Forms.Label cubeDensityLabel;
        private System.Windows.Forms.NumericUpDown pathLengthUpDown;
        private System.Windows.Forms.CheckBox displayPlaneCheckBox;
        private System.Windows.Forms.CheckBox displayDiagonalCheckBox;
        private System.Windows.Forms.CheckBox displayPathCheckBox;
        private System.Windows.Forms.CheckBox displayCubeCheckBox;
        private System.Windows.Forms.Label pathLengthLabel;
        private System.Windows.Forms.Label cubeEdgeLengthLabel;
        private System.Windows.Forms.CheckBox gravityOnCheckBox;
        private System.Windows.Forms.Label otherLabel;
        private System.Windows.Forms.Label visualizationLabel;
        private System.Windows.Forms.Label initialConditionsLabel;
        private System.Windows.Forms.Button endSimulationButton;
        private System.Windows.Forms.NumericUpDown integrationStepNumericUpDown;
        private System.Windows.Forms.NumericUpDown angularVelocityNumericUpDown;
        private System.Windows.Forms.NumericUpDown cubeDeviationNumericUpDown;
        private System.Windows.Forms.NumericUpDown cubeDensityNumericUpDown;
        private System.Windows.Forms.NumericUpDown cubeEdgeLengthNumericUpDown;
        private System.Windows.Forms.Button applyConditionsButton;
        private System.Windows.Forms.CheckBox displayWallsCheckBox;
    }
}

