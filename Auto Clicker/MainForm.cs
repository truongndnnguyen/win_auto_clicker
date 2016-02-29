using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Threading;
using System.Runtime.InteropServices;
using System.Linq;
using MouseKeyboardActivityMonitor;
using MouseKeyboardActivityMonitor.WinApi;
using System.IO;
using System.Xml.Linq;
using System.Text.RegularExpressions;




//Ryan Harrison 2011
//raharrison.co.uk
//mail@raharrison.co.uk

namespace Auto_Clicker
{



    public partial class MainForm : Form
    {
        public static int DELAY_TIME = 20;
        public const int NOMOD = 0x0000;

        public const int ALT = 0x0001;

        public const int CTRL = 0x0002;

        public const int SHIFT = 0x0004;

        public const int WIN = 0x0008;



        //windows message id for hotkey

        public const int WM_HOTKEY_MSG_ID = 0x0312;

        KeyboardHook hook = new KeyboardHook();
        //http://www.liensberger.it/web/blog/?p=207

        #region Global Variables and Properties

        private Thread ClickThread; //Thread to take care of clicking the mouse
                                    //so UI is not made unresponsive
        ClickPoints QueuePoints = new ClickPoints();
        private Point CurrentPosition { get; set; } //The current position of the mouse cursor
        private ClickPoint EditingPoint = null;

        #endregion

        #region Constructor


        #region Mouse Hook Event -

        // First, a MouseHookListener object must exist in the class
        private MouseHookListener m_mouseListener;

        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        public static extern IntPtr LoadCursorFromFile(string filename);

        // Subroutine for activating the hook
        public void ActivateMouseHook()
        {
            // Note: for an application hook, use the AppHooker class instead
            m_mouseListener = new MouseHookListener(new GlobalHooker());

            // The listener is not enabled by default
            m_mouseListener.Enabled = true;

            // Set the event handler
            // recommended to use the Extended handlers, which allow input suppression among other additional information
            m_mouseListener.MouseDownExt += MouseListener_MouseDownExt;
        }


        private bool isRecord = false;

        private void MouseListener_MouseDownExt(object sender, MouseEventExtArgs e)
        {
            // log the mouse click
            //Console.WriteLine(string.Format("MouseDown: \t{0}; \t System Timestamp: \t{1}", e.Button, e.Timestamp));

            // uncommenting the following line with suppress a middle mouse button click
            if (e.Button == MouseButtons.Right)
            {
                isRecord = false;
                updateLabelRecordButton();
                if (running)
                {

                    StopClickingButton_Click(null, null);
                }
            }
            if(e.Button == MouseButtons.Left && isRecord)
            {
                CopyToAddButton_Click(null, null);
                AddPositionButton_Click(null, null);

                drawMouseIndicator(Cursor.Position.X, Cursor.Position.Y, Color.Green, 32, QueuePoints.Count);
            }
        }

        public void DeactivateMouseHook()
        {
            m_mouseListener.Dispose();
        }
        #endregion
        /// <summary>
        /// Construct the form object and initialise all form components
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

            Boolean success = MainForm.RegisterHotKey(this.Handle, this.GetType().GetHashCode(), ALT | SHIFT, (int)Keys.S);//Set hotkey as 'b'
             success = MainForm.RegisterHotKey(this.Handle, this.GetType().GetHashCode(), ALT | SHIFT, (int)Keys.E);
            //MainForm.RegisterHotKey(this.Handle, this.GetType().GetHashCode(), ALT | SHIFT, (int)Keys.A);
            ActivateMouseHook();

