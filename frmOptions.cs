using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace MandelbrotCS
{
	/// <summary>
	/// Summary description for frmOptions.
	/// </summary>
	public class frmOptions : System.Windows.Forms.Form
	{
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox txtTLReal;
        private System.Windows.Forms.TextBox txtTLImag;
        private System.Windows.Forms.TextBox txtBRReal;
        private System.Windows.Forms.TextBox txtBRImag;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtIterations;
        private System.Windows.Forms.Button button1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
        //The fields hold the parameter values.
        public double TLReal, TLImag, BRReal, BRImag;
        public Boolean useColor = false;
        private CheckBox chkUseColor;
        public int Iterations;

		public frmOptions()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

            //Initialze the parameter values with defaults.
            TLReal = -2.1;
            TLImag = 1.2;
            BRReal = 1.0;
            BRImag = -1.2;
            Iterations = 50;
            //Display them in the text boxes.
            txtTLReal.Text = TLReal.ToString();
            txtTLImag.Text = TLImag.ToString();
            txtBRReal.Text = BRReal.ToString();
            txtBRImag.Text = BRImag.ToString();
            txtIterations.Text = Iterations.ToString();
            chkUseColor.Checked = useColor;
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.txtTLReal = new System.Windows.Forms.TextBox();
            this.txtTLImag = new System.Windows.Forms.TextBox();
            this.txtBRReal = new System.Windows.Forms.TextBox();
            this.txtBRImag = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtIterations = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.chkUseColor = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(32, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Top left corner, real part:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(40, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "Imaginary part:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(-8, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(168, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "Bottom right corner, real part:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(40, 120);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 24);
            this.label4.TabIndex = 3;
            this.label4.Text = "Imaginary part:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(272, 136);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(88, 32);
            this.btnOK.TabIndex = 4;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtTLReal
            // 
            this.txtTLReal.Location = new System.Drawing.Point(176, 24);
            this.txtTLReal.Name = "txtTLReal";
            this.txtTLReal.Size = new System.Drawing.Size(48, 20);
            this.txtTLReal.TabIndex = 5;
            this.txtTLReal.Text = "-2.1";
            // 
            // txtTLImag
            // 
            this.txtTLImag.Location = new System.Drawing.Point(176, 56);
            this.txtTLImag.Name = "txtTLImag";
            this.txtTLImag.Size = new System.Drawing.Size(48, 20);
            this.txtTLImag.TabIndex = 6;
            this.txtTLImag.Text = "1.2";
            // 
            // txtBRReal
            // 
            this.txtBRReal.Location = new System.Drawing.Point(176, 88);
            this.txtBRReal.Name = "txtBRReal";
            this.txtBRReal.Size = new System.Drawing.Size(48, 20);
            this.txtBRReal.TabIndex = 7;
            this.txtBRReal.Text = "-1.2";
            // 
            // txtBRImag
            // 
            this.txtBRImag.Location = new System.Drawing.Point(176, 120);
            this.txtBRImag.Name = "txtBRImag";
            this.txtBRImag.Size = new System.Drawing.Size(48, 20);
            this.txtBRImag.TabIndex = 8;
            this.txtBRImag.Text = "-1.2";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(48, 160);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 16);
            this.label5.TabIndex = 9;
            this.label5.Text = "Iterations:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txtIterations
            // 
            this.txtIterations.Location = new System.Drawing.Point(176, 152);
            this.txtIterations.Name = "txtIterations";
            this.txtIterations.Size = new System.Drawing.Size(48, 20);
            this.txtIterations.TabIndex = 10;
            this.txtIterations.Text = "20";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(272, 88);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 32);
            this.button1.TabIndex = 11;
            this.button1.Text = "Cancel";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // chkUseColor
            // 
            this.chkUseColor.AutoSize = true;
            this.chkUseColor.Location = new System.Drawing.Point(272, 31);
            this.chkUseColor.Name = "chkUseColor";
            this.chkUseColor.Size = new System.Drawing.Size(72, 17);
            this.chkUseColor.TabIndex = 12;
            this.chkUseColor.Text = "Use Color";
            this.chkUseColor.UseVisualStyleBackColor = true;
            // 
            // frmOptions
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(376, 197);
            this.Controls.Add(this.chkUseColor);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtIterations);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtBRImag);
            this.Controls.Add(this.txtBRReal);
            this.Controls.Add(this.txtTLImag);
            this.Controls.Add(this.txtTLReal);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmOptions";
            this.Text = "Mandelbrot Parameters";
            this.ResumeLayout(false);
            this.PerformLayout();

        }
		#endregion


        private void button1_Click(object sender, System.EventArgs e)
        {
            //User cancelled. Do not save values and return old values
            //to the text boxes.
            txtTLReal.Text = TLReal.ToString();
            txtTLImag.Text = TLImag.ToString();
            txtBRReal.Text = BRReal.ToString();
            txtBRImag.Text = BRImag.ToString();
            txtIterations.Text = Iterations.ToString();
            chkUseColor.Checked = useColor;
            this.Hide();
        }

        private void btnOK_Click(object sender, System.EventArgs e)
        {
            //User selects OK. Save values.
            TLReal = double.Parse(txtTLReal.Text);
            TLImag = double.Parse(txtTLImag.Text);
            BRReal = double.Parse(txtBRReal.Text);
            BRImag = double.Parse(txtBRImag.Text);
            Iterations = int.Parse(txtIterations.Text);
            useColor = chkUseColor.Checked;
            this.Hide();
        }
	}
}
