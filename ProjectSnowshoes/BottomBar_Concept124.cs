﻿using ImageProcessor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Transitions;

namespace ProjectSnowshoes
{
    public partial class BottomBar_Concept124 : Form
    {

        int heightToUseInAdj;
        int currentCountProc = 0;
        Boolean stillHere = true;

        Transition red = new Transition(new TransitionType_EaseInEaseOut(300));

        Transition orange = new Transition(new TransitionType_EaseInEaseOut(300));

        Transition yellow = new Transition(new TransitionType_EaseInEaseOut(300));

        Transition green = new Transition(new TransitionType_EaseInEaseOut(300));

        Transition blue = new Transition(new TransitionType_EaseInEaseOut(300));

        Transition indigo = new Transition(new TransitionType_EaseInEaseOut(300));

        Transition violet = new Transition(new TransitionType_EaseInEaseOut(300));

        Transition custCol = new Transition(new TransitionType_EaseInEaseOut(300));

        Transition final = new Transition(new TransitionType_EaseInEaseOut(300));

        Label newTSC = new Label();


        [DllImport("user32.dll", SetLastError = true)]
        static extern void ShowWindow(IntPtr hWnd, int nCmdShow);

        public BottomBar_Concept124(int canYouBelieveThis)
        {
            heightToUseInAdj = canYouBelieveThis;
            InitializeComponent();
        }



        private void BottomBar_Concept124_Load(object sender, EventArgs e)
        {


            // Adjust size

            this.Width = Screen.PrimaryScreen.WorkingArea.Width;
            this.Height = heightToUseInAdj - Screen.PrimaryScreen.WorkingArea.Height;
            this.Top = Screen.PrimaryScreen.WorkingArea.Height;
            this.Left = 0;

            // Left Account Information 

            name.Text = Properties.Settings.Default.nickname[Properties.Settings.Default.whoIsThisCrazyDoge];

            // Custom Color Integration

            name.BackColor = Color.FromName(Properties.Settings.Default.custColor[Properties.Settings.Default.whoIsThisCrazyDoge]);

            // Adjustment of Font and Resolution

            name.Font = new System.Drawing.Font(Properties.Settings.Default.fontsOfScience[Properties.Settings.Default.whoIsThisCrazyDoge], 14);

            timeSpaceContinuum.Visible = false;
            //timeSpaceContinuum.Font = new System.Drawing.Font(Properties.Settings.Default.fontsOfScience[Properties.Settings.Default.whoIsThisCrazyDoge], 9);

            name.Width = 145;

            // Load processes

            spaceForProcesses.Top = 0;
            spaceForProcesses.Left = 150;
            spaceForProcesses.Width = spaceForProcesses.Width - 150;

            //spaceForProcesses.Top = this.Top;


            spaceForProcesses.Height = this.Height;

            spaceForProcesses.Invalidate();

            newTSC.TextAlign = ContentAlignment.MiddleCenter;
            newTSC.Dock = DockStyle.Right;
            newTSC.Width = 60;
            newTSC.ForeColor = Color.Black;
            newTSC.Font = new System.Drawing.Font(Properties.Settings.Default.fontsOfScience[Properties.Settings.Default.whoIsThisCrazyDoge], 9);
            newTSC.BringToFront();

            this.Controls.Add(newTSC);

            this.Invalidate();

        }

        private void timeTimer_Tick(object sender, EventArgs e)
        {
            newTSC.Text = System.DateTime.Now.ToShortTimeString();

            goGenerateProcessesFriendship();
        }

        private void name_Click(object sender, EventArgs e)
        {
            Boolean itsOpen = false;

            for (int i = 0; i < Application.OpenForms.Count; i++)
            {
                if (Application.OpenForms[i].Name == "SlidingMenuBarPostEG")
                {
                    itsOpen = true;
                    Application.OpenForms[i].Close();
                }
            }

            if (!itsOpen)
            {
                SlidingMenuBarPostEG slidingMenu = new SlidingMenuBarPostEG();
                slidingMenu.Show();
                slidingMenu.BringToFront();
            }


        }

        private void timeSpaceContinuum_Click(object sender, EventArgs e)
        {
            UserSettings snoopdoge = new UserSettings();
            snoopdoge.Show();
            snoopdoge.BringToFront();
        }

        private void dogeAccountImg_Click(object sender, EventArgs e)
        {
            MinervaIntegrated minervuh = new MinervaIntegrated();

            minervuh.Show();
            minervuh.BringToFront();
        }

        delegate bool EnumThreadDelegate(IntPtr hWnd, IntPtr lParam);
        [DllImport("user32.dll")]
        static extern bool EnumThreadWindows(int dwThreadId, EnumThreadDelegate lpfn,
        IntPtr lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder lpString, int nMaxCount);
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern int GetWindowTextLength(IntPtr hWnd);
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool IsWindowVisible(IntPtr hWnd);