            // register the event that is fired after the key press.
            /*hook.KeyPressed +=
                new EventHandler<KeyPressedEventArgs>(hook_KeyPressed);
            // register the control + alt + F12 combination as hot key.
            hook.RegisterHotKey(ModifierKeys.Control | ModifierKeys.Alt,
                Keys.F12);
        */
        }

        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, int fsModifiers, int vlc);
        //[DllImport("user32.dll")]
        //public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x0312)
            {
                //richTextBox1.Text += "\r\n" + m.Msg.ToString();
                //MessageBox.Show("Catched");//You can replace this statement with your desired response to the Hotkey.

                // get the keys.
                Keys key = (Keys)(((int)m.LParam >> 16) & 0xFFFF);
                ModifierKeys modifier = (ModifierKeys)((int)m.LParam & 0xFFFF);

                if (key == Keys.E && modifier == (Auto_Clicker.ModifierKeys.Alt | Auto_Clicker.ModifierKeys.Shift))
                {

                }
                    if (key == Keys.S && modifier == (Auto_Clicker.ModifierKeys.Alt | Auto_Clicker.ModifierKeys.Shift))
                {


                    if (running)
                    {

                        StopClickingButton_Click(null, null);
                    }
                    else
                    {
                        this.Show();
                        StartClickingButton_Click(null, null);
                    }
                }

                if (key == Keys.A && modifier == (Auto_Clicker.ModifierKeys.Alt | Auto_Clicker.ModifierKeys.Shift))
                {

                }

            }
            base.WndProc(ref m);
        }


        void hook_KeyPressed(object sender, KeyPressedEventArgs e)
        {
            // show the keys pressed in a label.
            stsFileName.Text = e.Modifier.ToString() + " + " + e.Key.ToString();
        }


        #endregion

        #region Form Component Events

        /// <summary>
        /// Start the timer to update the cursor position and clear all items in the list view
        /// when the form loads
        /// </summary>
        private void MainForm_Load(object sender, EventArgs e)
        {
            CurrentPositionTimer.Start();
            PositionsListView.Items.Clear();
            //load data from document
            try {

                workingDir = Path.Combine(Environment.ExpandEnvironmentVariables("%userprofile%"), "Documents");
                if (Directory.Exists(workingDir))
                {
                    var files = Directory.GetFiles(workingDir, "*.acf");

                    foreach (var item in files)
                    {
                        var f = Path.GetFileName(item);
                        comboBox1.Items.Add(f);
                    }
                }
            }
            catch(Exception ex)
            {

            }
        }

        /// <summary>
        /// Handle keyboard shortcuts from the user
        /// </summary>
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F1)
            {
                CopyToAddButton_Click(null, null);
            }
            else if (e.KeyCode == Keys.F2 || (e.Shift && e.Alt && e.KeyCode == Keys.A))
            {
                //MessageBox.Show("Start");
                CopyToAddButton_Click(null, null);
                AddPositionButton_Click(null, null);
            }
            else if (e.KeyCode == Keys.F3 || (e.Shift && e.Alt && e.KeyCode == Keys.S))
            {
                //MessageBox.Show("Start");
                StartClickingButton_Click(null, null);
            }
            else if (e.KeyCode == Keys.F4 || (e.Shift && e.Alt && e.KeyCode == Keys.E))
            {
                StopClickingButton_Click(null, null);
                //MessageBox.Show("End");
            }
        }

        /// <summary>
        /// Set the CurrentPosition property to the current position of the mouse cursor
        /// on screen on each interval of the timer
        /// </summary>
        private void CurrentPositionTimer_Tick(object sender, EventArgs e)
        {
            CurrentPosition = Cursor.Position;
            UpdateCurrentPositionTextBoxes();

        }

        /// <summary>
        /// Copy current position of the cursor to alternate textboxes so they are ready to 
        /// be queued by the user
        /// </summary>
        private void CopyToAddButton_Click(object sender, EventArgs e)
        {
            QueuedXPositionTextBox.Text = CurrentPosition.X.ToString();
            QueuedYPositionTextBox.Text = CurrentPosition.Y.ToString();
            
        }

        /// <summary>
        /// Add the point held in the queued textboxes to the listview so ready to be executed
        /// </summary>
        private void AddPositionButton_Click(object sender, EventArgs e)
        {
            if (CurrentPositionIsValid(QueuedXPositionTextBox.Text, QueuedYPositionTextBox.Text))
            {
                if (IsValidNumericalInput(SleepTimeTextBox.Text))
                {
                    //Add item holding coordinates, right/left click and sleep time to list view
                    //holding all queued clicks

                    string clickType = (RightClickCheckBox.Checked) == true ? "R" : "L";

                    int sleepTime = Convert.ToInt32(SleepTimeTextBox.Text);

                    ClickPoint point = new ClickPoint()
                    {
                        Index = QueuePoints.Count + 1,
                        X = int.Parse(QueuedXPositionTextBox.Text),
                        Y = int.Parse(QueuedYPositionTextBox.Text),
                        Wait = sleepTime,
                        Type = clickType,
                        Enable = true,
                        Note = txtNote.Text,


                    };
                    QueuePoints.Add(point);
                    AddPoint(point);
                }
                else
                {
                    MessageBox.Show("Sleep time is not a valid positive integer", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Current Coordinates are not valid", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddPoint(ClickPoint point)
        {
            ListViewItem item = new ListViewItem(point.Index.ToString());
            item.SubItems.Add(point.X.ToString());
            item.SubItems.Add(point.Y.ToString());

            item.SubItems.Add(point.Type);
            item.SubItems.Add(point.Wait.ToString());
            item.SubItems.Add(point.Note.ToString());
            PositionsListView.Items.Add(item);
            var total = QueuePoints.Sum(p => p.Wait) / 1000;

            stsTotalTimes.Text = string.Format("{0}s", total);

        }
        private bool running = false;

        /// <summary>
        /// Assign all points in the queue to the ClickHelper and start the thread
        /// </summary>
        private void StartClickingButton_Click(object sender, EventArgs e)
        {
            running = true;
            //Cursor = new Cursor(LoadCursorFromFile(@"C:\Users\truong.n.nguyen\Desktop\Auto_Clicker\Auto Clicker\Normal.cur"));
            if (IsValidNumericalInput(NumRepeatsTextBox.Text))
            {
                int iterations = Convert.ToInt32(NumRepeatsTextBox.Text);
                List<Point> points = new List<Point>();
                List<string> clickType = new List<string>();
                List<int> times = new List<int>();

                //foreach (ListViewItem item in PositionsListView.Items)
                foreach (var item in QueuePoints)
                {

                    //Add data in queued clicks to corresponding List collection
                    //int x = Convert.ToInt32(item.Text); //x coordinate
                    // int y = Convert.ToInt32(item.SubItems[1].Text); //y coordinate
                    //clickType.Add(item.SubItems[2].Text); //click type
                    //times.Add(Convert.ToInt32(item.SubItems[3].Text)); //sleep time

                    int x = item.X; //x coordinate
                    int y = item.Y; //y coordinate
                    clickType.Add(item.Type); //click type
                    times.Add(Convert.ToInt32(item.Wait)); //sleep time

                    points.Add(new Point(x, y));
                }
                try
                {
                    //Create a ClickHelper passing Lists of click information
                    if (Convert.ToInt32(txtSleeps.Text) > 0)
                    {
                        points.Add(new Point() { X = points[points.Count - 1].X, Y = points[points.Count - 1].Y });
                        clickType.Add("L");
                        times.Add(Convert.ToInt32(txtSleeps.Text) * 1000);
                    }
                    ClickThreadHelper helper = new ClickThreadHelper() { Points = points, ClickType = clickType, Iterations = iterations, Times = times };
                    //Create the thread passing the Run method
                    ClickThread = new Thread(new ThreadStart(helper.Run));
                    //Start the thread, thus starting the clicks
                    ClickThread.Start();
                    running = true;
                }
                catch (Exception exc)
                {
                   // MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Number of repeats is not a valid positive integer", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
      
        /// <summary>
        /// Abort the clicking thread and so stop all simulated clicks
        /// </summary>
        private void StopClickingButton_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
            try
            {
                if (ClickThread.IsAlive)
                {
                    ClickThread.Abort(); //Attempt to stop the thread
                    ClickThread.Join(); //Wait for thread to stop
                    //MessageBox.Show("Clicking successfully stopped", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    running = false;
                }
            }
            catch (ThreadAbortException ex)
            {
                // MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception exc)
            {
                // MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Remove all items from the list view holding queued positions
        /// </summary>
        private void RemoveAllMenuItem_Click(object sender, EventArgs e)
        {
            PositionsListView.Items.Clear();
            QueuePoints.Clear();
        }

        /// <summary>
        /// Remove only the selected item from the list view holding all queued positions
        /// </summary>
        private void RemoveSelectedMenuItem_Click(object sender, EventArgs e)
        {
            PositionsListView.SelectedItems[0].Remove();

            QueuePoints.Remove(EditingPoint);
            ReloadData();
        }

        #endregion

        #region Helper Methods

        /// <summary>
        /// Update current position textboxes to reflect the current position of the cursor
        /// </summary>
        private void UpdateCurrentPositionTextBoxes()
        {
            CurrentXCoordTextBox.Text = this.CurrentPosition.X.ToString();
            CurrentYCoordTextBox.Text = this.CurrentPosition.Y.ToString();
            toolStripStatusLabel1.Text = string.Format("X:{0}, Y:{1}", CurrentPosition.X, CurrentPosition.Y);

        }

        /// <summary>
        /// Check whether the input string consists of a valid positive integer
        /// </summary>
        /// <param name="input">The string to check</param>
        /// <returns>True if input is a valid positive integer, otherwise false</returns>
        private bool IsValidNumericalInput(string input)
        {
            int temp = 0;
            return (int.TryParse(input, out temp)) && temp >= 0;
        }

        /// <summary>
        /// Check if the coordinates are valid positive integers and also fit
        /// inside the bounds of the monitor
        /// </summary>
        /// <param name="xCoord">The X coordinate to check</param>
        /// <param name="yCoord">The Y coordinate to check</param>
        /// <returns>True if coordinates are valid, otherwise false</returns>
        private bool CurrentPositionIsValid(string xCoord, string yCoord)
        {
            int x, y, width, height = 0;

            if (int.TryParse(xCoord, out x) && int.TryParse(yCoord, out y))
            {
                width = System.Windows.Forms.SystemInformation.VirtualScreen.Width;
                height = System.Windows.Forms.SystemInformation.VirtualScreen.Height;

                if (x <= width && x >= 0 && y <= height && y >= 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        #endregion

        #region Thread Helper Class

        internal class ClickThreadHelper
        {
            #region Fields, DLL Imports and Constants

            public List<Point> Points { get; set; } //Hold the list of points in the queue
            public int Iterations { get; set; } //Hold the number of iterations/repeats
            public List<string> ClickType { get; set; } //Is each point right click or left click
            public List<int> Times { get; set; } //Holds sleep times for after each click

            //Import unmanaged functions from DLL library
            [DllImport("user32.dll")]
            public static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);

            [DllImport("user32.dll", SetLastError = true)]
            public static extern int SendInput(int nInputs, ref INPUT pInputs, int cbSize);



            /// <summary>
            /// Structure for SendInput function holding relevant mouse coordinates and information
            /// </summary>
            public struct INPUT
            {
                public uint type;
                public MOUSEINPUT mi;

            };

            /// <summary>
            /// Structure for SendInput function holding coordinates of the click and other information
            /// </summary>
            public struct MOUSEINPUT
            {
                public int dx;
                public int dy;
                public int mouseData;
                public int dwFlags;
                public int time;
                public IntPtr dwExtraInfo;
            };

            //Constants for use in SendInput and mouse_event
            public const int INPUT_MOUSE = 0x0000;
            public const int MOUSEEVENTF_LEFTDOWN = 0x0002;
            public const int MOUSEEVENTF_LEFTUP = 0x0004;
            public const int MOUSEEVENTF_RIGHTDOWN = 0x0008;
            public const int MOUSEEVENTF_RIGHTUP = 0x0010;
            public const int MOUSEEVENTF_MIDDLEDOWN = 0x0020;
            public const int MOUSEEVENTF_MIDDLEUP = 0x0040;

            #endregion

            #region Mouse_Event Methods

            /// <summary>
            /// Click the left mouse button at the current cursor position using
            /// the imported mouse_event function
            /// </summary>
            private void ClickLeftMouseButtonMouseEvent()
            {
                //Send a left click down followed by a left click up to simulate a 
                //full left click
                mouse_event(MOUSEEVENTF_LEFTDOWN, 0, 0, 0, 0);
                Thread.Sleep(20);
                mouse_event(MOUSEEVENTF_LEFTUP, 0, 0, 0, 0);
            }

            /// <summary>
            /// Click the right mouse button at the current cursor position using
            /// the imported mouse_event function
            /// </summary>
            private void ClickRightMouseButtonMouseEvent()
            {
                //Send a left click down followed by a right click up to simulate a 
                //full right click
                mouse_event(MOUSEEVENTF_RIGHTDOWN, 0, 0, 0, 0);
                Thread.Sleep(20);
                mouse_event(MOUSEEVENTF_RIGHTUP, 0, 0, 0, 0);
            }

            #endregion

            #region SendInput Methods

            /// <summary>
            /// Click the left mouse button at the current cursor position using
            /// the imported SendInput function
            /// </summary>
            public void ClickLeftMouseButtonSendInput()
            {
                //Initialise INPUT object with corresponding values for a left click
                INPUT input = new INPUT();
                input.type = INPUT_MOUSE;
                input.mi.dx = 0;
                input.mi.dy = 0;
                input.mi.dwFlags = MOUSEEVENTF_LEFTDOWN;
                input.mi.dwExtraInfo = IntPtr.Zero;
                input.mi.mouseData = 0;
                input.mi.time = 0;

                //Send a left click down followed by a left click up to simulate a 
                //full left click
                SendInput(1, ref input, Marshal.SizeOf(input));
                Thread.Sleep(20);
                input.mi.dwFlags = MOUSEEVENTF_LEFTUP;
                SendInput(1, ref input, Marshal.SizeOf(input));

                drawMouseIndicator(Cursor.Position.X, Cursor.Position.Y, Color.Green);

            }

            [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
            public static extern IntPtr GetDesktopWindow();
            [DllImport("user32.dll", EntryPoint = "GetDCEx", CharSet = CharSet.Auto, ExactSpelling = true)]
            private static extern IntPtr GetDCEx(IntPtr hWnd, IntPtr hrgnClip, int flags);

            [DllImport("user32.dll")]
            [return: MarshalAs(UnmanagedType.Bool)]
            private static extern bool InvalidateRect(IntPtr hWnd, IntPtr rect, bool bErase);

            [DllImport("user32.dll")]
            [return: MarshalAs(UnmanagedType.Bool)]
            private static extern bool UpdateWindow(IntPtr hWnd);

            public bool PaintWindow(IntPtr hWnd)
            {
                InvalidateRect(hWnd, IntPtr.Zero, true);
                if (UpdateWindow(hWnd))
                {
                    Application.DoEvents();
                    return true;
                }

                return false;
            }

            void drawMouseIndicator(int x, int y, Color color)
            {
                int size = 24;
                int haftSize = size / 2;

                IntPtr desk = GetDesktopWindow();
                PaintWindow(desk);

                IntPtr deskDC = GetDCEx(desk, IntPtr.Zero, 0x403);
                Graphics g = Graphics.FromHdc(deskDC);
                SolidBrush br = new SolidBrush(color);
                g.FillEllipse(br, x- size/2, y- size/2, size, size);
                //g.ReleaseHdc(deskDC);
                g.Dispose();
                               
            }


            /// <summary>
            /// Click the left mouse button at the current cursor position using
            /// the imported SendInput function
            /// </summary>
            public void ClickRightMouseButtonSendInput()
            {
                //Initialise INPUT object with corresponding values for a right click
                INPUT input = new INPUT();
                input.type = INPUT_MOUSE;
                input.mi.dx = 0;
                input.mi.dy = 0;
                input.mi.dwFlags = MOUSEEVENTF_RIGHTDOWN;
                input.mi.dwExtraInfo = IntPtr.Zero;
                input.mi.mouseData = 0;
                input.mi.time = 0;

                //Send a right click down followed by a right click up to simulate a 
                //full right click
                SendInput(1, ref input, Marshal.SizeOf(input));
                input.mi.dwFlags = MOUSEEVENTF_RIGHTUP;
                SendInput(1, ref input, Marshal.SizeOf(input));
                drawMouseIndicator(Cursor.Position.X, Cursor.Position.Y, Color.Green);
            }

            #endregion

            #region Methods

            /// <summary>
            /// Iterate through all queued clicks, for each deciding which mouse button
            /// to press and how long to sleep afterwards
            /// 
            /// This method is assigned to the ClickThread and is the only place where
            /// the mouse buttons are pressed
            /// </summary>
            public static int currentPosition;

            public void Run()
            {
                try
                {
                    int i = 1;

                    while (i <= Iterations)
                    {
                        //Iterate through all queued clicks
                        for (int j = 0; j <= Points.Count - 1; j++)
                        {

                            SetCursorPosition(Points[j]); //Set cursor position before clicking
                            if (ClickType[j].Equals("R"))
                            {
                                ClickRightMouseButtonSendInput();
                            }
                            else
                            {
                                ClickLeftMouseButtonSendInput();
                            }
                            //Cursor = Cursors.Default;

                            Thread.Sleep(Times[j]);
                        }
                        i++;
                    }
                }
                catch (Exception exc)
                {
                    MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            /// <summary>
            /// Set the current position of the cursor to the coordinates held in point
            /// </summary>
            /// <param name="point">Coordinates to set the cursor to</param>
            public void SetCursorPosition(Point point)
            {
                Cursor.Position = point;
            }

            #endregion
        }

        #endregion

        private void ShowSelectedPosition_Click(object sender, EventArgs e)
        {
            var selectedItem = PositionsListView.Items.Cast<ListViewItem>().Where(p => p.Selected).ToList();
            if (selectedItem.Count() == 1)
            {
                Cursor.Position = new Point() { X = EditingPoint.X, Y = EditingPoint.Y };
                drawMouseIndicator(Cursor.Position.X, Cursor.Position.Y, Color.Red);
            }
            else
            {
                for (int i = 0; i < selectedItem.Count(); i++)
                {
                    var p = QueuePoints[selectedItem[i].Index];
                    Cursor.Position = new Point() { X = p.X, Y = p.Y };
                    drawMouseIndicator(p.X,p.Y, Color.Red, 32, i+1);
                }
                

            }
        }


        private void PositionsListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            //PositionsListView.selected
            var selectedItem = PositionsListView.Items.Cast<ListViewItem>().FirstOrDefault(p => p.Selected);
            if (selectedItem != null)
            {
                int index = Convert.ToInt32(selectedItem.Text);

                EditingPoint = QueuePoints.FirstOrDefault(p => p.Index == index);

                QueuedXPositionTextBox.Text = EditingPoint.X.ToString();
                QueuedYPositionTextBox.Text = EditingPoint.Y.ToString();
                SleepTimeTextBox.Text = EditingPoint.Wait.ToString();

                var count = QueuePoints.Count(p => p.X == EditingPoint.X && p.Y == EditingPoint.Y);

                stsNote.Text = string.Format( "Found {0} items with the same coordinate", count);

                drawMouseIndicator(EditingPoint.X, EditingPoint.Y, Color.Red);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            SaveFileDialog dlg = new SaveFileDialog()
            {
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                RestoreDirectory = true,
                DefaultExt = "acf",
                Filter = "Auto Clicker files (*.acf)|*.acf|All files (*.*)|*.*"

            };


            if (dlg.ShowDialog() == DialogResult.OK)
            {
                var filename = dlg.FileName;

                QueuePoints.RepeatCounts = NumRepeatsTextBox.Text;
                System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(QueuePoints.GetType());
                using (var stream = dlg.OpenFile())
                {
                    x.Serialize(stream, QueuePoints);
                }

                formatXMLFile(dlg.FileName);
                //UpdateLastFolder(dlg.FileName);

            }
        }
        private void formatXMLFile(string file)
        {
            var lines = File.ReadAllLines(file);
            List<string> newlines = new List<string>();

            foreach (var item in lines)
            {
                //XElement element = XElement.Parse(item);
                if(Regex.IsMatch(item,"Y=\"(\\d*)\""))
                {
                    var Y = Convert.ToInt32(Regex.Match(item, "Y=\"(\\d*)\"").Groups[1].Value);

                    if(Y<= 50)
                    {
                        newlines.Add("\r\n");
                    }
                }
                newlines.Add(item);
            }

            File.WriteAllLines(file, newlines.ToArray());

        }
        private void UpdateLastFolder(string path)
        {
            return;
            Microsoft.Win32.RegistryKey key;
            key = Microsoft.Win32.Registry.CurrentUser.CreateSubKey("AutoClicker");
            key.SetValue("Path", path);
            key.Close();
        }

        private string ReadLastFolder(string path)
        {
            Microsoft.Win32.RegistryKey key;
            key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("AutoClicker");
            return key.GetValue("Path", path).ToString();
            
        }
        private string workingDir = "";

        private void btnLoad_Click(object sender, EventArgs e)
        {
            //if(MessageBox())

            OpenFileDialog dlg = new OpenFileDialog()
            {
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                RestoreDirectory = true,
                DefaultExt = "acf",
                Filter = "Auto Clicker files (*.acf)|*.acf|All files (*.*)|*.*"

            };

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                comboBox1.Items.Clear();
                LoadFromFile(dlg.FileName
                    );

                //UpdateLastFolder(dlg.FileName);
                workingDir = Path.GetDirectoryName(dlg.FileName);

                var files = Directory.GetFiles(workingDir, "*.acf");

                foreach (var item in files)
                {
                    var f = Path.GetFileName(item);
                    comboBox1.Items.Add(f);
                }

            }
            NumRepeatsTextBox.Text = QueuePoints.RepeatCounts;
            ReloadData();
        }

        private void LoadFromFile(string fileName)
        {
            System.Xml.Serialization.XmlSerializer x = new System.Xml.Serialization.XmlSerializer(QueuePoints.GetType());
            using (var stream = File.OpenRead(fileName))
            {
                QueuePoints = x.Deserialize(stream) as ClickPoints;
            }

            stsFileName.Text = System.IO.Path.GetFileName(fileName) + "[" + fileName + "]";
            ReloadData();
        }

        private void ReloadData()
        {
            PositionsListView.Items.Clear();
            var index = 1;
            foreach (var item in QueuePoints)
            {
                item.Index = index++;
                AddPoint(item);
            }
            EditingPoint = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            EditingPoint.X = int.Parse(QueuedXPositionTextBox.Text);
            EditingPoint.Y = int.Parse(QueuedYPositionTextBox.Text);
            EditingPoint.Wait = Convert.ToInt32(SleepTimeTextBox.Text);
            var index = QueuePoints.IndexOf(EditingPoint);
            ReloadData();

            PositionsListView.Items[index].Selected = true;
            PositionsListView.Items[index].EnsureVisible();
            stsNote.Text = "Update Item successful";

        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (CurrentPositionIsValid(QueuedXPositionTextBox.Text, QueuedYPositionTextBox.Text))
            {
                if (IsValidNumericalInput(SleepTimeTextBox.Text))
                {
                    //Add item holding coordinates, right/left click and sleep time to list view
                    //holding all queued clicks

                    string clickType = (RightClickCheckBox.Checked) == true ? "R" : "L";

                    int sleepTime = Convert.ToInt32(SleepTimeTextBox.Text);

                    ClickPoint point = new ClickPoint()
                    {
                        Index = QueuePoints.Count + 1,
                        X = int.Parse(QueuedXPositionTextBox.Text),
                        Y = int.Parse(QueuedYPositionTextBox.Text),
                        Wait = sleepTime,
                        Type = clickType,
                        Enable = true


                    };



                    if (EditingPoint != null)
                    {
                        int index = EditingPoint.Index;

                        QueuePoints.Insert(index, point);

                        for (int i = 0; i < QueuePoints.Count; i++)
                        {
                            QueuePoints[i].Index = i + 1;
                        }

                    }
                    else
                        QueuePoints.Add(point);

                    ReloadData();
                }
                else
                {
                    MessageBox.Show("Sleep time is not a valid positive integer", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Current Coordinates are not valid", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void mnuSetDelayToAll_Click(object sender, EventArgs e)
        {
            DelayForm form = new DelayForm();

            if (form.ShowDialog() == DialogResult.OK)
            {
                int newValue = Convert.ToInt32(form.GetValue());
                foreach (var item in QueuePoints)
                {
                    item.Wait = newValue;
                    ReloadData();
                }
            }
        }

        private void bntDelete_Click(object sender, EventArgs e)
        {
            if (PositionsListView.SelectedItems.Count > 0)
            {
                PositionsListView.SelectedItems[0].Remove();

                QueuePoints.Remove(EditingPoint);
                ReloadData();
            }
        }

        private void bntMoveUp_Click(object sender, EventArgs e)
        {
            if (EditingPoint != null)
            {
                var index = EditingPoint.Index - 2;

                if (index > 0)
                {
                    var prev = QueuePoints[index];
                    EditingPoint.Index--;
                    prev.Index++;

                    QueuePoints[index] = EditingPoint;
                    QueuePoints[index + 1] = prev;

                    ReloadData();

                }

            }
        }

        private void bntDown_Click(object sender, EventArgs e)
        {
            if (EditingPoint != null)
            {
                var index = EditingPoint.Index;

                if (index > 0)
                {
                    var prev = QueuePoints[index];
                    EditingPoint.Index++;
                    prev.Index--;

                    QueuePoints[index] = EditingPoint;
                    QueuePoints[index - 1] = prev;

                    ReloadData();

                }

            }
        }

        private void bntMoveTo_Click(object sender, EventArgs e)
        {
            if (EditingPoint != null)
            {
                var index = Convert.ToInt32(txtMoveTo.Text);

                if (index > 0)
                {

                    QueuePoints.Insert(index, EditingPoint.Clone());
                    QueuePoints.Remove(EditingPoint);
                    ReloadData();
                }

            }
        }

        int segmentFrom = 0;
        int segmentTo = 0;
        private void mnuExecuteItem_Click(object sender, EventArgs e)
        {
            var selectedItem = PositionsListView.Items.Cast<ListViewItem>().Where(p => p.Selected).ToList();

            if (selectedItem.Count() == 1)
            {

                ClickThreadHelper helper = new ClickThreadHelper();
                helper.SetCursorPosition(new Point() { X = EditingPoint.X, Y = EditingPoint.Y }); //Set cursor position before clicking
                if (EditingPoint.Type.Equals("R"))
                {
                    helper.ClickRightMouseButtonSendInput();
                }
                else
                {
                    helper.ClickLeftMouseButtonSendInput();
                }

            }
            else
            {
                int iterations = 1;
                List<Point> points = new List<Point>();
                List<string> clickType = new List<string>();
                List<int> times = new List<int>();

                
                for (int i = 0; i < selectedItem.Count(); i++)
                {
                    var item = QueuePoints[selectedItem[i].Index];



                    int x = item.X; //x coordinate
                    int y = item.Y; //y coordinate
                    clickType.Add(item.Type); //click type
                    times.Add(Convert.ToInt32(item.Wait)); //sleep time

                    points.Add(new Point(x, y));
                }
                try
                {

                    ClickThreadHelper helper = new ClickThreadHelper() { Points = points, ClickType = clickType, Iterations = iterations, Times = times };
                    //Create the thread passing the Run method
                    ClickThread = new Thread(new ThreadStart(helper.Run));
                    //Start the thread, thus starting the clicks
                    ClickThread.Start();
                    running = true;
                }
                catch (Exception exc)
                {
                    // MessageBox.Show(exc.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }

        
          
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClickPoint prev = null;
            ClickPoint prev1 = null;
            var indx = QueuePoints.IndexOf(EditingPoint) - 1;
            if (indx >= 0)
                prev1 = QueuePoints.ElementAt(indx);

            var X = EditingPoint.X;
            var Y = EditingPoint.Y;

            foreach (var item in QueuePoints.Where(p=>p.X == X && p.Y == Y))
            {
                if(item.X == X && item.Y == Y)// && ((prev!= null && prev1!= null && prev.X == prev1.X && prev.Y == prev1.Y) || prev == null || prev1 == null))
                {
                    
                    item.X = int.Parse(QueuedXPositionTextBox.Text);
                    item.Y = int.Parse(QueuedYPositionTextBox.Text);
                    item.Wait = Convert.ToInt32(SleepTimeTextBox.Text);
                }
                prev = item;
            }
            ReloadData();
            stsNote.Text = "Update all successful";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var file = comboBox1.SelectedItem as string;
            LoadFromFile(Path.Combine(workingDir,file));
        }

        private void bntInsertToAll_Click(object sender, EventArgs e)
        {
            if (CurrentPositionIsValid(QueuedXPositionTextBox.Text, QueuedYPositionTextBox.Text))
            {
                if (IsValidNumericalInput(SleepTimeTextBox.Text))
                {
                    //Add item holding coordinates, right/left click and sleep time to list view
                    //holding all queued clicks

                    string clickType = (RightClickCheckBox.Checked) == true ? "R" : "L";

                    int sleepTime = Convert.ToInt32(SleepTimeTextBox.Text);

                    ClickPoint point = new ClickPoint()
                    {
                        Index = QueuePoints.Count + 1,
                        X = int.Parse(QueuedXPositionTextBox.Text),
                        Y = int.Parse(QueuedYPositionTextBox.Text),
                        Wait = sleepTime,
                        Type = clickType,
                        Enable = true


                    };



                    if (EditingPoint != null)
                    {

                        var X = EditingPoint.X;
                        var Y = EditingPoint.Y;
                        var pointtoInserts = QueuePoints.Where(p => p.X == X && p.Y == Y).ToList();

                        foreach (var item in pointtoInserts)
                        {
                            int index = QueuePoints.IndexOf(item)+1;
                            QueuePoints.Insert(index, point);
                        }

                        for (int i = 0; i < QueuePoints.Count; i++)
                        {
                            QueuePoints[i].Index = i + 1;
                        }

                    }
                    

                    ReloadData();
                    stsNote.Text = "Bulk insert successful!";
                }
                else
                {
                    MessageBox.Show("Sleep time is not a valid positive integer", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Current Coordinates are not valid", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetDesktopWindow();
        [DllImport("user32.dll", EntryPoint = "GetDCEx", CharSet = CharSet.Auto, ExactSpelling = true)]
        private static extern IntPtr GetDCEx(IntPtr hWnd, IntPtr hrgnClip, int flags);

        private void button3_Click(object sender, EventArgs e)
        {

            drawMouseIndicator(50, 50, Color.Red);


        }
        void drawMouseIndicator(int x, int y, Color color, int size = 32, int index=-1)
        {
            
            IntPtr desk = GetDesktopWindow();
            IntPtr deskDC = GetDCEx(desk, IntPtr.Zero, 0x403);
            Graphics g = Graphics.FromHdc(deskDC);
            SolidBrush b = new SolidBrush(color);
            SolidBrush textB = new SolidBrush(Color.BurlyWood);
            g.FillEllipse(b, x-size/2, y-size/2, size, size);
            if(index>0)
            {
                if (index < 10)
                {
                    Font font = new Font("Segoe UI", 14.0f, FontStyle.Bold);

                    g.DrawString(index.ToString(), font, textB, new PointF() { X = x - size / 2 + 4, Y = y - size / 2 - 4 });
                }
                else
                {
                    Font font = new Font("Segoe UI", 10.0f, FontStyle.Regular);

                    g.DrawString(index.ToString(), font, textB, new PointF() { X = x - size / 2 +2  , Y = y - size / 2  });

                }

            }
            //g.ReleaseHdc(deskDC);
            g.Dispose();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            isRecord = !isRecord;
            updateLabelRecordButton();
        }

        private void updateLabelRecordButton()
        {
            if (isRecord)
            {
                stsNote.Text = "Recording mouse left click.";
                btnRecord.Text = "Stop Record";
            }
            else
            {
                btnRecord.Text = "Start Record";
                stsNote.Text = "Recording stop";
            }
        }
        public const int MAX_INIT_Y_COOR = 50;

        private void PositionsListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            var index = QueuePoints.IndexOf(EditingPoint);
            int lowIndex = index;
            int hightIndex = index;
            var point = EditingPoint;

            while (point.Y> MAX_INIT_Y_COOR )
            {
                lowIndex--;
                point = QueuePoints[lowIndex];
            }
            point = EditingPoint;
            while (point.Y > MAX_INIT_Y_COOR)
            {
                hightIndex++;
                point = QueuePoints[hightIndex];
            }

            for(int i = lowIndex +1; i< hightIndex; i++)
            {

                PositionsListView.Items[i].Selected = true;
            }
        }

        private void PositionsGroupBox_Enter(object sender, EventArgs e)
        {

        }
    }
}
