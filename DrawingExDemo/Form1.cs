using System;

using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using DrawingEx.IconEncoder;
using DrawingEx.ColorManagement.ColorModels;
using DrawingEx.ColorManagement.Gradients;
using System.Drawing.Drawing2D;
using System.Drawing;
using System.Threading;
using System.Globalization;

namespace DrawingExDemo
{
	/// <summary>
	/// Zusammenfassung für Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private DrawingExDemo.icnpicturebox icnpicturebox1;
		private DrawingEx.ColorManagement.ColorDialogEx colorDialogEx1;
		private System.Windows.Forms.Label label1;
		private PictureBox pictureBox1;
		private Label label2;
		/// <summary>
		/// Erforderliche Designervariable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Erforderlich für die Windows Form-Designerunterstützung
			//
			InitializeComponent();

			//
			// TODO: Fügen Sie den Konstruktorcode nach dem Aufruf von InitializeComponent hinzu
			//
			grd = new Gradient();
			grd.Alphas.Add(new AlphaPoint(255, 0.0));
			grd.Alphas.Add(new AlphaPoint(255, 1.0));
			grd.Colors.Add(new ColorPoint(Color.Red, 0.0));
			grd.Colors.Add(new ColorPoint(Color.Blue, 1.0));
			grd.Colors[1].Focus = 0.1;
			coll.Add(grd);
		}

		/// <summary>
		/// Die verwendeten Ressourcen bereinigen.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		#region Vom Windows Form-Designer generierter Code
		/// <summary>
		/// Erforderliche Methode für die Designerunterstützung. 
		/// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.icnpicturebox1 = new DrawingExDemo.icnpicturebox();
			this.colorDialogEx1 = new DrawingEx.ColorManagement.ColorDialogEx();
			this.label1 = new System.Windows.Forms.Label();
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.label2 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			this.SuspendLayout();
			// 
			// icnpicturebox1
			// 
			this.icnpicturebox1.BackColor = System.Drawing.SystemColors.AppWorkspace;
			this.icnpicturebox1.Icon = ((DrawingEx.IconEncoder.Icon)(resources.GetObject("icnpicturebox1.Icon")));
			this.icnpicturebox1.Location = new System.Drawing.Point(56, 32);
			this.icnpicturebox1.Name = "icnpicturebox1";
			this.icnpicturebox1.Size = new System.Drawing.Size(184, 72);
			this.icnpicturebox1.TabIndex = 1;
			this.icnpicturebox1.Click += new System.EventHandler(this.icnpicturebox1_Click);
			// 
			// colorDialogEx1
			// 
			this.colorDialogEx1.Color = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(56, 103);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(184, 24);
			this.label1.TabIndex = 2;
			this.label1.Text = "click here ^^ to choose a color";
			this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// pictureBox1
			// 
			this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pictureBox1.Location = new System.Drawing.Point(56, 144);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(184, 72);
			this.pictureBox1.TabIndex = 3;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
			this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(56, 216);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(184, 24);
			this.label2.TabIndex = 2;
			this.label2.Text = "click here ^^ to choose a gradient";
			this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(298, 272);
			this.Controls.Add(this.pictureBox1);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.icnpicturebox1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MaximumSize = new System.Drawing.Size(304, 300);
			this.MinimumSize = new System.Drawing.Size(304, 300);
			this.Name = "Form1";
			this.Text = "DrawingEx Demo";
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// Der Haupteinstiegspunkt für die Anwendung.
		/// </summary>
		[STAThread]
		static void Main()
		{
			//Thread.CurrentThread.CurrentCulture =
			//    Thread.CurrentThread.CurrentUICulture =
			//    new CultureInfo("de-DE");
			Application.EnableVisualStyles();
			Application.Run(new Form1());
		}

		private void icnpicturebox1_Click(object sender, System.EventArgs e)
		{
			colorDialogEx1.Color = icnpicturebox1.BackColor;
			if (colorDialogEx1.ShowDialog(this) == DialogResult.OK)
				icnpicturebox1.BackColor = colorDialogEx1.Color;
		}
		//gradients
		private GradientCollection coll = new GradientCollection();
		private Gradient grd = null;
		private void pictureBox1_Click(object sender, EventArgs e)
		{
			using (GradientCollectionEditor edit = new GradientCollectionEditor())
			{
				//normally, you would use edit.Gradients.Load(...)
				foreach (Gradient g in coll)
					edit.Gradients.Add(g);
				edit.SelectedGradient = grd;
				//
				if (edit.ShowDialog() == DialogResult.OK)
				{
					//normally, you would use edit.Gradients.Save(...)
					coll.Clear();
					foreach (Gradient g in edit.Gradients)
						coll.Add(g);
					grd = edit.SelectedGradient;
					//
					pictureBox1.Refresh();
				}
			}
		}

		private void pictureBox1_Paint(object sender, PaintEventArgs e)
		{
			using (HatchBrush hbrs = new HatchBrush(HatchStyle.LargeCheckerBoard,
				Color.Silver, Color.White))
			{
				e.Graphics.FillRectangle(hbrs, pictureBox1.ClientRectangle);
			}
			if (grd != null)
			{
				using (LinearGradientBrush lnbrs = new LinearGradientBrush(
					new Point(0, 0), new Point(Math.Max(1, pictureBox1.Width), 0),
					Color.Transparent, Color.Black))
				{
					lnbrs.InterpolationColors = grd;
					e.Graphics.FillRectangle(lnbrs, pictureBox1.ClientRectangle);
				}
			}
		}
	}
}