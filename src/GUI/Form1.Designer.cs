namespace GUI
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выйтиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TreeOfStates = new System.Windows.Forms.ListBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.PropertiesOfElements = new System.Windows.Forms.GroupBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.menuStripStates = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteState = new System.Windows.Forms.ToolStripMenuItem();
            this.createState = new System.Windows.Forms.ToolStripMenuItem();
            this.stateWaitCreate = new System.Windows.Forms.ToolStripMenuItem();
            this.stateDialogueCreate = new System.Windows.Forms.ToolStripMenuItem();
            this.stateChoiceCreate = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.menuStripStates.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.оПрограммеToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(8, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1291, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьToolStripMenuItem,
            this.сохранитьToolStripMenuItem,
            this.выйтиToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(44, 24);
            this.файлToolStripMenuItem.Text = "File";
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(120, 26);
            this.открытьToolStripMenuItem.Text = "Open";
            this.открытьToolStripMenuItem.Click += new System.EventHandler(this.открытьToolStripMenuItem_Click);
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(120, 26);
            this.сохранитьToolStripMenuItem.Text = "Save";
            this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.сохранитьToolStripMenuItem_Click);
            // 
            // выйтиToolStripMenuItem
            // 
            this.выйтиToolStripMenuItem.Name = "выйтиToolStripMenuItem";
            this.выйтиToolStripMenuItem.Size = new System.Drawing.Size(120, 26);
            this.выйтиToolStripMenuItem.Text = "Exit";
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(71, 24);
            this.оПрограммеToolStripMenuItem.Text = "About...";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TreeOfStates);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 28);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(267, 694);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "States";
            // 
            // TreeOfStates
            // 
            this.TreeOfStates.BackColor = System.Drawing.SystemColors.Window;
            this.TreeOfStates.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TreeOfStates.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.TreeOfStates.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TreeOfStates.FormattingEnabled = true;
            this.TreeOfStates.HorizontalScrollbar = true;
            this.TreeOfStates.Location = new System.Drawing.Point(4, 19);
            this.TreeOfStates.Margin = new System.Windows.Forms.Padding(4);
            this.TreeOfStates.Name = "TreeOfStates";
            this.TreeOfStates.Size = new System.Drawing.Size(259, 671);
            this.TreeOfStates.TabIndex = 0;
            this.TreeOfStates.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBox2_DrawItem);
            this.TreeOfStates.SelectedIndexChanged += new System.EventHandler(this.listBox2_SelectedIndexChanged);
            this.TreeOfStates.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TreeOfStates_MouseUp);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tabControl1.Location = new System.Drawing.Point(267, 470);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1024, 252);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.textBox2);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage1.Size = new System.Drawing.Size(1016, 223);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Тестовое окно";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(8, 18);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Текст:";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(69, 18);
            this.textBox2.Margin = new System.Windows.Forms.Padding(4);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(932, 169);
            this.textBox2.TabIndex = 4;
            this.textBox2.Text = resources.GetString("textBox2.Text");
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 198);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Ответ:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(69, 196);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(352, 22);
            this.textBox1.TabIndex = 4;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.label3);
            this.tabPage2.Controls.Add(this.textBox3);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(4);
            this.tabPage2.Size = new System.Drawing.Size(1016, 223);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Лог";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(5, 11);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "Текст:";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(60, 7);
            this.textBox3.Margin = new System.Windows.Forms.Padding(4);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(941, 202);
            this.textBox3.TabIndex = 0;
            this.textBox3.Text = resources.GetString("textBox3.Text");
            // 
            // PropertiesOfElements
            // 
            this.PropertiesOfElements.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PropertiesOfElements.Location = new System.Drawing.Point(267, 28);
            this.PropertiesOfElements.Margin = new System.Windows.Forms.Padding(4);
            this.PropertiesOfElements.Name = "PropertiesOfElements";
            this.PropertiesOfElements.Padding = new System.Windows.Forms.Padding(4);
            this.PropertiesOfElements.Size = new System.Drawing.Size(1024, 442);
            this.PropertiesOfElements.TabIndex = 0;
            this.PropertiesOfElements.TabStop = false;
            this.PropertiesOfElements.Text = "Properties";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // menuStripStates
            // 
            this.menuStripStates.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStripStates.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.deleteState,
            this.createState});
            this.menuStripStates.Name = "menuStripStates";
            this.menuStripStates.Size = new System.Drawing.Size(182, 84);
            // 
            // deleteState
            // 
            this.deleteState.Name = "deleteState";
            this.deleteState.Size = new System.Drawing.Size(181, 26);
            this.deleteState.Text = "Delete state";
            this.deleteState.Click += new System.EventHandler(this.deleteState_Click);
            // 
            // createState
            // 
            this.createState.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stateWaitCreate,
            this.stateDialogueCreate,
            this.stateChoiceCreate});
            this.createState.Name = "createState";
            this.createState.Size = new System.Drawing.Size(181, 26);
            this.createState.Text = "Create state";
            // 
            // stateWaitCreate
            // 
            this.stateWaitCreate.Name = "stateWaitCreate";
            this.stateWaitCreate.Size = new System.Drawing.Size(181, 26);
            this.stateWaitCreate.Text = "State wait";
            this.stateWaitCreate.Click += new System.EventHandler(this.stateWaitCreate_Click);
            // 
            // stateDialogueCreate
            // 
            this.stateDialogueCreate.Name = "stateDialogueCreate";
            this.stateDialogueCreate.Size = new System.Drawing.Size(181, 26);
            this.stateDialogueCreate.Text = "State dialogue";
            this.stateDialogueCreate.Click += new System.EventHandler(this.stateDialogueCreate_Click);
            // 
            // stateChoiceCreate
            // 
            this.stateChoiceCreate.Name = "stateChoiceCreate";
            this.stateChoiceCreate.Size = new System.Drawing.Size(181, 26);
            this.stateChoiceCreate.Text = "State choice";
            this.stateChoiceCreate.Click += new System.EventHandler(this.stateChoiceCreate_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1291, 722);
            this.Controls.Add(this.PropertiesOfElements);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BookOfAdventure";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.menuStripStates.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem файлToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem сохранитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem выйтиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem оПрограммеToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.GroupBox PropertiesOfElements;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.ListBox TreeOfStates;
        private System.Windows.Forms.ToolStripMenuItem открытьToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ContextMenuStrip menuStripStates;
        private System.Windows.Forms.ToolStripMenuItem deleteState;
        private System.Windows.Forms.ToolStripMenuItem createState;
        private System.Windows.Forms.ToolStripMenuItem stateWaitCreate;
        private System.Windows.Forms.ToolStripMenuItem stateDialogueCreate;
        private System.Windows.Forms.ToolStripMenuItem stateChoiceCreate;
    }
}

