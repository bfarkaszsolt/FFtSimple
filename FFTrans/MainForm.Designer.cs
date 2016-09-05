/*
 * Created by SharpDevelop.
 * User: zfarkas
 * Date: 09/02/2016
 * Time: 14:17
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace FFTrans
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox InFileBox;
		private System.Windows.Forms.TextBox OutFileBox;
		private System.Windows.Forms.Label inFileLabel;
		private System.Windows.Forms.Label outFileLabel;
		private System.Windows.Forms.Button inputBrowse;
		private System.Windows.Forms.Button outputFileBrowse;
		private System.Windows.Forms.OpenFileDialog inputFileDialog;
		private System.Windows.Forms.SaveFileDialog outputFileDialog;
		private System.ComponentModel.BackgroundWorker ffmpegWorker;
		private System.Windows.Forms.Button cancel;
		private System.Windows.Forms.DataGridView dataGridView1;
		private System.Windows.Forms.Button addtoList;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.button1 = new System.Windows.Forms.Button();
			this.InFileBox = new System.Windows.Forms.TextBox();
			this.OutFileBox = new System.Windows.Forms.TextBox();
			this.inFileLabel = new System.Windows.Forms.Label();
			this.outFileLabel = new System.Windows.Forms.Label();
			this.inputBrowse = new System.Windows.Forms.Button();
			this.outputFileBrowse = new System.Windows.Forms.Button();
			this.inputFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.outputFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.ffmpegWorker = new System.ComponentModel.BackgroundWorker();
			this.cancel = new System.Windows.Forms.Button();
			this.dataGridView1 = new System.Windows.Forms.DataGridView();
			this.addtoList = new System.Windows.Forms.Button();
			this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.button1.Location = new System.Drawing.Point(771, 166);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 2;
			this.button1.Text = "Convert";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Visible = false;
			this.button1.Click += new System.EventHandler(this.Button1Click);
			// 
			// InFileBox
			// 
			this.InFileBox.Location = new System.Drawing.Point(90, 12);
			this.InFileBox.Name = "InFileBox";
			this.InFileBox.Size = new System.Drawing.Size(660, 20);
			this.InFileBox.TabIndex = 3;
			// 
			// OutFileBox
			// 
			this.OutFileBox.Location = new System.Drawing.Point(90, 38);
			this.OutFileBox.Name = "OutFileBox";
			this.OutFileBox.Size = new System.Drawing.Size(660, 20);
			this.OutFileBox.TabIndex = 4;
			// 
			// inFileLabel
			// 
			this.inFileLabel.Location = new System.Drawing.Point(12, 15);
			this.inFileLabel.Name = "inFileLabel";
			this.inFileLabel.Size = new System.Drawing.Size(72, 23);
			this.inFileLabel.TabIndex = 6;
			this.inFileLabel.Text = "Input File";
			// 
			// outFileLabel
			// 
			this.outFileLabel.Location = new System.Drawing.Point(12, 38);
			this.outFileLabel.Name = "outFileLabel";
			this.outFileLabel.Size = new System.Drawing.Size(72, 23);
			this.outFileLabel.TabIndex = 7;
			this.outFileLabel.Text = "Output Folder";
			// 
			// inputBrowse
			// 
			this.inputBrowse.Location = new System.Drawing.Point(771, 9);
			this.inputBrowse.Name = "inputBrowse";
			this.inputBrowse.Size = new System.Drawing.Size(75, 23);
			this.inputBrowse.TabIndex = 9;
			this.inputBrowse.Text = "Browse";
			this.inputBrowse.UseVisualStyleBackColor = true;
			this.inputBrowse.Click += new System.EventHandler(this.InputBrowseClick);
			// 
			// outputFileBrowse
			// 
			this.outputFileBrowse.Location = new System.Drawing.Point(771, 36);
			this.outputFileBrowse.Name = "outputFileBrowse";
			this.outputFileBrowse.Size = new System.Drawing.Size(75, 23);
			this.outputFileBrowse.TabIndex = 10;
			this.outputFileBrowse.Text = "Browse";
			this.outputFileBrowse.UseVisualStyleBackColor = true;
			this.outputFileBrowse.Click += new System.EventHandler(this.OutputFileBrowseClick);
			// 
			// inputFileDialog
			// 
			this.inputFileDialog.FileName = "inputFileDialog";
			this.inputFileDialog.Filter = "Mxf Files|*.mxf";
			// 
			// ffmpegWorker
			// 
			this.ffmpegWorker.WorkerReportsProgress = true;
			this.ffmpegWorker.WorkerSupportsCancellation = true;
			this.ffmpegWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.FfmpegWorkerDoWork);
			this.ffmpegWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.Ffmpegworker_ProgressChanged);
			this.ffmpegWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.Ffmpegworker_RunWorkerCompleted);
			// 
			// cancel
			// 
			this.cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.cancel.Location = new System.Drawing.Point(675, 166);
			this.cancel.Name = "cancel";
			this.cancel.Size = new System.Drawing.Size(75, 23);
			this.cancel.TabIndex = 13;
			this.cancel.Text = "Cancel";
			this.cancel.UseVisualStyleBackColor = true;
			this.cancel.Visible = false;
			this.cancel.Click += new System.EventHandler(this.CancelClick);
			// 
			// dataGridView1
			// 
			this.dataGridView1.AllowUserToAddRows = false;
			this.dataGridView1.AllowUserToOrderColumns = true;
			this.dataGridView1.AllowUserToResizeColumns = false;
			this.dataGridView1.AllowUserToResizeRows = false;
			this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
			this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridView1.Location = new System.Drawing.Point(15, 110);
			this.dataGridView1.Name = "dataGridView1";
			this.dataGridView1.Size = new System.Drawing.Size(834, 43);
			this.dataGridView1.TabIndex = 14;
			this.dataGridView1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dataGridKeydown);
			// 
			// addtoList
			// 
			this.addtoList.Location = new System.Drawing.Point(771, 72);
			this.addtoList.Name = "addtoList";
			this.addtoList.Size = new System.Drawing.Size(75, 23);
			this.addtoList.TabIndex = 15;
			this.addtoList.Text = "Add to List";
			this.addtoList.UseVisualStyleBackColor = true;
			this.addtoList.Click += new System.EventHandler(this.AddtoListClick);
			// 
			// MainForm
			// 
			this.AllowDrop = true;
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(861, 201);
			this.Controls.Add(this.addtoList);
			this.Controls.Add(this.dataGridView1);
			this.Controls.Add(this.cancel);
			this.Controls.Add(this.outputFileBrowse);
			this.Controls.Add(this.inputBrowse);
			this.Controls.Add(this.outFileLabel);
			this.Controls.Add(this.inFileLabel);
			this.Controls.Add(this.OutFileBox);
			this.Controls.Add(this.InFileBox);
			this.Controls.Add(this.button1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximumSize = new System.Drawing.Size(877, 2000);
			this.MinimumSize = new System.Drawing.Size(877, 239);
			this.Name = "MainForm";
			this.Text = "MXF to MP4 Converter";
			this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormClosingEvent);
			this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form_DragDrop);
			this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form_DragEnter);
			((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
		}
		}


