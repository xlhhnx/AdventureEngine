namespace AssetPlanner
{
    partial class AssetPlanner
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
            this.assetFileTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.browseFilesButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.assetTypeComboBox = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.idLabel = new System.Windows.Forms.Label();
            this.newAssetButton = new System.Windows.Forms.Button();
            this.addAssetButton = new System.Windows.Forms.Button();
            this.assetListBox = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.batchLabel = new System.Windows.Forms.Label();
            this.batchListBox = new System.Windows.Forms.ListBox();
            this.label5 = new System.Windows.Forms.Label();
            this.deleteBatchButton = new System.Windows.Forms.Button();
            this.editBatchButton = new System.Windows.Forms.Button();
            this.addBatchButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.batchNameTextBox = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // assetFileTextBox
            // 
            this.assetFileTextBox.Location = new System.Drawing.Point(85, 12);
            this.assetFileTextBox.Name = "assetFileTextBox";
            this.assetFileTextBox.Size = new System.Drawing.Size(171, 20);
            this.assetFileTextBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Asset File:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // browseFilesButton
            // 
            this.browseFilesButton.Location = new System.Drawing.Point(262, 12);
            this.browseFilesButton.Name = "browseFilesButton";
            this.browseFilesButton.Size = new System.Drawing.Size(28, 20);
            this.browseFilesButton.TabIndex = 2;
            this.browseFilesButton.Text = "...";
            this.browseFilesButton.UseVisualStyleBackColor = true;
            this.browseFilesButton.Click += new System.EventHandler(this.browseFilesButton_Click);
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "Asset Type:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // assetTypeComboBox
            // 
            this.assetTypeComboBox.FormattingEnabled = true;
            this.assetTypeComboBox.Items.AddRange(new object[] {
            "Texture2D",
            "SpriteFont",
            "Effect"});
            this.assetTypeComboBox.Location = new System.Drawing.Point(85, 39);
            this.assetTypeComboBox.Name = "assetTypeComboBox";
            this.assetTypeComboBox.Size = new System.Drawing.Size(120, 21);
            this.assetTypeComboBox.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(12, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Asset Id:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // idLabel
            // 
            this.idLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.idLabel.Location = new System.Drawing.Point(85, 65);
            this.idLabel.Name = "idLabel";
            this.idLabel.Size = new System.Drawing.Size(120, 21);
            this.idLabel.TabIndex = 7;
            this.idLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // newAssetButton
            // 
            this.newAssetButton.Location = new System.Drawing.Point(211, 38);
            this.newAssetButton.Name = "newAssetButton";
            this.newAssetButton.Size = new System.Drawing.Size(79, 22);
            this.newAssetButton.TabIndex = 8;
            this.newAssetButton.Text = "New Asset";
            this.newAssetButton.UseVisualStyleBackColor = true;
            // 
            // addAssetButton
            // 
            this.addAssetButton.Location = new System.Drawing.Point(211, 65);
            this.addAssetButton.Name = "addAssetButton";
            this.addAssetButton.Size = new System.Drawing.Size(79, 21);
            this.addAssetButton.TabIndex = 9;
            this.addAssetButton.Text = "Add Asset";
            this.addAssetButton.UseVisualStyleBackColor = true;
            // 
            // assetListBox
            // 
            this.assetListBox.FormattingEnabled = true;
            this.assetListBox.Location = new System.Drawing.Point(12, 119);
            this.assetListBox.Name = "assetListBox";
            this.assetListBox.Size = new System.Drawing.Size(278, 95);
            this.assetListBox.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(9, 96);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "Assets in Batch:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // batchLabel
            // 
            this.batchLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.batchLabel.Location = new System.Drawing.Point(102, 95);
            this.batchLabel.Name = "batchLabel";
            this.batchLabel.Size = new System.Drawing.Size(103, 21);
            this.batchLabel.TabIndex = 12;
            this.batchLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // batchListBox
            // 
            this.batchListBox.FormattingEnabled = true;
            this.batchListBox.Location = new System.Drawing.Point(12, 253);
            this.batchListBox.Name = "batchListBox";
            this.batchListBox.Size = new System.Drawing.Size(278, 95);
            this.batchListBox.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(12, 230);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 20);
            this.label5.TabIndex = 14;
            this.label5.Text = "Batches:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // deleteBatchButton
            // 
            this.deleteBatchButton.Location = new System.Drawing.Point(215, 354);
            this.deleteBatchButton.Name = "deleteBatchButton";
            this.deleteBatchButton.Size = new System.Drawing.Size(75, 23);
            this.deleteBatchButton.TabIndex = 15;
            this.deleteBatchButton.Text = "Delete";
            this.deleteBatchButton.UseVisualStyleBackColor = true;
            // 
            // editBatchButton
            // 
            this.editBatchButton.Location = new System.Drawing.Point(93, 354);
            this.editBatchButton.Name = "editBatchButton";
            this.editBatchButton.Size = new System.Drawing.Size(75, 23);
            this.editBatchButton.TabIndex = 16;
            this.editBatchButton.Text = "Edit";
            this.editBatchButton.UseVisualStyleBackColor = true;
            // 
            // addBatchButton
            // 
            this.addBatchButton.Location = new System.Drawing.Point(12, 354);
            this.addBatchButton.Name = "addBatchButton";
            this.addBatchButton.Size = new System.Drawing.Size(75, 23);
            this.addBatchButton.TabIndex = 17;
            this.addBatchButton.Text = "Add";
            this.addBatchButton.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(9, 390);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(123, 20);
            this.label6.TabIndex = 18;
            this.label6.Text = "Batch Name (Optional):";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // batchNameTextBox
            // 
            this.batchNameTextBox.Location = new System.Drawing.Point(138, 390);
            this.batchNameTextBox.Name = "batchNameTextBox";
            this.batchNameTextBox.Size = new System.Drawing.Size(152, 20);
            this.batchNameTextBox.TabIndex = 19;
            this.batchNameTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // saveButton
            // 
            this.saveButton.BackColor = System.Drawing.Color.Red;
            this.saveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.saveButton.ForeColor = System.Drawing.Color.Yellow;
            this.saveButton.Location = new System.Drawing.Point(12, 420);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(278, 41);
            this.saveButton.TabIndex = 20;
            this.saveButton.Text = "SAVE TO FILE";
            this.saveButton.UseVisualStyleBackColor = false;
            // 
            // AssetPlanner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(302, 473);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.batchNameTextBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.addBatchButton);
            this.Controls.Add(this.editBatchButton);
            this.Controls.Add(this.deleteBatchButton);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.batchListBox);
            this.Controls.Add(this.batchLabel);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.assetListBox);
            this.Controls.Add(this.addAssetButton);
            this.Controls.Add(this.newAssetButton);
            this.Controls.Add(this.idLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.assetTypeComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.browseFilesButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.assetFileTextBox);
            this.Name = "AssetPlanner";
            this.Text = "AssetPlanner";
            this.Load += new System.EventHandler(this.AssetPlanner_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox assetFileTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button browseFilesButton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox assetTypeComboBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label idLabel;
        private System.Windows.Forms.Button newAssetButton;
        private System.Windows.Forms.Button addAssetButton;
        private System.Windows.Forms.ListBox assetListBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label batchLabel;
        private System.Windows.Forms.ListBox batchListBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button deleteBatchButton;
        private System.Windows.Forms.Button editBatchButton;
        private System.Windows.Forms.Button addBatchButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox batchNameTextBox;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}