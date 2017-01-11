using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Interop;
using System.Threading;
using System.Windows.Media.Animation;

namespace exzam_work
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        TreeViewBlock treeViewBlock;
        WrapPanelView wrapPanelView;
        SlideShow slideShow;
        bool isRandom = false;
        int animation = 0, slideShowTime = 5;

        public MainWindow()
        {
            InitializeComponent();

            treeViewBlock = new TreeViewBlock(FolderTreeView, Resources);
            wrapPanelView = new WrapPanelView(FileWrapPanel, Resources, BlockFull);
            slideShow = new SlideShow(BlockFull);
            treeViewBlock.LoadDrives();
        }

        private void FolderTreeView_Expanded(object sender, RoutedEventArgs e)
        {
            wrapPanelView.LoadFiles(TreeViewBlock.thisPath, false);
        }

        private void IconClose_MouseDown(object sender, MouseButtonEventArgs e)
        {
            BlockFull.Visibility = Visibility.Hidden;
            ImageFull.BeginAnimation(Image.OpacityProperty, null);
            ImageFull.BeginAnimation(Image.WidthProperty, null);
            ImageFull.Source = null;

            if (WindowStyle == WindowStyle.None)
            {
                WindowStyle = WindowStyle.SingleBorderWindow;
                IconFull.Source = new BitmapImage(new Uri("Resources/full.png", UriKind.Relative));
            }
        }

        private void IconFull_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (WindowStyle != WindowStyle.None)
            {
                WindowStyle = WindowStyle.None;
                WindowState = WindowState.Normal;
                WindowState = WindowState.Maximized;
                IconFull.Source = new BitmapImage(new Uri("Resources/full_off.png", UriKind.Relative));
            }
            else
            {
                WindowStyle = WindowStyle.SingleBorderWindow;
                WindowState = WindowState.Normal;
                IconFull.Source = new BitmapImage(new Uri("Resources/full.png", UriKind.Relative));
            }
        }

        private void IconDeep_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Border border = (Border)sender;
            border.Background = new SolidColorBrush(Color.FromRgb(245, 245, 245));
            border.BorderThickness = new Thickness(2);
            border.BorderBrush = Brushes.Gray;
        }

        private void IconDeep_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (TreeViewBlock.thisPath != null && TreeViewBlock.thisPath.Length > 3)
            {
                if (MessageBox.Show("Поиск файлов, будет учитывать подпапки.\nПоэтому, поиск может занять некое время.", "Информация", MessageBoxButton.OKCancel, MessageBoxImage.Information) == MessageBoxResult.OK)
                    wrapPanelView.LoadFiles(TreeViewBlock.thisPath, true);
            }
            else
                Thread.Sleep(100);

            Border border = (Border)sender;
            border.Background = Brushes.White;
            border.BorderThickness = new Thickness(1);
            border.BorderBrush = Brushes.LightGray;
        }

        private void IconRandom_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Border border = (Border)sender;

            if (!isRandom)
            {
                border.Background = new SolidColorBrush(Color.FromRgb(245, 245, 245));
                border.BorderThickness = new Thickness(2);
                border.BorderBrush = Brushes.Gray;
            }
            else
            {
                border.Background = Brushes.White;
                border.BorderThickness = new Thickness(1);
                border.BorderBrush = Brushes.LightGray;
            }

            isRandom = !isRandom;
        }

        private void IconSettings_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Border border = (Border)sender;
            border.Background = new SolidColorBrush(Color.FromRgb(245, 245, 245));
            border.BorderThickness = new Thickness(2);
            border.BorderBrush = Brushes.Gray;
        }

        private void IconSettings_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Thread.Sleep(100);
            Border border = (Border)sender;
            border.Background = Brushes.White;
            border.BorderThickness = new Thickness(1);
            border.BorderBrush = Brushes.LightGray;

            PopUpSettings.IsOpen = true;
        }

        private void IconSlideShow_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Border border = (Border)sender;
            border.Background = new SolidColorBrush(Color.FromRgb(245, 245, 245));
            border.BorderThickness = new Thickness(2);
            border.BorderBrush = Brushes.Gray;
        }

        private void IconSlideShow_MouseUp(object sender, MouseButtonEventArgs e)
        {
            Thread.Sleep(100);
            Border border = (Border)sender;
            border.Background = Brushes.White;
            border.BorderThickness = new Thickness(1);
            border.BorderBrush = Brushes.LightGray;
            PopUpSettings.IsOpen = false;
            slideShow.StartSlideShow(isRandom, slideShowTime, animation);
        }

        private void IconLeftArrow_MouseDown(object sender, MouseButtonEventArgs e)
        {
            slideShow.PrevImage(isRandom, true);
        }

        private void IconRightArrow_MouseDown(object sender, MouseButtonEventArgs e)
        {
            slideShow.NextImage(isRandom, true);
        }

        private void RadioButtonAnamation_Checked(object sender, RoutedEventArgs e)
        {
            if (IsLoaded)
                animation = (animation == 0) ? 1 : 0;
        }

        private void SlideShowTime_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                slideShowTime = Convert.ToInt32(SlideShowTime.Text);
                SlideShowTime.Text = slideShowTime.ToString();
            }
            catch
            {
                if (SlideShowTime.Text.Length > 0)
                    SlideShowTime.Text = SlideShowTime.Text.Substring(0, SlideShowTime.Text.Length - 1);
            }
        }

        private void PopUpSettings_MouseLeave(object sender, MouseEventArgs e)
        {
            PopUpSettings.IsOpen = false;
        }

    }

    class TreeViewBlock
    {
        TreeView treeView;
        ResourceDictionary Resources;
        public static string thisPath { get; private set; }

        public TreeViewBlock(TreeView tv, ResourceDictionary r)
        {
            treeView = tv;
            Resources = r;
        }

        public void LoadDrives()
        {
            string typeDrive;

            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                switch (drive.DriveType)
                {
                    case System.IO.DriveType.CDRom:
                        typeDrive = "DVD/CD привод ";
                        break;
                    case System.IO.DriveType.Fixed:
                        typeDrive = "Локальный диск "; // Local Drive
                        break;
                    case System.IO.DriveType.Network:
                        typeDrive = "Сетевой диск "; // Mapped Drive
                        break;
                    case System.IO.DriveType.NoRootDirectory:
                        typeDrive = "NoRootDirectory ";
                        break;
                    case System.IO.DriveType.Ram:
                        typeDrive = "Ram ";
                        break;
                    case System.IO.DriveType.Removable:
                        typeDrive = "Съемный диск "; // Usually a USB Drive
                        break;
                    case System.IO.DriveType.Unknown:
                        typeDrive = "Неизвестный тип диска ";
                        break;
                    default:
                        typeDrive = "";
                        break;
                }

                NewDirectoryInTreeView(null, typeDrive +  "(" + drive.ToString().Remove(2) + ")", drive, drive.ToString());
            }
        }

        private void NewDirectoryInTreeView(TreeViewItem treeViewItem, string headerTexr, object tag, string path)
        {
            StackPanel stackPanel = new StackPanel();
            stackPanel.Style = (Style)Resources["StackPanelFTV"];
            Image image = new Image();
            image.Style = (Style)Resources["ImageFTV"];
            image.Source = IconObject.ReceivingBitmapSource(path);
            stackPanel.Children.Add(image);
            TextBlock textBlock = new TextBlock();
            textBlock.Style = (Style)Resources["TextBlockFTV"];
            textBlock.Text = headerTexr;
            stackPanel.Children.Add(textBlock);
            TreeViewItem item = new TreeViewItem();
            item.Style = (Style)Resources["TreeViewItemFTV"];
            item.Tag = tag;
            item.Header = stackPanel;
            item.Expanded += SelectedItems_Expanded;
            item.Items.Add("*");

            if (treeViewItem != null)
                treeViewItem.Items.Add(item);
            else
                treeView.Items.Add(item);
        }

        private void SelectedItems_Expanded(object sender, RoutedEventArgs e)
        {
            TreeViewItem item = (TreeViewItem)e.OriginalSource;
            item.Items.Clear();

            DirectoryInfo dir;

            if (item.Tag is DriveInfo)
            {
                DriveInfo drive = (DriveInfo)item.Tag;
                dir = drive.RootDirectory;
            }
            else
                dir = (DirectoryInfo)item.Tag;

            try
            {
                thisPath = dir.FullName;
                foreach (DirectoryInfo subDir in dir.GetDirectories())
                    NewDirectoryInTreeView(item, subDir.ToString(), subDir, subDir.FullName);
            }
            catch
            { }
        }
    }

    class WrapPanelView
    {
        WrapPanel wrapPanel;
        ResourceDictionary Resources;
        Grid gridImageFull;

        public WrapPanelView(WrapPanel wp, ResourceDictionary r, Grid gif)
        {
            wrapPanel = wp;
            Resources = r;
            gridImageFull = gif;
        }

        public void LoadFiles(string path, bool isDeep)
        {
            SlideShow.uriImageList.Clear();

            try
            {
                wrapPanel.Children.Clear();

                SearchOption searchOption = (isDeep) ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly;
                string[] dirs = Directory.GetFiles(TreeViewBlock.thisPath, "*.*", searchOption);
                string allTypeFile = ".BMP.GIF.ICO.JPEG.JPG.PNG";

                foreach (string dir in dirs)
                {
                    if (allTypeFile.IndexOf(System.IO.Path.GetExtension(dir), 0, StringComparison.OrdinalIgnoreCase) == -1)
                        continue;

                    Border border = new Border();
                    border.Style = (Style)Resources["BorderFWP"];
                    border.MouseDown += border_MouseDown;
                    StackPanel stackPanel = new StackPanel();
                    stackPanel.Style = (Style)Resources["StackPanelFWP"];
                    border.Child = stackPanel;
                    Image image = new Image();
                    image.Style = (Style)Resources["ImageFWP"];
                    image.Source = new BitmapImage(new Uri(dir, UriKind.Absolute));
                    stackPanel.Children.Add(image);
                    TextBlock textBlock = new TextBlock();
                    textBlock.Style = (Style)Resources["TextBlockFWP"];
                    textBlock.Text = System.IO.Path.GetFileName(dir);
                    stackPanel.Children.Add(textBlock);
                    wrapPanel.Children.Add(border);
                    SlideShow.uriImageList.Add(dir);
                }
            }
            catch
            { }
        }

        private void border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if(e.ChangedButton == MouseButton.Left)
                if(e.ClickCount == 2)
                {
                    Border border = (Border)sender;
                    StackPanel stackPanel = (StackPanel)border.Child;
                    Image image = (Image)stackPanel.Children[0];
                    Image imageFull = (Image)gridImageFull.Children[0];
                    gridImageFull.Visibility = Visibility.Visible;
                    imageFull.Source = image.Source;
                }
        }
    }

    class SlideShow
    {
        Grid gridFull;
        Image image;
        public static List<string> uriImageList { get; private set; }
        int thisIndex;
        Random rand;
        bool isRandom;
        int time, animation;

        public SlideShow(Grid IF)
        {
            gridFull = IF;
            uriImageList = new List<string>();
            image = (Image)gridFull.Children[0];
            rand = new Random();
        }

        private void SearchIndex()
        {
            if (image.Source != null)
                for (int i = 0; i < uriImageList.Count; i++)
                    if (image.Source.ToString() == "file:///" + uriImageList[i].Replace(@"\", "/"))
                        thisIndex = i;
        }

        private void AnimationAppointment(bool twoAnimation = false)
        {
            if (animation == 0)
            {
                if (twoAnimation)
                {
                    DoubleAnimationUsingKeyFrames a = new DoubleAnimationUsingKeyFrames();
                    a.Completed += Animation_Completed;

                    EasingDoubleKeyFrame edkf1 = new EasingDoubleKeyFrame();
                    edkf1.KeyTime = new TimeSpan(0, 0, 0);
                    edkf1.Value = 0;
                    a.KeyFrames.Add(edkf1);

                    EasingDoubleKeyFrame edkf2 = new EasingDoubleKeyFrame();
                    edkf2.KeyTime = new TimeSpan(0, 0, 2);
                    edkf2.Value = 1;
                    a.KeyFrames.Add(edkf2);

                    EasingDoubleKeyFrame edkf3 = new EasingDoubleKeyFrame();
                    edkf3.KeyTime = new TimeSpan(0, 0, time + 2);
                    edkf3.Value = 1;
                    a.KeyFrames.Add(edkf3);

                    EasingDoubleKeyFrame edkf4 = new EasingDoubleKeyFrame();
                    edkf4.KeyTime = new TimeSpan(0, 0, time + 4);
                    edkf4.Value = 0;
                    a.KeyFrames.Add(edkf4);

                    image.BeginAnimation(Image.OpacityProperty, a);
                }
                else
                {
                    DoubleAnimationUsingKeyFrames a = new DoubleAnimationUsingKeyFrames();
                    a.Completed += Animation_Completed;

                    EasingDoubleKeyFrame edkf1 = new EasingDoubleKeyFrame();
                    edkf1.KeyTime = new TimeSpan(0, 0, time);
                    edkf1.Value = 1;
                    a.KeyFrames.Add(edkf1);

                    EasingDoubleKeyFrame edkf2 = new EasingDoubleKeyFrame();
                    edkf2.KeyTime = new TimeSpan(0, 0, time + 2);
                    edkf2.Value = 0;
                    a.KeyFrames.Add(edkf2);

                    image.BeginAnimation(Image.OpacityProperty, a);
                }
            }
            else if (animation == 1)
            {
                if (twoAnimation)
                {
                    DoubleAnimationUsingKeyFrames a = new DoubleAnimationUsingKeyFrames();
                    a.Completed += Animation_Completed;

                    EasingDoubleKeyFrame edkf1 = new EasingDoubleKeyFrame();
                    edkf1.KeyTime = new TimeSpan(0, 0, 0);
                    edkf1.Value = 0;
                    a.KeyFrames.Add(edkf1);

                    EasingDoubleKeyFrame edkf2 = new EasingDoubleKeyFrame();
                    edkf2.KeyTime = new TimeSpan(0, 0, 3);
                    edkf2.Value = gridFull.ActualWidth;
                    a.KeyFrames.Add(edkf2);

                    EasingDoubleKeyFrame edkf3 = new EasingDoubleKeyFrame();
                    edkf3.KeyTime = new TimeSpan(0, 0, time + 2);
                    edkf3.Value = gridFull.ActualWidth;
                    a.KeyFrames.Add(edkf3);

                    EasingDoubleKeyFrame edkf4 = new EasingDoubleKeyFrame();
                    edkf4.KeyTime = new TimeSpan(0, 0, time + 4);
                    edkf4.Value = 0;
                    a.KeyFrames.Add(edkf4);

                    image.BeginAnimation(Image.WidthProperty, a);
                }
                else
                {
                    DoubleAnimationUsingKeyFrames a = new DoubleAnimationUsingKeyFrames();
                    a.Completed += Animation_Completed;

                    EasingDoubleKeyFrame edkf1 = new EasingDoubleKeyFrame();
                    edkf1.KeyTime = new TimeSpan(0, 0, time);
                    edkf1.Value = gridFull.ActualWidth;
                    a.KeyFrames.Add(edkf1);

                    EasingDoubleKeyFrame edkf2 = new EasingDoubleKeyFrame();
                    edkf2.KeyTime = new TimeSpan(0, 0, time + 2);
                    edkf2.Value = 0;
                    a.KeyFrames.Add(edkf2);

                    image.BeginAnimation(Image.WidthProperty, a);
                }
            }
        }

        private void Animation_Completed(object sender, EventArgs e)
        {
            NextImage(isRandom);
        }

        public void StartSlideShow(bool isRand, int time, int animation)
        {
            if (uriImageList.Count > 0)
            {
                gridFull.Visibility = Visibility.Visible;
                this.time = time;
                this.animation = animation;
                isRandom = isRand;

                if (isRandom)
                {
                    thisIndex = rand.Next(0, uriImageList.Count);
                    image.Source = new BitmapImage(new Uri(uriImageList[thisIndex]));
                }
                else
                {
                    if (image.Source == null)
                    {
                        image.Source = new BitmapImage(new Uri(uriImageList[0]));
                        thisIndex = 0;
                    }
                    else
                        SearchIndex();
                }

                AnimationAppointment();
            }
        }

        public void NextImage(bool isRand, bool isClickUser = false)
        {
            if (isRand)
                thisIndex = rand.Next(0, uriImageList.Count);
            else
            {
                SearchIndex();
                if (uriImageList.Count > thisIndex + 1)
                    thisIndex++;
            }

            image.Source = new BitmapImage(new Uri(uriImageList[thisIndex]));

            if (!isClickUser)
                AnimationAppointment(true);
        }

        public void PrevImage(bool isRand, bool isClickUser = false)
        {
            if (isRand)
                thisIndex = rand.Next(0, uriImageList.Count);
            else
            {
                SearchIndex();

                if (thisIndex > 0)
                    thisIndex--;
            }

            image.Source = new BitmapImage(new Uri(uriImageList[thisIndex]));

            if (!isClickUser)
                AnimationAppointment(true);
        }

    }

    class IconObject
    {
        [StructLayout(LayoutKind.Sequential)]
        struct SHFILEINFO
        {
            public IntPtr hIcon;
            public IntPtr iIcon;
            public uint dwAttributes;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string szDisplayName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
            public string szTypeName;
        };

        [DllImport("User32.dll")]
        static extern int DestroyIcon(IntPtr hIcon);

        class Win32
        {
            public const uint SHGFI_ICON = 0x100;
            public const uint SHGFI_LARGEICON = 0x0;
            public const uint SHGFI_SMALLICON = 0x1;

            [DllImport("shell32.dll")]
            public static extern IntPtr SHGetFileInfo(string pszPath,
            uint dwFileAttributes,
            ref SHFILEINFO psfi,
            uint cbSizeFileInfo,
            uint uFlags);
        }

        static System.Drawing.Icon GetIcon(string path, bool bolshaya)
        {
            IntPtr hImgSmall;
            IntPtr hImgLarge;
            SHFILEINFO shinfo = new SHFILEINFO();

            if (!bolshaya)
            {
                hImgSmall = Win32.SHGetFileInfo(path, 0, ref shinfo,
                (uint)Marshal.SizeOf(shinfo),
                Win32.SHGFI_ICON |
                Win32.SHGFI_SMALLICON);
            }

            else
            {
                hImgLarge = Win32.SHGetFileInfo(path, 0,
                ref shinfo, (uint)Marshal.SizeOf(shinfo),
                Win32.SHGFI_ICON | Win32.SHGFI_LARGEICON);
            }

            System.Drawing.Icon myIcon = (System.Drawing.Icon)System.Drawing.Icon.FromHandle(shinfo.hIcon).Clone();
            DestroyIcon(shinfo.hIcon);
            return myIcon;
        }

        public static BitmapSource ReceivingBitmapSource(string path)
        {
            return Imaging.CreateBitmapSourceFromHBitmap(GetIcon(path, true).ToBitmap().GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        }
    }
}


