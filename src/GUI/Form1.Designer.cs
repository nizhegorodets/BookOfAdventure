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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.открытьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сохранитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToGraphToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createAllWaysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.выйтиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addOriginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addThreadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оПрограммеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TreeOfStates = new System.Windows.Forms.ListBox();
            this.PropertiesOfElements = new System.Windows.Forms.GroupBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.menuStripStates = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.deleteState = new System.Windows.Forms.ToolStripMenuItem();
            this.createState = new System.Windows.Forms.ToolStripMenuItem();
            this.stateWaitCreate = new System.Windows.Forms.ToolStripMenuItem();
            this.stateDialogueCreate = new System.Windows.Forms.ToolStripMenuItem();
            this.stateChoiceCreate = new System.Windows.Forms.ToolStripMenuItem();
            this.stateImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stateFullscreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.autoSaving = new System.Windows.Forms.Timer(this.components);
            this.addStateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dialogueToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.choiceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.waitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fullscreenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.menuStripStates.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.addOriginToolStripMenuItem,
            this.addThreadToolStripMenuItem,
            this.addStateToolStripMenuItem,
            this.оПрограммеToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1317, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.открытьToolStripMenuItem,
            this.сохранитьToolStripMenuItem,
            this.exportToGraphToolStripMenuItem,
            this.createAllWaysToolStripMenuItem,
            this.выйтиToolStripMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.файлToolStripMenuItem.Text = "File";
            // 
            // открытьToolStripMenuItem
            // 
            this.открытьToolStripMenuItem.Name = "открытьToolStripMenuItem";
            this.открытьToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.открытьToolStripMenuItem.Text = "Open";
            this.открытьToolStripMenuItem.Click += new System.EventHandler(this.открытьToolStripMenuItem_Click);
            // 
            // сохранитьToolStripMenuItem
            // 
            this.сохранитьToolStripMenuItem.Name = "сохранитьToolStripMenuItem";
            this.сохранитьToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.сохранитьToolStripMenuItem.Text = "Save";
            this.сохранитьToolStripMenuItem.Click += new System.EventHandler(this.сохранитьToolStripMenuItem_Click);
            // 
            // exportToGraphToolStripMenuItem
            // 
            this.exportToGraphToolStripMenuItem.Name = "exportToGraphToolStripMenuItem";
            this.exportToGraphToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.exportToGraphToolStripMenuItem.Text = "Export to graph";
            this.exportToGraphToolStripMenuItem.Click += new System.EventHandler(this.exportToGraphToolStripMenuItem_Click);
            // 
            // createAllWaysToolStripMenuItem
            // 
            this.createAllWaysToolStripMenuItem.Name = "createAllWaysToolStripMenuItem";
            this.createAllWaysToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.createAllWaysToolStripMenuItem.Text = "Create all ways";
            this.createAllWaysToolStripMenuItem.Click += new System.EventHandler(this.createAllWaysToolStripMenuItem_Click);
            // 
            // выйтиToolStripMenuItem
            // 
            this.выйтиToolStripMenuItem.Name = "выйтиToolStripMenuItem";
            this.выйтиToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.выйтиToolStripMenuItem.Text = "Exit";
            // 
            // addOriginToolStripMenuItem
            // 
            this.addOriginToolStripMenuItem.Name = "addOriginToolStripMenuItem";
            this.addOriginToolStripMenuItem.Size = new System.Drawing.Size(75, 20);
            this.addOriginToolStripMenuItem.Text = "Add origin";
            this.addOriginToolStripMenuItem.Click += new System.EventHandler(this.addOriginToolStripMenuItem_Click);
            // 
            // addThreadToolStripMenuItem
            // 
            this.addThreadToolStripMenuItem.Name = "addThreadToolStripMenuItem";
            this.addThreadToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.addThreadToolStripMenuItem.Text = "Add thread";
            this.addThreadToolStripMenuItem.Click += new System.EventHandler(this.addThreadToolStripMenuItem_Click);
            // 
            // оПрограммеToolStripMenuItem
            // 
            this.оПрограммеToolStripMenuItem.Name = "оПрограммеToolStripMenuItem";
            this.оПрограммеToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.оПрограммеToolStripMenuItem.Text = "About...";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TreeOfStates);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 24);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(255, 503);
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
            this.TreeOfStates.Location = new System.Drawing.Point(3, 16);
            this.TreeOfStates.Name = "TreeOfStates";
            this.TreeOfStates.Size = new System.Drawing.Size(249, 484);
            this.TreeOfStates.TabIndex = 0;
            this.TreeOfStates.DrawItem += new System.Windows.Forms.DrawItemEventHandler(this.listBox2_DrawItem);
            this.TreeOfStates.SelectedIndexChanged += new System.EventHandler(this.listBox2_SelectedIndexChanged);
            this.TreeOfStates.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TreeOfStates_MouseUp);
            // 
            // PropertiesOfElements
            // 
            this.PropertiesOfElements.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PropertiesOfElements.Location = new System.Drawing.Point(255, 24);
            this.PropertiesOfElements.Name = "PropertiesOfElements";
            this.PropertiesOfElements.Size = new System.Drawing.Size(1062, 503);
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
            this.menuStripStates.Size = new System.Drawing.Size(137, 48);
            // 
            // deleteState
            // 
            this.deleteState.Name = "deleteState";
            this.deleteState.Size = new System.Drawing.Size(136, 22);
            this.deleteState.Text = "Delete state";
            this.deleteState.Click += new System.EventHandler(this.deleteState_Click);
            // 
            // createState
            // 
            this.createState.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stateWaitCreate,
            this.stateDialogueCreate,
            this.stateChoiceCreate,
            this.stateImageToolStripMenuItem,
            this.stateFullscreenToolStripMenuItem});
            this.createState.Name = "createState";
            this.createState.Size = new System.Drawing.Size(136, 22);
            this.createState.Text = "Create state";
            // 
            // stateWaitCreate
            // 
            this.stateWaitCreate.Name = "stateWaitCreate";
            this.stateWaitCreate.Size = new System.Drawing.Size(154, 22);
            this.stateWaitCreate.Text = "State wait";
            this.stateWaitCreate.Click += new System.EventHandler(this.stateWaitCreate_Click);
            // 
            // stateDialogueCreate
            // 
            this.stateDialogueCreate.Name = "stateDialogueCreate";
            this.stateDialogueCreate.Size = new System.Drawing.Size(154, 22);
            this.stateDialogueCreate.Text = "State dialogue";
            this.stateDialogueCreate.Click += new System.EventHandler(this.stateDialogueCreate_Click);
            // 
            // stateChoiceCreate
            // 
            this.stateChoiceCreate.Name = "stateChoiceCreate";
            this.stateChoiceCreate.Size = new System.Drawing.Size(154, 22);
            this.stateChoiceCreate.Text = "State choice";
            this.stateChoiceCreate.Click += new System.EventHandler(this.stateChoiceCreate_Click);
            // 
            // stateImageToolStripMenuItem
            // 
            this.stateImageToolStripMenuItem.Name = "stateImageToolStripMenuItem";
            this.stateImageToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.stateImageToolStripMenuItem.Text = "State image";
            this.stateImageToolStripMenuItem.Click += new System.EventHandler(this.stateImageToolStripMenuItem_Click);
            // 
            // stateFullscreenToolStripMenuItem
            // 
            this.stateFullscreenToolStripMenuItem.Name = "stateFullscreenToolStripMenuItem";
            this.stateFullscreenToolStripMenuItem.Size = new System.Drawing.Size(154, 22);
            this.stateFullscreenToolStripMenuItem.Text = "State fullscreen";
            this.stateFullscreenToolStripMenuItem.Click += new System.EventHandler(this.stateFullscreenToolStripMenuItem_Click);
            // 
            // autoSaving
            // 
            this.autoSaving.Interval = 3000;
            this.autoSaving.Tick += new System.EventHandler(this.autoSaving_Tick);
            // 
            // addStateToolStripMenuItem
            // 
            this.addStateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dialogueToolStripMenuItem,
            this.choiceToolStripMenuItem,
            this.waitToolStripMenuItem,
            this.imageToolStripMenuItem,
            this.fullscreenToolStripMenuItem});
            this.addStateToolStripMenuItem.Name = "addStateToolStripMenuItem";
            this.addStateToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.addStateToolStripMenuItem.Text = "Add state...";
            // 
            // dialogueToolStripMenuItem
            // 
            this.dialogueToolStripMenuItem.Name = "dialogueToolStripMenuItem";
            this.dialogueToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.dialogueToolStripMenuItem.Text = "Dialogue";
            this.dialogueToolStripMenuItem.Click += new System.EventHandler(this.dialogueToolStripMenuItem_Click);
            // 
            // choiceToolStripMenuItem
            // 
            this.choiceToolStripMenuItem.Name = "choiceToolStripMenuItem";
            this.choiceToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.choiceToolStripMenuItem.Text = "Choice";
            this.choiceToolStripMenuItem.Click += new System.EventHandler(this.choiceToolStripMenuItem_Click);
            // 
            // waitToolStripMenuItem
            // 
            this.waitToolStripMenuItem.Name = "waitToolStripMenuItem";
            this.waitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.waitToolStripMenuItem.Text = "Wait";
            this.waitToolStripMenuItem.Click += new System.EventHandler(this.waitToolStripMenuItem_Click);
            // 
            // imageToolStripMenuItem
            // 
            this.imageToolStripMenuItem.Name = "imageToolStripMenuItem";
            this.imageToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.imageToolStripMenuItem.Text = "Image";
            this.imageToolStripMenuItem.Click += new System.EventHandler(this.imageToolStripMenuItem_Click);
            // 
            // fullscreenToolStripMenuItem
            // 
            this.fullscreenToolStripMenuItem.Name = "fullscreenToolStripMenuItem";
            this.fullscreenToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.fullscreenToolStripMenuItem.Text = "Fullscreen";
            this.fullscreenToolStripMenuItem.Click += new System.EventHandler(this.fullscreenToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1317, 527);
            this.Controls.Add(this.PropertiesOfElements);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BookOfAdventure";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
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
        private System.Windows.Forms.GroupBox PropertiesOfElements;
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
        private System.Windows.Forms.ToolStripMenuItem addOriginToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stateImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem stateFullscreenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addThreadToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportToGraphToolStripMenuItem;
        private System.Windows.Forms.Timer autoSaving;
        private System.Windows.Forms.ToolStripMenuItem createAllWaysToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addStateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dialogueToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem choiceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem waitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem imageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fullscreenToolStripMenuItem;
    }
}

