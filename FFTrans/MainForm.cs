/*
 * Created by SharpDevelop.
 * User: zfarkas
 * Date: 09/02/2016
 * Time: 14:17
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Diagnostics;
using System.IO;
using System.ComponentModel;
using System.Windows.Forms;
using System.Media;


namespace FFTrans
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	/// 
	
	
	
	public partial class MainForm : Form
	{
		public MainForm()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			SetdataGridView1();
			
			OutFileBox.ForeColor = Color.Gray;
			
			OutFileBox.Text = "This folder must be set";
		
			//PopulatePresetBox();
			
		//	PopulatePresetList();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		static public TimeSpan Duration;
		
		static public string ffmpegPath = String.Format("\"{0}\\ffmpeg.exe\"", Directory.GetCurrentDirectory());
		
	
	
		
		void TextBox1TextChanged(object sender, EventArgs e)
		{
	
		}
		private void Button1Click(object sender, EventArgs e)
		{
			
	
			startConvertProcess();
		
	
		}
		
		
		void startConvertProcess()
			
		{
			
			if (!ffmpegWorker.IsBusy)
			
			{
				
			if (dataGridView1.Rows.Count > 0)
		
			{
			
				
			if (dataGridView1.Rows[0].Cells["inFile"].Value !=null && dataGridView1.Rows[0].Cells["outFile"].Value !=null)
				
			{
				
				string aspectValue = CheckAspectRatio(dataGridView1.Rows[0].Cells["inFile"].Value.ToString());
				
				if (aspectValue != "")
					
				{
				
				
				
				
				
				
				
				string getFFmpegPresetbasedonValue = GetFFmpegPreset(aspectValue);
				
					
					if (getFFmpegPresetbasedonValue != "")
						
					{
			
				
				
							Tuple<string, string, string> passArgs = new Tuple<string, string, string>(dataGridView1.Rows[0].Cells["inFile"].Value.ToString(), dataGridView1.Rows[0].Cells["outFile"].Value.ToString(), getFFmpegPresetbasedonValue);
			
			
			
							ffmpegWorker.RunWorkerAsync(passArgs);
			
							
					}
					
					
					else
						
					{
					
					
						MessageBox.Show("Aspect Ratio unknown. Please check file.");
				
					
					
					}

							
			
				}
				
				
				else
					
				{
				
					MessageBox.Show("Can not determine Aspect Ratio. Please check file.");
				
				
				}
				
				
				
				
			}
			
			}
				
		
			}
			
			
			
		}
		
		
			string GetFFmpegPreset(string gotAspectValue)
				
			{
			
			
				
				
				
				string Preset_608 = "-acodec aac -b:a 128k -af \"pan=stereo|c0=c0|c1=c1\" -vcodec libx264 -pix_fmt yuv420p -preset veryfast -b:v 2000k -vf \"crop=720:576:0:32, scale=-768:432, yadif=0:-1:0\" -sws_flags lanczos";
				
				string Preset_576 = "-acodec aac -b:a 128k -af \"pan=stereo|c0=c0|c1=c1\" -vcodec libx264 -pix_fmt yuv420p -preset veryfast -b:v 2000k -vf \"yadif=0:-1:0\"";

				string Preset_720p = "-acodec aac -b:a 128k -af \"pan=stereo|c0=c0|c1=c1\" -vcodec libx264 -pix_fmt yuv420p -preset veryfast -b:v 3200k -vf \"yadif=0:-1:0\"";
				
				string Preset_HighHD = "-acodec aac -b:a 128k -af \"pan=stereo|c0=c0|c1=c1\" -vcodec libx264 -pix_fmt yuv420p -preset veryfast -b:v 3200k -vf \"scale=-1280:720, yadif=0:-1:0\" -sws_flags lanczos";	
				
				
				int aspectHeight = int.Parse(gotAspectValue.Substring(gotAspectValue.IndexOf('x')+1));
				
				
				
				
				
				if (aspectHeight == 608)
					
					
				{
				
					return Preset_608;
				
				}
				
				
				if (aspectHeight == 576)
					
				{
				
				
					return Preset_576;
				
				
				}
				
				
				if (aspectHeight == 720)
					
					
				{
				
				
				
					return Preset_720p;
				
				
				}
				
				
				if (aspectHeight >= 720)
					
					
				{
				
				
				
					return Preset_HighHD;
				
				
				}
				
				
				
				
				return ""; 
			
			}
			
		
		
		
		void Label1Click(object sender, EventArgs e)
		{
	
		}
		void InputBrowseClick(object sender, EventArgs e)
		{
	
			
		
			
			 DialogResult result = inputFileDialog.ShowDialog();
	   	

			 if (result == DialogResult.OK) // Test result.
	    
				 {
	    		
	   			
			 	InFileBox.Text = inputFileDialog.FileName;
	   			
	   			}
			
			
		}
		

		
		void OutputFileBrowseClick(object sender, EventArgs e)
			
		{
		
			
			
			DialogResult result = folderBrowserDialog1.ShowDialog();
			
			if (!string.IsNullOrWhiteSpace(folderBrowserDialog1.SelectedPath))
				
			{
			
			
				OutFileBox.ForeColor = Color.Black;
				OutFileBox.Text = folderBrowserDialog1.SelectedPath;
			
			
			}
		
		
		
		
		
		
		}
		
		
		
		
		
		private void FfmpegWorkerDoWork(object sender, DoWorkEventArgs e)
		{
	
			
			Tuple<string, string, string> value = e.Argument as Tuple<string, string, string>;  
			
			string inFile = value.Item1;
			
			string outFile = value.Item2;
			
			string preset = value.Item3;
			
		//	string preset = "-acodec aac -b:a 128k -af \"pan=stereo|c0=c0|c1=c1\" -vcodec libx264 -pix_fmt yuv420p -preset veryfast -b:v 2000k -vf \"crop=720:576:0:32, scale=-768:432, yadif=0:-1:0\" -sws_flags lanczos";
			
		
		
			string argumenttoProcess = String.Format("-i " + "{0}" + " " + "{1}" + " " + "{2}" + " " + "-y", inFile, preset, outFile);
			
			   Process proc = new Process ();
                proc.StartInfo.FileName = ffmpegPath;
                proc.StartInfo.Arguments = argumenttoProcess;
                proc.StartInfo.RedirectStandardError = true;
                proc.StartInfo.UseShellExecute = false;
                proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                proc.StartInfo.CreateNoWindow = true;
                if (!proc.Start()) {
                        MessageBox.Show("Error starting");
                        return;
                }
                StreamReader reader = proc.StandardError;
                string line;
                while ((line = reader.ReadLine()) != null) {
                      
                	if (line.Contains("Duration: "))
                	{
                	
                		string parsedDuration = line.Substring(11, 12);
                		
                		TimeSpan parsedDurationTs = TimeSpan.Parse(parsedDuration);
                		
                		
                		Duration = parsedDurationTs;
                		
                		string AddInfo = Duration.ToString();
                		
                //	MessageBox.Show(parsedDuration);
                	}
                	
                	if (line.Contains("size="))
                	{
                		
                		TimeSpan actualDuration = TimeSpan.Parse(line.Substring(line.LastIndexOf("time=")+5, 12));
                		
                		long remainder;
                		
                		long progressPercLong = Math.DivRem((actualDuration.Ticks * 100), Duration.Ticks, out remainder);
                		
                		string percinString = progressPercLong.ToString();
                		
                		int progpercinInt = int.Parse(percinString);
                		
                		if (ffmpegWorker.CancellationPending)
                			
                			{
                			
                			proc.Kill();
                			 proc.Close();
                			 
                			 
                			
                			 (sender as BackgroundWorker).ReportProgress(0);
                			 
     						    e.Cancel = true;
     						    reader.Close();
     						    
     						    CloseApplication();
     						    
       						   return;
      						}
                		
                		(sender as BackgroundWorker).ReportProgress(progpercinInt);
                		
       
                		
                	}
                	
                
                	
                	
                	
                	
                }
                
                reader.Close();
                proc.Close();
			
			
			
		}
			private void Ffmpegworker_ProgressChanged(object sender,  ProgressChangedEventArgs e)
	{
	
	 
	    dataGridView1.Rows[0].Cells["Percent"].Value = e.ProgressPercentage;
	    
	    
	}
		void CancelClick(object sender, EventArgs e)
		{
		
			
			if (dataGridView1.CurrentCell != null)
				
			{
			
				if (dataGridView1.CurrentCell.RowIndex == 0)
					
				{
				
					if (dataGridView1.Rows[0].Cells["Percent"].Value != null)
					
						{
				
							this.ffmpegWorker.CancelAsync();
							
							return;
			
						}
					
					
					if (dataGridView1.Rows[0].Cells["Percent"].Value == null)
					
						{
				
							RemoveListEvent(false);
							return;
			
						}
				
				}
			
	
				
						RemoveListEvent(false);
						return;
			
					
				
			}
			
			
		}
		
		
		
		private void Ffmpegworker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
		
		
		{
		
		
			RemoveListEvent(true);
			
			if (dataGridView1.Rows.Count > 0)
				
			{
			
				startConvertProcess();
				
				//Tuple<string, string> passArgs = new Tuple<string, string>(dataGridView1.Rows[0].Cells["inFile"].Value.ToString(), dataGridView1.Rows[0].Cells["outFile"].Value.ToString());
			
				//ffmpegWorker.RunWorkerAsync(passArgs);
			
			
			}
			
		
		
		
		}
		
		
		
		void SetdataGridView1()
 	
 		{
 		
 			dataGridView1.ColumnCount = 3;
 			
 	
 			dataGridView1.Columns[0].Name = "inFile";
 			dataGridView1.Columns["inFile"].ValueType = typeof(string);
 			dataGridView1.Columns["inFile"].SortMode = DataGridViewColumnSortMode.NotSortable;
 			dataGridView1.Columns["inFile"].Width = 390;
 			
 			
 			dataGridView1.Columns[1].Name = "outFile";
 			dataGridView1.Columns["outFile"].ValueType = typeof(string);
 			dataGridView1.Columns["outFile"].SortMode = DataGridViewColumnSortMode.NotSortable;
 			dataGridView1.Columns["outFile"].Width = 390;
 		
 			dataGridView1.Columns[2].Name = "Percent";
 			dataGridView1.Columns["Percent"].ValueType = typeof(int);
 			
 			dataGridView1.Columns["Percent"].SortMode = DataGridViewColumnSortMode.NotSortable;
 			dataGridView1.Columns["Percent"].Width = 51;
 			dataGridView1.Columns["Percent"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
 
 			dataGridView1.RowHeadersVisible = false;
 			
 			
 			
 		}
		
		
		
		
		void RowMaker(string inFile, string outFolder)
 			
 		{
 		
 		
			string inFileName = Path.GetFileNameWithoutExtension(inFile);
			
			
			
			
			string outFile = String.Format("{0}\\{1}.mp4", outFolder, inFileName);
			
			
			
			
			
 			DataGridViewRow dataGridViewlistRow = dataGridView1.Rows[dataGridView1.Rows.Add()];
 				
 												
 				
 				dataGridViewlistRow.Cells["inFile"].Value = inFile;
 				
 				dataGridViewlistRow.Cells["outFile"].Value = outFile;
 				
 		
	
	}
		void AddtoListClick(object sender, EventArgs e)
		{
			
			
			
			
			
			
			if (InFileBox.Text != "" && OutFileBox.Text != "" && OutFileBox.Text != "This folder must be set")
				
			{
				
				
				
				RowMaker(InFileBox.Text, OutFileBox.Text);
				
				AddtoListEvent();
				
				
			}
			
			
		}
		
		void AddtoListEvent()
			
		{
		
			
			button1.Visible = true;
			cancel.Visible = true;
			
		
			if (dataGridView1.Rows.Count == 2)
				
			{
			
				int newHeight = this.Height + 25;
				this.Size = new Size(877, newHeight);
				
				
			
			}
			
				if (dataGridView1.Rows.Count > 2)
				
			{
			
				int newHeight = this.Height + 22;
				this.Size = new Size(877, newHeight);
				
			
			}
		
		
		
		}
		
		
		void RemoveListEvent(bool istheWorkerCompleteCalling)
			
		{
		
			
			
			if (istheWorkerCompleteCalling == true)
				
			{
			
			
				dataGridView1.Rows.RemoveAt(0);
				
					int newHeight = this.Height - 22;
				this.Size = new Size(877, newHeight);
				
				return;
			
			
			
			
			}
			
			
		
		
			
			
			
			
				if (istheWorkerCompleteCalling == false)
				
			{
			
					dataGridView1.Rows.RemoveAt(dataGridView1.CurrentCell.RowIndex);
					
					
				int newHeight = this.Height - 22;
				this.Size = new Size(877, newHeight);
				
			
				return;
				
			}
		
		
		
		}
		
		
		
		private void dataGridKeydown(object sender, KeyEventArgs e)
			
		{
		
			if (e.KeyCode == Keys.Up && e.Modifiers == Keys.Alt)
				
			{
			
				moveLineUp();
			
			
			
			}
			
				if (e.KeyCode == Keys.Down && e.Modifiers == Keys.Alt)
				
			{
			
				moveLineDown();
			
			
			
			}
				
				
				if (e.KeyCode == Keys.Delete)
				
			{
			
				RemoveListEvent(false);
			
			
			
			}
				
			
			
			
			
		
		
		
		}
		
		
		
		private void moveLineUp()
			
			
		{
		
		
		
			if (dataGridView1.RowCount > 1)
			
			{
			
			
				if (dataGridView1.CurrentCell.RowIndex > 1)
					
				{
				
					int rowIndex =  dataGridView1.SelectedCells[0].OwningRow.Index; //  dataGridView1.CurrentCell.RowIndex;
					
					DataGridViewRow prevRow = dataGridView1.Rows[rowIndex - 1];
					
					dataGridView1.Rows.Remove(prevRow);
							
					dataGridView1.Rows.Insert(rowIndex, prevRow);
					
					dataGridView1.CurrentCell = dataGridView1.Rows[rowIndex].Cells[0];
					
					
					
					dataGridView1.Rows[rowIndex].Selected = true;
				
				
				
				
				}
					
			
			
			
			
			}
		
		
		
		
		}
		
		
		
		private void moveLineDown()
			
			
		{
		
			
			
		
		
			if (dataGridView1.RowCount > 1)
			
			{
			
			
				if (dataGridView1.CurrentCell.RowIndex < dataGridView1.RowCount-1)
					
				{
				
					int rowIndex =  dataGridView1.SelectedCells[0].OwningRow.Index; //  dataGridView1.CurrentCell.RowIndex;
					
					DataGridViewRow nextRow = dataGridView1.Rows[rowIndex + 1];
					
					dataGridView1.Rows.Remove(nextRow);
							
					dataGridView1.Rows.Insert(rowIndex, nextRow);
					
					dataGridView1.CurrentCell = dataGridView1.Rows[rowIndex].Cells[0];
					
					
					
					dataGridView1.Rows[rowIndex].Selected = true;
				
				
				
				
				}
					
			
			
			
			
			}
		
		
		
		
		}
		
		
		
		volatile bool isClosePending = false;
		
		private void FormClosingEvent(object sender, FormClosingEventArgs e)
			
						
		{
			
			
			if (dataGridView1.RowCount > 0)
				
			{
				
			
			
			if (ffmpegWorker.IsBusy == true)
					
						{
				
				isClosePending = true;
				
				this.ffmpegWorker.CancelAsync();
				
				return;
				
							
						
			
						}
			
			
			
			
			}
			
			
			
			
		Application.Exit();
			
		
		
		}
		
		
		void Form_DragEnter(object sender, DragEventArgs e)
			
			
		{
		
			if (e.Data.GetDataPresent(DataFormats.FileDrop)) e.Effect = DragDropEffects.Copy;
		
		
		
		}
		
		
		void Form_DragDrop(object sender, DragEventArgs e)
			
		{
		
			string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
		
			foreach (string file in files)
				
			{
			
				
				if (OutFileBox.Text != "" && OutFileBox.Text != "This folder must be set" && Path.GetExtension(file) == ".mxf")
					
				{
				

				RowMaker(file, OutFileBox.Text);
				
				AddtoListEvent();
				
				
			
				}
			}
		
		
		}
		
		
		
		
		
		void CloseApplication()
			
		{
		
	
			if (isClosePending)
				
			{
			
			Application.Exit();
			
			}
			
		}
		
		
		
		
		string CheckAspectRatio(string inFiletoCheck)
			
		{
		
		string returnAspect = "";
			
			string argumenttoProcess = String.Format("-i " + "{0}", inFiletoCheck);
			
			   Process proc = new Process ();
                proc.StartInfo.FileName = ffmpegPath;
                proc.StartInfo.Arguments = argumenttoProcess;
                proc.StartInfo.RedirectStandardError = true;
                proc.StartInfo.UseShellExecute = false;
                proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                proc.StartInfo.CreateNoWindow = true;
                if (!proc.Start()) {
                        MessageBox.Show("Error starting");
                        return returnAspect;
                }
                StreamReader reader = proc.StandardError;
                string line;
                while ((line = reader.ReadLine()) != null) {
                      
                	if (line.Contains("Stream") && line.Contains("Video"))
                	{
                	
                		int i = line.IndexOf('x');
                		string thisAspect = String.Format("{0}", line.Substring(i-4,9)).Trim();
                		return thisAspect;
                		
                		
                		
                //	MessageBox.Show(parsedDuration);
                	}
                	
			
			
			
		
                }
                
                return returnAspect;
		
		}
		void MusicCheckBoxCheckedChanged(object sender, EventArgs e)
		{
			
			PlaySound();
			
	
		}
		
		
		private void PlaySound()
			
		{
		
			SoundPlayer safeandSound = new SoundPlayer(@"c:\Utils\Bin\An.wav");
			
			safeandSound.PlayLooping();
		
		}
	
		
		
		
	
		
		
		
		

	}

	
		
	}
	
	
	

		
	
		
	
	
	
	
	
	
	

	

