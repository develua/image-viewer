﻿#pragma checksum "..\..\MainWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "5CE14A6E8933444D9312AE5282AE84E6"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace exzam_work {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 113 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Primitives.Popup PopUpSettings;
        
        #line default
        #line hidden
        
        
        #line 127 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox SlideShowTime;
        
        #line default
        #line hidden
        
        
        #line 137 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TreeView FolderTreeView;
        
        #line default
        #line hidden
        
        
        #line 141 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.WrapPanel FileWrapPanel;
        
        #line default
        #line hidden
        
        
        #line 145 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid BlockFull;
        
        #line default
        #line hidden
        
        
        #line 156 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image ImageFull;
        
        #line default
        #line hidden
        
        
        #line 159 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image IconFull;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/exzam_work;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MainWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 99 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Border)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.IconDeep_MouseDown);
            
            #line default
            #line hidden
            
            #line 99 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Border)(target)).MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.IconDeep_MouseUp);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 103 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Border)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.IconRandom_MouseDown);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 106 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Border)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.IconSettings_MouseDown);
            
            #line default
            #line hidden
            
            #line 106 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Border)(target)).MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.IconSettings_MouseUp);
            
            #line default
            #line hidden
            return;
            case 4:
            
            #line 109 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Border)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.IconSlideShow_MouseDown);
            
            #line default
            #line hidden
            
            #line 109 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Border)(target)).MouseUp += new System.Windows.Input.MouseButtonEventHandler(this.IconSlideShow_MouseUp);
            
            #line default
            #line hidden
            return;
            case 5:
            this.PopUpSettings = ((System.Windows.Controls.Primitives.Popup)(target));
            
            #line 113 "..\..\MainWindow.xaml"
            this.PopUpSettings.MouseLeave += new System.Windows.Input.MouseEventHandler(this.PopUpSettings_MouseLeave);
            
            #line default
            #line hidden
            return;
            case 6:
            
            #line 114 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Border)(target)).AddHandler(System.Windows.Controls.Primitives.ToggleButton.CheckedEvent, new System.Windows.RoutedEventHandler(this.RadioButtonAnamation_Checked));
            
            #line default
            #line hidden
            return;
            case 7:
            this.SlideShowTime = ((System.Windows.Controls.TextBox)(target));
            
            #line 127 "..\..\MainWindow.xaml"
            this.SlideShowTime.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.SlideShowTime_TextChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            this.FolderTreeView = ((System.Windows.Controls.TreeView)(target));
            
            #line 137 "..\..\MainWindow.xaml"
            this.FolderTreeView.AddHandler(System.Windows.Controls.TreeViewItem.ExpandedEvent, new System.Windows.RoutedEventHandler(this.FolderTreeView_Expanded));
            
            #line default
            #line hidden
            return;
            case 9:
            this.FileWrapPanel = ((System.Windows.Controls.WrapPanel)(target));
            return;
            case 10:
            this.BlockFull = ((System.Windows.Controls.Grid)(target));
            return;
            case 11:
            this.ImageFull = ((System.Windows.Controls.Image)(target));
            return;
            case 12:
            this.IconFull = ((System.Windows.Controls.Image)(target));
            
            #line 159 "..\..\MainWindow.xaml"
            this.IconFull.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.IconFull_MouseDown);
            
            #line default
            #line hidden
            return;
            case 13:
            
            #line 163 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Image)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.IconClose_MouseDown);
            
            #line default
            #line hidden
            return;
            case 14:
            
            #line 167 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Image)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.IconLeftArrow_MouseDown);
            
            #line default
            #line hidden
            return;
            case 15:
            
            #line 171 "..\..\MainWindow.xaml"
            ((System.Windows.Controls.Image)(target)).MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.IconRightArrow_MouseDown);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