        private IEnumerable<IntPtr> getHandles(Process proc)
        {
            // This is my first work with handles on Windows in a while, so 
            // please be kind...also, thanks to Stack Overflow (Spirin, K) for posting 
            // an elegant solution that handles this...a lot of what you see ahead 
            // is basically a re-transcription of his response!

            var h = new List<IntPtr>(); // Seriously, match this line. It's nearly identical.

            foreach (ProcessThread t in proc.Threads)
            {
                EnumThreadWindows(t.Id, (hWnd, lParam) => { h.Add(hWnd); return true; }, IntPtr.Zero);
            }

            return h;

        }

        private void goGenerateProcessesFriendship()
        {
            
            int artOfficial = Process.GetProcesses().Length;
            
            /* Previous code for tallying after we get the processes...which is just a waste of time. Still, it's here. 
            foreach (var theProcess in Process.GetProcesses())
            {
                if (theProcess.MainWindowTitle != "" && theProcess.MainWindowTitle != "Space")
                {
                    artOfficial++;
                }
            }*/
            

            if (artOfficial != currentCountProc)
            {
                spaceForProcesses.Controls.Clear();
                int procCount = 0;
                foreach (var theProcess in Process.GetProcesses())
                {

                    if (procCount != 0 && procCount != 4)
                    {

                        if ((theProcess.MainWindowTitle != "" && theProcess.Modules[0].FileName != "ProjectSnowshoes.exe") && theProcess.MainWindowHandle != null)
                        {
                            foreach (var h in getHandles(theProcess))
                            {
                                if (IsWindowVisible(h))
                                {
                                    PictureBox hmGreatJobFantasticAmazing = new PictureBox();
                                    StringBuilder sb = new StringBuilder(GetWindowTextLength(h) + 1);
                                    GetWindowText(h, sb, sb.Capacity);




                                    hmGreatJobFantasticAmazing.Margin = new Padding(6, 0, 6, 0);
                                    hmGreatJobFantasticAmazing.Visible = true;
                                    hmGreatJobFantasticAmazing.SizeMode = PictureBoxSizeMode.CenterImage;
                                    hmGreatJobFantasticAmazing.BackgroundImageLayout = ImageLayout.Zoom;

                                    Icon.ExtractAssociatedIcon(theProcess.Modules[0].FileName).ToBitmap().Save(@"C:\ProjectSnowshoes\temptaskico.png");

                                    ImageFactory grayify = new ImageFactory();
                                    grayify.Load(@"C:\ProjectSnowshoes\temptaskico.png");
                                    Size sizeeeee = new System.Drawing.Size();
                                    sizeeeee.Height = 20;
                                    sizeeeee.Width = 20;
                                    ImageProcessor.Imaging.ResizeLayer reLay = new ImageProcessor.Imaging.ResizeLayer(sizeeeee);
                                    grayify.Resize(reLay);

                                    hmGreatJobFantasticAmazing.Image = grayify.Image;
                                    hmGreatJobFantasticAmazing.Click += (sender, args) =>
                                    {

                                        ShowWindow(theProcess.MainWindowHandle, 5);
                                        ShowWindow(theProcess.MainWindowHandle, 9);
                                    };
                                    hmGreatJobFantasticAmazing.MouseHover += (sender, args) =>
                                    {
                                        Properties.Settings.Default.stayHere = true;
                                        Properties.Settings.Default.Save();
                                        int recordNao = hmGreatJobFantasticAmazing.Left;

                                        hmGreatJobFantasticAmazing.Image.Save(@"C:\ProjectSnowshoes\TheyNeedToKeepOriginalAlbums.png");
                                        Size sizeeeeeA = new System.Drawing.Size();
                                        sizeeeeeA.Height = 100;
                                        sizeeeeeA.Width = 100;
                                        ImageProcessor.Imaging.ResizeLayer reLayA = new ImageProcessor.Imaging.ResizeLayer(sizeeeeeA);
                                        ImageProcessor.Imaging.GaussianLayer gauLay = new ImageProcessor.Imaging.GaussianLayer();
                                        gauLay.Sigma = 2;
                                        gauLay.Threshold = 10;
                                        gauLay.Size = 20;
                                        ImageFactory backify = new ImageFactory();
                                        backify.Load(@"C:\ProjectSnowshoes\TheyNeedToKeepOriginalAlbums.png");
                                        backify.Brightness(-30);
                                        backify.Resize(reLayA);
                                        backify.GaussianBlur(gauLay);
                                        ImageProcessor.Imaging.CropLayer notAsLongAsOriginalName = new ImageProcessor.Imaging.CropLayer(90, 0, 0, 0, ImageProcessor.Imaging.CropMode.Percentage);
                                        backify.Crop(new Rectangle(25, (100 - this.Height) / 2, 50, this.Height));
                                        hmGreatJobFantasticAmazing.BackgroundImage = backify.Image;
                                        grayify.Save(@"C:\ProjectSnowshoes\TheyStillNeedToKeepOriginalAlbums.png");
                                        ImageFactory grayifyA = new ImageFactory();
                                        grayifyA.Load(@"C:\ProjectSnowshoes\TheyStillNeedToKeepOriginalAlbums.png");
                                        grayifyA.Saturation(44);
                                        grayifyA.Brightness(42);
                                        hmGreatJobFantasticAmazing.Image = grayifyA.Image;
                                        // Yeahhhhhhhhh I'm going to have to do this another way
                                        // panel1.Controls.Add(areYouSeriouslyStillDoingThisLetItGo);
                                        // Oh
                                        // I can just make another form to draw over and go have turnips with parameters
                                        // Also credits to Microsoft Word's "Sentence Case" option as this came out in all caps originally
                                        // Measuring string turnt-up-edness was guided by an answer on Stack Overflow by Tom Anderson.
                                        String keepThisShortWeNeedToOptimize = sb.ToString().Replace("&", "&&");
                                        Graphics heyGuessWhatGraphicsYeahThatsRight = Graphics.FromImage(new Bitmap(1, 1));
                                        SizeF sure = heyGuessWhatGraphicsYeahThatsRight.MeasureString(keepThisShortWeNeedToOptimize, new System.Drawing.Font(Properties.Settings.Default.fontsOfScience[Properties.Settings.Default.whoIsThisCrazyDoge], 14, FontStyle.Regular, GraphicsUnit.Point));
                                        Size sureAgain = sure.ToSize();
                                        int recordThatJim;
                                        if (sureAgain.Width >= 300)
                                        {
                                            recordThatJim = sureAgain.Width + 10;
                                        }
                                        else
                                        {
                                            recordThatJim = 300;
                                        }
                                        CanWeMakeAHoverFormLikeThisIsThisLegal notAsLongInstanceName = new CanWeMakeAHoverFormLikeThisIsThisLegal(recordNao + 150, this.Height, recordThatJim, keepThisShortWeNeedToOptimize);
                                        notAsLongInstanceName.Show();
                                        notAsLongInstanceName.BringToFront();
                                        //hmGreatJobFantasticAmazing.BringToFront();
                                        //panel1.Controls.Add(hmGreatJobFantasticAmazing);
                                        //hmGreatJobFantasticAmazing.Top = this.Top - 40;
                                        //hmGreatJobFantasticAmazing.Left = recordNao + 150;
                                        //hmGreatJobFantasticAmazing.BringToFront();
                                        //hmGreatJobFantasticAmazing.Invalidate();
                                        /*hmGreatJobFantasticAmazing.Height = 100;
                                        hmGreatJobFantasticAmazing.Width = 100;*/
                                    };
                                    hmGreatJobFantasticAmazing.MouseLeave += (sender, args) =>
                                    {
                                        /*hmGreatJobFantasticAmazing.ImageAlign = ContentAlignment.MiddleCenter;
                                        hmGreatJobFantasticAmazing.AutoEllipsis = false;
                                        hmGreatJobFantasticAmazing.Width = 40;
                                        hmGreatJobFantasticAmazing.BackColor = Color.Transparent;
                                        //hmGreatJobFantasticAmazing.Font = new System.Drawing.Font(Properties.Settings.Default.fontsOfScience[Properties.Settings.Default.whoIsThisCrazyDoge], 14, FontStyle.Regular);
                                        //hmGreatJobFantasticAmazing.ForeColor = Color.White;
                                        hmGreatJobFantasticAmazing.TextAlign = ContentAlignment.MiddleLeft;
                                        hmGreatJobFantasticAmazing.Text = "";*/
                                        try
                                        {
                                            Application.OpenForms["CanWeMakeAHoverFormLikeThisIsThisLegal"].Close();
                                        }
                                        catch (Exception exTurnip) { }
                                        hmGreatJobFantasticAmazing.BackgroundImage = null;
                                        hmGreatJobFantasticAmazing.Invalidate();
                                        Properties.Settings.Default.stayHere = false;
                                        Properties.Settings.Default.Save();
                                        hmGreatJobFantasticAmazing.Image = grayify.Image;
                                    };
                                    //openFileToolTip.SetToolTip(hmGreatJobFantasticAmazing, theProcess.MainWindowTitle);
                                    //hmGreatJobFantasticAmazing.BackgroundImage = Icon.ExtractAssociatedIcon(theProcess.Modules[0].FileName).ToBitmap();
                                    hmGreatJobFantasticAmazing.Height = this.Height;
                                    hmGreatJobFantasticAmazing.Width = 50;
                                    spaceForProcesses.Controls.Add(hmGreatJobFantasticAmazing);
                                }
                            }
                        }

                    }
                    procCount++;
                }

            }

            currentCountProc = artOfficial;


        }


    }
}