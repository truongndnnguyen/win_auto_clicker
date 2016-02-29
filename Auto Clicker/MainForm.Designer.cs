namespace Auto_Clicker
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
            //DeactivateMouseHook();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.PositionsGroupBox = new System.Windows.Forms.GroupBox();
            this.btnRecord = new System.Windows.Forms.Button();
            this.bntInsertToAll = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNote = new System.Windows.Forms.TextBox();
            this.txtMoveTo = new System.Windows.Forms.TextBox();
            this.bntDelete = new System.Windows.Forms.Button();
            this.bntMoveTo = new System.Windows.Forms.Button();
            this.bntMoveUp = new System.Windows.Forms.Button();
            this.bntDown = new System.Windows.Forms.Button();
            this.btnInsert = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SleepTimeTextBox = new System.Windows.Forms.TextBox();
            this.QueuedYPositionTextBox = new System.Windows.Forms.TextBox();
            this.RightClickCheckBox = new System.Windows.Forms.CheckBox();
            this.SleepTimeLabel = new System.Windows.Forms.Label();
            this.AddPositionButton = new System.Windows.Forms.Button();
            this.QueuedXPositionLabel = new System.Windows.Forms.Label();
            this.QueuedYPositionLabel = new System.Windows.Forms.Label();
            this.QueuedXPositionTextBox = new System.Windows.Forms.TextBox();
            this.PositionsListView = new System.Windows.Forms.ListView();
            this.indexHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.XCoordHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.YCoordHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LRHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SleepTimeHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ListViewContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.ShowSelectedPosition = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExecuteItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.RemoveAllMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.RemoveSelectedMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuSetDelayToAll = new System.Windows.Forms.ToolStripMenuItem();
            this.CurrentPosGroupBox = new System.Windows.Forms.GroupBox();
            this.CopyToAddButton = new System.Windows.Forms.Button();
            this.CurrentYCoordTextBox = new System.Windows.Forms.TextBox();
            this.XCoordLabel = new System.Windows.Forms.Label();
            this.YCoordLabel = new System.Windows.Forms.Label();
            this.CurrentXCoordTextBox = new System.Windows.Forms.TextBox();
            this.StartingOptionsGroupBox = new System.Windows.Forms.GroupBox();
            this.txtSleeps = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.StopClickingButton = new System.Windows.Forms.Button();
            this.btnLoad = new System.Windows.Forms.Button();
            this.StartClickingButton = new System.Windows.Forms.Button();
            this.NumRepeatsTextBox = new System.Windows.Forms.TextBox();
            this.NumRepeatsLabel = new System.Windows.Forms.Label();
            this.CurrentPositionTimer = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.stsFileName = new System.Windows.Forms.ToolStripStatusLabel();
            this.stsNote = new System.Windows.Forms.ToolStripStatusLabel();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.stsTotalTimes = new System.Windows.Forms.ToolStripStatusLabel();
            this.PositionsGroupBox.SuspendLayout();
            this.ListViewContextMenu.SuspendLayout();
            this.CurrentPosGroupBox.SuspendLayout();
            this.StartingOptionsGroupBox.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // PositionsGroupBox
            // 
            this.PositionsGroupBox.Controls.Add(this.btnRecord);
            this.PositionsGroupBox.Controls.Add(this.bntInsertToAll);
            this.PositionsGroupBox.Controls.Add(this.button2);
            this.PositionsGroupBox.Controls.Add(this.label2);
            this.PositionsGroupBox.Controls.Add(this.txtNote);
            this.PositionsGroupBox.Controls.Add(this.txtMoveTo);
            this.PositionsGroupBox.Controls.Add(this.bntDelete);
            this.PositionsGroupBox.Controls.Add(this.bntMoveTo);
            this.PositionsGroupBox.Controls.Add(this.bntMoveUp);
            this.PositionsGroupBox.Controls.Add(this.bntDown);
            this.PositionsGroupBox.Controls.Add(this.btnInsert);
            this.PositionsGroupBox.Controls.Add(this.button1);
            this.PositionsGroupBox.Controls.Add(this.SleepTimeTextBox);
            this.PositionsGroupBox.Controls.Add(this.QueuedYPositionTextBox);
            this.PositionsGroupBox.Controls.Add(this.RightClickCheckBox);
            this.PositionsGroupBox.Controls.Add(this.SleepTimeLabel);
            this.PositionsGroupBox.Controls.Add(this.AddPositionButton);
            this.PositionsGroupBox.Controls.Add(this.QueuedXPositionLabel);
            this.PositionsGroupBox.Controls.Add(this.QueuedYPositionLabel);
            this.PositionsGroupBox.Controls.Add(this.QueuedXPositionTextBox);
            this.PositionsGroupBox.Controls.Add(this.PositionsListView);
            this.PositionsGroupBox.Location = new System.Drawing.Point(428, 5);
            this.PositionsGroupBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PositionsGroupBox.Name = "PositionsGroupBox";
            this.PositionsGroupBox.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PositionsGroupBox.Size = new System.Drawing.Size(630, 541);
            this.PositionsGroupBox.TabIndex = 0;
            this.PositionsGroupBox.TabStop = false;
            this.PositionsGroupBox.Text = "Cursor Positions";
            this.PositionsGroupBox.Enter += new System.EventHandler(this.PositionsGroupBox_Enter);
            // 
            // btnRecord
            // 
            this.btnRecord.Location = new System.Drawing.Point(272, 355);
            this.btnRecord.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRecord.Name = "btnRecord";
            this.btnRecord.Size = new System.Drawing.Size(166, 35);
            this.btnRecord.TabIndex = 22;
            this.btnRecord.Text = "Start Record";
            this.btnRecord.UseVisualStyleBackColor = true;
            this.btnRecord.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // bntInsertToAll
            // 
            this.bntInsertToAll.Location = new System.Drawing.Point(272, 404);
            this.bntInsertToAll.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bntInsertToAll.Name = "bntInsertToAll";
            this.bntInsertToAll.Size = new System.Drawing.Size(166, 35);
            this.bntInsertToAll.TabIndex = 21;
            this.bntInsertToAll.Text = "Insert all";
            this.bntInsertToAll.UseVisualStyleBackColor = true;
            this.bntInsertToAll.Click += new System.EventHandler(this.bntInsertToAll_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(272, 450);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(166, 35);
            this.button2.TabIndex = 20;
            this.button2.Text = "Update all";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(24, 502);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 20);
            this.label2.TabIndex = 19;
            this.label2.Text = "Note";
            // 
            // txtNote
            // 
            this.txtNote.Location = new System.Drawing.Point(84, 499);
            this.txtNote.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtNote.Name = "txtNote";
            this.txtNote.Size = new System.Drawing.Size(538, 26);
            this.txtNote.TabIndex = 7;
            // 
            // txtMoveTo
            // 
            this.txtMoveTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMoveTo.Location = new System.Drawing.Point(522, 241);
            this.txtMoveTo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtMoveTo.Name = "txtMoveTo";
            this.txtMoveTo.Size = new System.Drawing.Size(88, 44);
            this.txtMoveTo.TabIndex = 18;
            this.txtMoveTo.Text = "1";
            this.txtMoveTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // bntDelete
            // 
            this.bntDelete.Location = new System.Drawing.Point(521, 302);
            this.bntDelete.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bntDelete.Name = "bntDelete";
            this.bntDelete.Size = new System.Drawing.Size(89, 44);
            this.bntDelete.TabIndex = 17;
            this.bntDelete.Text = "Delete";
            this.bntDelete.UseVisualStyleBackColor = true;
            this.bntDelete.Click += new System.EventHandler(this.bntDelete_Click);
            // 
            // bntMoveTo
            // 
            this.bntMoveTo.Location = new System.Drawing.Point(522, 187);
            this.bntMoveTo.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bntMoveTo.Name = "bntMoveTo";
            this.bntMoveTo.Size = new System.Drawing.Size(89, 44);
            this.bntMoveTo.TabIndex = 16;
            this.bntMoveTo.Text = "Move to";
            this.bntMoveTo.UseVisualStyleBackColor = true;
            this.bntMoveTo.Click += new System.EventHandler(this.bntMoveTo_Click);
            // 
            // bntMoveUp
            // 
            this.bntMoveUp.Location = new System.Drawing.Point(522, 133);
            this.bntMoveUp.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bntMoveUp.Name = "bntMoveUp";
            this.bntMoveUp.Size = new System.Drawing.Size(89, 44);
            this.bntMoveUp.TabIndex = 15;
            this.bntMoveUp.Text = "Up";
            this.bntMoveUp.UseVisualStyleBackColor = true;
            this.bntMoveUp.Click += new System.EventHandler(this.bntMoveUp_Click);
            // 
            // bntDown
            // 
            this.bntDown.Location = new System.Drawing.Point(522, 88);
            this.bntDown.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bntDown.Name = "bntDown";
            this.bntDown.Size = new System.Drawing.Size(89, 35);
            this.bntDown.TabIndex = 14;
            this.bntDown.Text = "Down";
            this.bntDown.UseVisualStyleBackColor = true;
            this.bntDown.Click += new System.EventHandler(this.bntDown_Click);
            // 
            // btnInsert
            // 
            this.btnInsert.Location = new System.Drawing.Point(446, 404);
            this.btnInsert.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnInsert.Name = "btnInsert";
            this.btnInsert.Size = new System.Drawing.Size(166, 35);
            this.btnInsert.TabIndex = 13;
            this.btnInsert.Text = "Insert";
            this.btnInsert.UseVisualStyleBackColor = true;
            this.btnInsert.Click += new System.EventHandler(this.btnInsert_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(446, 450);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(166, 35);
            this.button1.TabIndex = 12;
            this.button1.Text = "Update";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SleepTimeTextBox
            // 
            this.SleepTimeTextBox.Location = new System.Drawing.Point(165, 396);
            this.SleepTimeTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.SleepTimeTextBox.Name = "SleepTimeTextBox";
            this.SleepTimeTextBox.Size = new System.Drawing.Size(92, 26);
            this.SleepTimeTextBox.TabIndex = 11;
            this.SleepTimeTextBox.Text = "1000";
            // 
            // QueuedYPositionTextBox
            // 
            this.QueuedYPositionTextBox.Location = new System.Drawing.Point(52, 396);
            this.QueuedYPositionTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.QueuedYPositionTextBox.Name = "QueuedYPositionTextBox";
            this.QueuedYPositionTextBox.Size = new System.Drawing.Size(93, 26);
            this.QueuedYPositionTextBox.TabIndex = 10;
            // 
            // RightClickCheckBox
            // 
            this.RightClickCheckBox.AutoSize = true;
            this.RightClickCheckBox.Location = new System.Drawing.Point(26, 448);
            this.RightClickCheckBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.RightClickCheckBox.Name = "RightClickCheckBox";
            this.RightClickCheckBox.Size = new System.Drawing.Size(119, 24);
            this.RightClickCheckBox.TabIndex = 9;
            this.RightClickCheckBox.Text = "Right Click?";
            this.RightClickCheckBox.UseVisualStyleBackColor = true;
            // 
            // SleepTimeLabel
            // 
            this.SleepTimeLabel.AutoSize = true;
            this.SleepTimeLabel.Location = new System.Drawing.Point(161, 366);
            this.SleepTimeLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.SleepTimeLabel.Name = "SleepTimeLabel";
            this.SleepTimeLabel.Size = new System.Drawing.Size(76, 20);
            this.SleepTimeLabel.TabIndex = 5;
            this.SleepTimeLabel.Text = "Wait (ms)";
            // 
            // AddPositionButton
            // 
            this.AddPositionButton.Location = new System.Drawing.Point(445, 355);
            this.AddPositionButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.AddPositionButton.Name = "AddPositionButton";
            this.AddPositionButton.Size = new System.Drawing.Size(166, 35);
            this.AddPositionButton.TabIndex = 4;
            this.AddPositionButton.Text = "Add (F2)";
            this.AddPositionButton.UseVisualStyleBackColor = true;
            this.AddPositionButton.Click += new System.EventHandler(this.AddPositionButton_Click);
            // 
            // QueuedXPositionLabel
            // 
            this.QueuedXPositionLabel.AutoSize = true;
            this.QueuedXPositionLabel.Location = new System.Drawing.Point(24, 363);
            this.QueuedXPositionLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.QueuedXPositionLabel.Name = "QueuedXPositionLabel";
            this.QueuedXPositionLabel.Size = new System.Drawing.Size(24, 20);
            this.QueuedXPositionLabel.TabIndex = 7;
            this.QueuedXPositionLabel.Text = "X:";
            // 
            // QueuedYPositionLabel
            // 
            this.QueuedYPositionLabel.AutoSize = true;
            this.QueuedYPositionLabel.Location = new System.Drawing.Point(24, 402);
            this.QueuedYPositionLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.QueuedYPositionLabel.Name = "QueuedYPositionLabel";
            this.QueuedYPositionLabel.Size = new System.Drawing.Size(24, 20);
            this.QueuedYPositionLabel.TabIndex = 8;
            this.QueuedYPositionLabel.Text = "Y:";
            // 
            // QueuedXPositionTextBox
            // 
            this.QueuedXPositionTextBox.Location = new System.Drawing.Point(52, 360);
            this.QueuedXPositionTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.QueuedXPositionTextBox.Name = "QueuedXPositionTextBox";
            this.QueuedXPositionTextBox.Size = new System.Drawing.Size(93, 26);
            this.QueuedXPositionTextBox.TabIndex = 8;
            // 
            // PositionsListView
            // 
            this.PositionsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.indexHeader,
            this.XCoordHeader,
            this.YCoordHeader,
            this.LRHeader,
            this.SleepTimeHeader,
            this.columnHeader1});
            this.PositionsListView.ContextMenuStrip = this.ListViewContextMenu;
            this.PositionsListView.FullRowSelect = true;
            this.PositionsListView.GridLines = true;
            this.PositionsListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.PositionsListView.HideSelection = false;
            this.PositionsListView.Location = new System.Drawing.Point(8, 29);
            this.PositionsListView.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.PositionsListView.Name = "PositionsListView";
            this.PositionsListView.Size = new System.Drawing.Size(505, 322);
            this.PositionsListView.TabIndex = 1;
            this.PositionsListView.UseCompatibleStateImageBehavior = false;
            this.PositionsListView.View = System.Windows.Forms.View.Details;
            this.PositionsListView.SelectedIndexChanged += new System.EventHandler(this.PositionsListView_SelectedIndexChanged);
            this.PositionsListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.PositionsListView_MouseDoubleClick);
            // 
            // indexHeader
            // 
            this.indexHeader.Text = "No";
            // 
            // XCoordHeader
            // 
            this.XCoordHeader.Text = "X";
            this.XCoordHeader.Width = 74;
            // 
            // YCoordHeader
            // 
            this.YCoordHeader.Text = "Y";
            this.YCoordHeader.Width = 75;
            // 
            // LRHeader
            // 
            this.LRHeader.Text = "L/R";
            this.LRHeader.Width = 76;
            // 
            // SleepTimeHeader
            // 
            this.SleepTimeHeader.Text = "Delay";
            this.SleepTimeHeader.Width = 104;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Note";
            // 
            // ListViewContextMenu
            // 
            this.ListViewContextMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.ListViewContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ShowSelectedPosition,
            this.mnuExecuteItem,
            this.toolStripSeparator1,
            this.RemoveAllMenuItem,
            this.RemoveSelectedMenuItem,
            this.toolStripSeparator2,
            this.mnuSetDelayToAll});
            this.ListViewContextMenu.Name = "ListViewContextMenu";
            this.ListViewContextMenu.Size = new System.Drawing.Size(327, 166);
            // 
            // ShowSelectedPosition
            // 
            this.ShowSelectedPosition.Name = "ShowSelectedPosition";
            this.ShowSelectedPosition.Size = new System.Drawing.Size(326, 30);
            this.ShowSelectedPosition.Text = "Show Position";
            this.ShowSelectedPosition.Click += new System.EventHandler(this.ShowSelectedPosition_Click);
            // 
            // mnuExecuteItem
            // 
            this.mnuExecuteItem.Name = "mnuExecuteItem";
            this.mnuExecuteItem.Size = new System.Drawing.Size(326, 30);
            this.mnuExecuteItem.Text = "Execute this action";
            this.mnuExecuteItem.Click += new System.EventHandler(this.mnuExecuteItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(323, 6);
            // 
            // RemoveAllMenuItem
            // 
            this.RemoveAllMenuItem.Name = "RemoveAllMenuItem";
            this.RemoveAllMenuItem.Size = new System.Drawing.Size(326, 30);
            this.RemoveAllMenuItem.Text = "Remove All Items";
            this.RemoveAllMenuItem.Click += new System.EventHandler(this.RemoveAllMenuItem_Click);
            // 
            // RemoveSelectedMenuItem
            // 
            this.RemoveSelectedMenuItem.Name = "RemoveSelectedMenuItem";
            this.RemoveSelectedMenuItem.Size = new System.Drawing.Size(326, 30);
            this.RemoveSelectedMenuItem.Text = "Remove Selected";
            this.RemoveSelectedMenuItem.Click += new System.EventHandler(this.RemoveSelectedMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(323, 6);
            // 
            // mnuSetDelayToAll
            // 
            this.mnuSetDelayToAll.Name = "mnuSetDelayToAll";
            this.mnuSetDelayToAll.Size = new System.Drawing.Size(326, 30);
            this.mnuSetDelayToAll.Text = "Set delay time to whole scripts";
            this.mnuSetDelayToAll.Click += new System.EventHandler(this.mnuSetDelayToAll_Click);
            // 
            // CurrentPosGroupBox
            // 
            this.CurrentPosGroupBox.Controls.Add(this.CopyToAddButton);
            this.CurrentPosGroupBox.Controls.Add(this.CurrentYCoordTextBox);
            this.CurrentPosGroupBox.Controls.Add(this.XCoordLabel);
            this.CurrentPosGroupBox.Controls.Add(this.YCoordLabel);
            this.CurrentPosGroupBox.Controls.Add(this.CurrentXCoordTextBox);
            this.CurrentPosGroupBox.Location = new System.Drawing.Point(18, 18);
            this.CurrentPosGroupBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CurrentPosGroupBox.Name = "CurrentPosGroupBox";
            this.CurrentPosGroupBox.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CurrentPosGroupBox.Size = new System.Drawing.Size(400, 202);
            this.CurrentPosGroupBox.TabIndex = 2;
            this.CurrentPosGroupBox.TabStop = false;
            this.CurrentPosGroupBox.Text = "Current Cursor Position";
            // 
            // CopyToAddButton
            // 
            this.CopyToAddButton.Location = new System.Drawing.Point(14, 131);
            this.CopyToAddButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CopyToAddButton.Name = "CopyToAddButton";
            this.CopyToAddButton.Size = new System.Drawing.Size(378, 46);
            this.CopyToAddButton.TabIndex = 6;
            this.CopyToAddButton.Text = "Copy ( F1 or Shift + Alt + S)";
            this.CopyToAddButton.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.CopyToAddButton.UseVisualStyleBackColor = true;
            this.CopyToAddButton.Click += new System.EventHandler(this.CopyToAddButton_Click);
            // 
            // CurrentYCoordTextBox
            // 
            this.CurrentYCoordTextBox.Location = new System.Drawing.Point(70, 75);
            this.CurrentYCoordTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CurrentYCoordTextBox.Name = "CurrentYCoordTextBox";
            this.CurrentYCoordTextBox.Size = new System.Drawing.Size(319, 26);
            this.CurrentYCoordTextBox.TabIndex = 5;
            // 
            // XCoordLabel
            // 
            this.XCoordLabel.AutoSize = true;
            this.XCoordLabel.Location = new System.Drawing.Point(9, 40);
            this.XCoordLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.XCoordLabel.Name = "XCoordLabel";
            this.XCoordLabel.Size = new System.Drawing.Size(20, 20);
            this.XCoordLabel.TabIndex = 2;
            this.XCoordLabel.Text = "X";
            // 
            // YCoordLabel
            // 
            this.YCoordLabel.AutoSize = true;
            this.YCoordLabel.Location = new System.Drawing.Point(9, 86);
            this.YCoordLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.YCoordLabel.Name = "YCoordLabel";
            this.YCoordLabel.Size = new System.Drawing.Size(20, 20);
            this.YCoordLabel.TabIndex = 3;
            this.YCoordLabel.Text = "Y";
            // 
            // CurrentXCoordTextBox
            // 
            this.CurrentXCoordTextBox.Location = new System.Drawing.Point(70, 35);
            this.CurrentXCoordTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.CurrentXCoordTextBox.Name = "CurrentXCoordTextBox";
            this.CurrentXCoordTextBox.Size = new System.Drawing.Size(319, 26);
            this.CurrentXCoordTextBox.TabIndex = 4;
            // 
            // StartingOptionsGroupBox
            // 
            this.StartingOptionsGroupBox.Controls.Add(this.txtSleeps);
            this.StartingOptionsGroupBox.Controls.Add(this.label1);
            this.StartingOptionsGroupBox.Controls.Add(this.comboBox1);
            this.StartingOptionsGroupBox.Controls.Add(this.btnSave);
            this.StartingOptionsGroupBox.Controls.Add(this.StopClickingButton);
            this.StartingOptionsGroupBox.Controls.Add(this.btnLoad);
            this.StartingOptionsGroupBox.Controls.Add(this.StartClickingButton);
            this.StartingOptionsGroupBox.Controls.Add(this.NumRepeatsTextBox);
            this.StartingOptionsGroupBox.Controls.Add(this.NumRepeatsLabel);
            this.StartingOptionsGroupBox.Location = new System.Drawing.Point(18, 229);
            this.StartingOptionsGroupBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.StartingOptionsGroupBox.Name = "StartingOptionsGroupBox";
            this.StartingOptionsGroupBox.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.StartingOptionsGroupBox.Size = new System.Drawing.Size(400, 317);
            this.StartingOptionsGroupBox.TabIndex = 2;
            this.StartingOptionsGroupBox.TabStop = false;
            this.StartingOptionsGroupBox.Text = "Starting Options";
            // 
            // txtSleeps
            // 
            this.txtSleeps.Location = new System.Drawing.Point(309, 30);
            this.txtSleeps.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtSleeps.Name = "txtSleeps";
            this.txtSleeps.Size = new System.Drawing.Size(80, 26);
            this.txtSleeps.TabIndex = 22;
            this.txtSleeps.Text = "1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(218, 33);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 20);
            this.label1.TabIndex = 21;
            this.label1.Text = "Sleeps";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(14, 273);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(375, 28);
            this.comboBox1.TabIndex = 20;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(223, 204);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(166, 44);
            this.btnSave.TabIndex = 14;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // StopClickingButton
            // 
            this.StopClickingButton.Location = new System.Drawing.Point(9, 131);
            this.StopClickingButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.StopClickingButton.Name = "StopClickingButton";
            this.StopClickingButton.Size = new System.Drawing.Size(382, 57);
            this.StopClickingButton.TabIndex = 3;
            this.StopClickingButton.Text = "Stop (F4 or Shift + Alt + S)";
            this.StopClickingButton.UseVisualStyleBackColor = true;
            this.StopClickingButton.Click += new System.EventHandler(this.StopClickingButton_Click);
            // 
            // btnLoad
            // 
            this.btnLoad.Location = new System.Drawing.Point(14, 204);
            this.btnLoad.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(166, 44);
            this.btnLoad.TabIndex = 13;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // StartClickingButton
            // 
            this.StartClickingButton.Location = new System.Drawing.Point(9, 65);
            this.StartClickingButton.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.StartClickingButton.Name = "StartClickingButton";
            this.StartClickingButton.Size = new System.Drawing.Size(382, 57);
            this.StartClickingButton.TabIndex = 2;
            this.StartClickingButton.Text = "Start (F3 or Shift + Alt + S)";
            this.StartClickingButton.UseVisualStyleBackColor = true;
            this.StartClickingButton.Click += new System.EventHandler(this.StartClickingButton_Click);
            // 
            // NumRepeatsTextBox
            // 
            this.NumRepeatsTextBox.Location = new System.Drawing.Point(100, 26);
            this.NumRepeatsTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.NumRepeatsTextBox.Name = "NumRepeatsTextBox";
            this.NumRepeatsTextBox.Size = new System.Drawing.Size(80, 26);
            this.NumRepeatsTextBox.TabIndex = 1;
            this.NumRepeatsTextBox.Text = "1000";
            // 
            // NumRepeatsLabel
            // 
            this.NumRepeatsLabel.AutoSize = true;
            this.NumRepeatsLabel.Location = new System.Drawing.Point(9, 29);
            this.NumRepeatsLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.NumRepeatsLabel.Name = "NumRepeatsLabel";
            this.NumRepeatsLabel.Size = new System.Drawing.Size(83, 20);
            this.NumRepeatsLabel.TabIndex = 0;
            this.NumRepeatsLabel.Text = "Repeats - ";
            // 
            // CurrentPositionTimer
            // 
            this.CurrentPositionTimer.Interval = 1;
            this.CurrentPositionTimer.Tick += new System.EventHandler(this.CurrentPositionTimer_Tick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stsTotalTimes,
            this.toolStripStatusLabel1,
            this.stsFileName,
            this.stsNote});
            this.statusStrip1.Location = new System.Drawing.Point(0, 558);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1076, 34);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.toolStripStatusLabel1.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(140, 29);
            this.toolStripStatusLabel1.Text = "X: 1234  Y:3333";
            // 
            // stsFileName
            // 
            this.stsFileName.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.stsFileName.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.stsFileName.Name = "stsFileName";
            this.stsFileName.Size = new System.Drawing.Size(4, 29);
            // 
            // stsNote
            // 
            this.stsNote.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)));
            this.stsNote.BorderStyle = System.Windows.Forms.Border3DStyle.Etched;
            this.stsNote.Name = "stsNote";
            this.stsNote.Size = new System.Drawing.Size(4, 29);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(1089, 47);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(610, 443);
            this.richTextBox1.TabIndex = 7;
            this.richTextBox1.Text = "";
            // 
            // stsTotalTimes
            // 
            this.stsTotalTimes.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenInner;
            this.stsTotalTimes.Name = "stsTotalTimes";
            this.stsTotalTimes.Size = new System.Drawing.Size(22, 29);
            this.stsTotalTimes.Text = "0";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1076, 592);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.StartingOptionsGroupBox);
            this.Controls.Add(this.CurrentPosGroupBox);
            this.Controls.Add(this.PositionsGroupBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Text = "Auto Clicker";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            this.PositionsGroupBox.ResumeLayout(false);
            this.PositionsGroupBox.PerformLayout();
            this.ListViewContextMenu.ResumeLayout(false);
            this.CurrentPosGroupBox.ResumeLayout(false);
            this.CurrentPosGroupBox.PerformLayout();
            this.StartingOptionsGroupBox.ResumeLayout(false);
            this.StartingOptionsGroupBox.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox PositionsGroupBox;
        private System.Windows.Forms.TextBox SleepTimeTextBox;
        private System.Windows.Forms.TextBox QueuedYPositionTextBox;
        private System.Windows.Forms.CheckBox RightClickCheckBox;
        private System.Windows.Forms.Label SleepTimeLabel;
        private System.Windows.Forms.Button AddPositionButton;
        private System.Windows.Forms.Label QueuedXPositionLabel;
        private System.Windows.Forms.Label QueuedYPositionLabel;
        private System.Windows.Forms.TextBox QueuedXPositionTextBox;
        private System.Windows.Forms.ListView PositionsListView;
        private System.Windows.Forms.ColumnHeader XCoordHeader;
        private System.Windows.Forms.ColumnHeader YCoordHeader;
        private System.Windows.Forms.ColumnHeader LRHeader;
        private System.Windows.Forms.ColumnHeader SleepTimeHeader;
        private System.Windows.Forms.GroupBox CurrentPosGroupBox;
        private System.Windows.Forms.Button CopyToAddButton;
        private System.Windows.Forms.TextBox CurrentYCoordTextBox;
        private System.Windows.Forms.Label XCoordLabel;
        private System.Windows.Forms.Label YCoordLabel;
        private System.Windows.Forms.TextBox CurrentXCoordTextBox;
        private System.Windows.Forms.GroupBox StartingOptionsGroupBox;
        private System.Windows.Forms.Button StopClickingButton;
        private System.Windows.Forms.Button StartClickingButton;
        private System.Windows.Forms.TextBox NumRepeatsTextBox;
        private System.Windows.Forms.Label NumRepeatsLabel;
        private System.Windows.Forms.Timer CurrentPositionTimer;
        private System.Windows.Forms.ContextMenuStrip ListViewContextMenu;
        private System.Windows.Forms.ToolStripMenuItem RemoveAllMenuItem;
        private System.Windows.Forms.ToolStripMenuItem RemoveSelectedMenuItem;
        private System.Windows.Forms.ColumnHeader indexHeader;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem ShowSelectedPosition;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripStatusLabel stsFileName;
        private System.Windows.Forms.Button bntDelete;
        private System.Windows.Forms.Button bntMoveTo;
        private System.Windows.Forms.Button bntMoveUp;
        private System.Windows.Forms.Button bntDown;
        private System.Windows.Forms.ToolStripMenuItem mnuSetDelayToAll;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TextBox txtMoveTo;
        private System.Windows.Forms.ToolStripMenuItem mnuExecuteItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNote;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ToolStripStatusLabel stsNote;
        private System.Windows.Forms.Button bntInsertToAll;
        private System.Windows.Forms.Button btnInsert;
        private System.Windows.Forms.Button btnRecord;
        private System.Windows.Forms.TextBox txtSleeps;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripStatusLabel stsTotalTimes;
    }
}

