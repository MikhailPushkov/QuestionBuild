﻿#pragma checksum "..\..\..\AddWindows\AddAuthor.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "71C636CCF7E3A42BFAE980AE9F00EC40"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.34209
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


namespace QuestBuild.AddWindows {
    
    
    /// <summary>
    /// AddAuthor
    /// </summary>
    public partial class AddAuthor : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\AddWindows\AddAuthor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBox_Surname;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\AddWindows\AddAuthor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBox_Name;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\AddWindows\AddAuthor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox TextBox_Otchestvo;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\AddWindows\AddAuthor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Button_SaveAuthor;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\AddWindows\AddAuthor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Button_AddKafedra;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\AddWindows\AddAuthor.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox Cb_Kafedra;
        
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
            System.Uri resourceLocater = new System.Uri("/QuestBuild;component/addwindows/addauthor.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\AddWindows\AddAuthor.xaml"
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
            this.TextBox_Surname = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.TextBox_Name = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.TextBox_Otchestvo = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.Button_SaveAuthor = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\..\AddWindows\AddAuthor.xaml"
            this.Button_SaveAuthor.Click += new System.Windows.RoutedEventHandler(this.Button_SaveAuthor_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Button_AddKafedra = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\..\AddWindows\AddAuthor.xaml"
            this.Button_AddKafedra.Click += new System.Windows.RoutedEventHandler(this.Button_AddKafedra_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Cb_Kafedra = ((System.Windows.Controls.ComboBox)(target));
            
            #line 15 "..\..\..\AddWindows\AddAuthor.xaml"
            this.Cb_Kafedra.DropDownClosed += new System.EventHandler(this.Cb_Kafedra_DropDownClosed);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

