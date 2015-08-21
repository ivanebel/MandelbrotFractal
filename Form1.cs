using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Threading;

namespace MandelbrotCS
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
        private System.Windows.Forms.MainMenu mainMenu1;
        private IContainer components;
        private System.Windows.Forms.MenuItem mnuFractal;
        private System.Windows.Forms.MenuItem mnuSettings;
        private System.Windows.Forms.MenuItem mnuStart;
        private System.Windows.Forms.MenuItem mnuPause;
        private System.Windows.Forms.MenuItem mnuContinue;
        private System.Windows.Forms.MenuItem mnuExit;
        private System.Windows.Forms.MenuItem mnuStop;
        //The options form.
        private frmOptions fo;
        //True if a set is being generated.
        private bool running;
        //True if the thread is paused.
        private bool paused;
        //For the thread.
        private Thread thread;
        //For the shadow bitmap.
        private Bitmap bmp = null;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
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
            this.components = new System.ComponentModel.Container();
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.mnuFractal = new System.Windows.Forms.MenuItem();
            this.mnuSettings = new System.Windows.Forms.MenuItem();
            this.mnuStart = new System.Windows.Forms.MenuItem();
            this.mnuPause = new System.Windows.Forms.MenuItem();
            this.mnuContinue = new System.Windows.Forms.MenuItem();
            this.mnuStop = new System.Windows.Forms.MenuItem();
            this.mnuExit = new System.Windows.Forms.MenuItem();
            this.SuspendLayout();
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuFractal});
            // 
            // mnuFractal
            // 
            this.mnuFractal.Index = 0;
            this.mnuFractal.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuSettings,
            this.mnuStart,
            this.mnuPause,
            this.mnuContinue,
            this.mnuStop,
            this.mnuExit});
            this.mnuFractal.Text = "&Fractal";
            this.mnuFractal.Select += new System.EventHandler(this.mnuFractal_Select);
            // 
            // mnuSettings
            // 
            this.mnuSettings.Index = 0;
            this.mnuSettings.Text = "S&ettings";
            this.mnuSettings.Click += new System.EventHandler(this.mnuSettings_Click);
            // 
            // mnuStart
            // 
            this.mnuStart.Index = 1;
            this.mnuStart.Text = "&Start";
            this.mnuStart.Click += new System.EventHandler(this.mnuStart_Click);
            // 
            // mnuPause
            // 
            this.mnuPause.Index = 2;
            this.mnuPause.Text = "&Pause";
            this.mnuPause.Click += new System.EventHandler(this.mnuPause_Click);
            // 
            // mnuContinue
            // 
            this.mnuContinue.Index = 3;
            this.mnuContinue.Text = "&Continue";
            this.mnuContinue.Click += new System.EventHandler(this.mnuContinue_Click);
            // 
            // mnuStop
            // 
            this.mnuStop.Index = 4;
            this.mnuStop.Text = "S&top";
            this.mnuStop.Click += new System.EventHandler(this.mnuStop_Click);
            // 
            // mnuExit
            // 
            this.mnuExit.Index = 5;
            this.mnuExit.Text = "E&xit";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // Form1
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(744, 489);
            this.Menu = this.mainMenu1;
            this.Name = "Form1";
            this.Text = "Mandelbrodt Set";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

        private void mnuSettings_Click(object sender, System.EventArgs e)
        {
            //The settings command.
            fo.ShowDialog();
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {
            //Initialze the options form.
            fo = new frmOptions();
            running = false;
            paused = false;
            this.Text = "Mandelbrot Set";
            Form1.CheckForIllegalCrossThreadCalls = false;
        }

        private void mnuFractal_Select(object sender, System.EventArgs e)
        {
            //Enable/disable menu commands based on program state.
            mnuStop.Enabled = false;
            mnuPause.Enabled = false;
            mnuContinue.Enabled = false;
            mnuSettings.Enabled = true;
            mnuExit.Enabled = true;
            mnuStart.Enabled = true;

            if (running)
            {
                mnuStop.Enabled = true;
                mnuPause.Enabled = true;
                mnuContinue.Enabled = false;
                mnuSettings.Enabled = false;
                mnuExit.Enabled = false;
                mnuStart.Enabled = false;
            }
            
            if (paused)
            {
                mnuStop.Enabled = false;
                mnuPause.Enabled = false;
                mnuContinue.Enabled = true;
                mnuSettings.Enabled = false;
                mnuExit.Enabled = false;
                mnuStart.Enabled = false;
            }
        }

        private void mnuExit_Click(object sender, System.EventArgs e)
        {
            Application.Exit();
        }

        private void mnuStart_Click(object sender, System.EventArgs e)
        {
            thread = new Thread(new ThreadStart(MakeFractal));
            running = true;
            thread.Start();
        }

        private void MakeFractal()
        {
            int x, y, z, numIter = 0, xPixels, yPixels;
            Graphics gScreen = this.CreateGraphics();
            //Get the form's client size.
            Size sz = this.ClientSize;
            //The shadow bitmap - same size as the current form's
            //client area.
            bmp = new Bitmap(sz.Width, sz.Height);
            //Graphics object for the bitmap.
            Graphics gBitmap = Graphics.FromImage(bmp);
            //The pen for drawing.
            Pen p = Pens.Black;
            //The array of color pens.
            Pen[] colorPens = new Pen[36];
            colorPens[0] = Pens.Red;
            colorPens[1] = Pens.Gold;
            colorPens[2] = Pens.Green;
            colorPens[3] = Pens.Fuchsia ;
            colorPens[4] = Pens.Yellow;
            colorPens[5] = Pens.Blue;
            colorPens[6] = Pens.Gray;
            colorPens[7] = Pens.Orange;
            colorPens[8] = Pens.White;
            colorPens[9] = Pens.Red;
            colorPens[10] = Pens.Gold;
            colorPens[11] = Pens.Green;
            colorPens[12] = Pens.Fuchsia;
            colorPens[13] = Pens.Yellow;
            colorPens[14] = Pens.Blue;
            colorPens[15] = Pens.Gray;
            colorPens[16] = Pens.Orange;
            colorPens[17] = Pens.White;
            colorPens[18] = Pens.Red;
            colorPens[19] = Pens.Gold;
            colorPens[20] = Pens.Green;
            colorPens[21] = Pens.Fuchsia;
            colorPens[22] = Pens.Yellow;
            colorPens[23] = Pens.Blue;
            colorPens[24] = Pens.Gray;
            colorPens[25] = Pens.Orange;
            colorPens[26] = Pens.White;
            colorPens[27] = Pens.Red;
            colorPens[28] = Pens.Gold;
            colorPens[29] = Pens.Green;
            colorPens[30] = Pens.Fuchsia;
            colorPens[31] = Pens.Yellow;
            colorPens[32] = Pens.Blue;
            colorPens[33] = Pens.Gray;
            colorPens[34] = Pens.Orange;
            colorPens[35] = Pens.White;
          
            Complex currentPoint = new Complex();
            Complex c = new Complex();
            Complex c1 = new Complex();
            Complex c2 = new Complex();
            //Change form caption.
            //Form1.ActiveForm.Text = "Calculating...";
            //Get the parameters from the options form.
            Complex TopLeft = new Complex();
            TopLeft.a = fo.TLReal;
            TopLeft.b = fo.TLImag;
            Complex BottomRight = new Complex();
            BottomRight.a = fo.BRReal;
            BottomRight.b = fo.BRImag;
            int iter = fo.Iterations;
            Boolean useColor = fo.useColor;
            //Make the form non-sizable.
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            //Get the pixel size of the client area.
            xPixels = this.ClientSize.Width;
            yPixels = this.ClientSize.Height;
            //Determine the deltas - the amount that the real and
            //Imaginary values will be incremented.
            double xDelta = (BottomRight.a - TopLeft.a)/xPixels;
            double yDelta = (TopLeft.b - BottomRight.b)/yPixels;
            currentPoint = TopLeft;
            bool InSet;
            for (x = 0; x < xPixels; x++)
            {
                for (y = 0; y < yPixels; y++)
                {
                    InSet = true;
                    c = currentPoint;
                    for (z = 1; z <= iter; z++)
                    {
                        c1 = ComplexMath.Square(c);
                        c2 = ComplexMath.Sum(c1, currentPoint);
                        //See if the modulus is > 2. The following line
                        //avoids taking a square root and compares against 4,
                        //saving calculation time.
                        if ((c2.a * c2.a) + (c2.b * c2.b) > 4)
                        {
                            InSet = false;
                            if (z < 36)
                                numIter = z;
                            else
                                numIter = 36;
                            break;
                        }
                        //Update the point.
                        c = c2;
                    }
                    if (InSet)
                    {
                        gScreen.DrawLine(p, x, y, x, y + 1);
                        gBitmap.DrawLine(p, x, y, x, y + 1);
                    }
                    else
                        if (useColor)
                      {
                            gScreen.DrawLine(colorPens[numIter-1], x, y, x, y + 1);
                            gBitmap.DrawLine(colorPens[numIter-1], x, y, x, y + 1);
                        }

                    //Increment the imaginary part.
                    currentPoint.b -= yDelta;
                }
                //Reset the imag value.
                currentPoint.b = TopLeft.b;
                //Increment the real part.
                currentPoint.a += xDelta;
            }
            //Make the form sizable again.
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.Text = "Mandelbrot Set";
            running = false;
        }

        private void mnuPause_Click(object sender, System.EventArgs e)
        {
            thread.Suspend();
            running = false;
            paused = true;
            this.Text = "Paused";
        }

        private void mnuContinue_Click(object sender, System.EventArgs e)
        {
            thread.Resume();
            running = true;
            paused = false;
            //Change form caption.
            this.Text = "Calculating...";
        }

        private void mnuStop_Click(object sender, System.EventArgs e)
        {
            thread.Abort();
            running = false;
            this.Text = "Mandelbrot Set";
        }

        private void Form1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            if (bmp != null)
                e.Graphics.DrawImage(bmp, 0, 0);
        }
	}
}
