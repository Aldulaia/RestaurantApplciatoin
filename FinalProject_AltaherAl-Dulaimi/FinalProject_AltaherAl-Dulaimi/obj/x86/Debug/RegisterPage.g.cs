﻿#pragma checksum "C:\Users\6ahr\source\repos\FinalProject_AltaherAl-Dulaimi\FinalProject_AltaherAl-Dulaimi\RegisterPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "358111D9B6DB430C38AF8C5E343383DD24B75F11BE180511700BA474A0B282F0"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FinalProject_AltaherAl_Dulaimi
{
    partial class Page2 : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.685")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // RegisterPage.xaml line 40
                {
                    this.txtbFirstName = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 3: // RegisterPage.xaml line 43
                {
                    this.txtbLastName = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 4: // RegisterPage.xaml line 46
                {
                    this.txtbUsername = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 5: // RegisterPage.xaml line 49
                {
                    this.pPassword = (global::Windows.UI.Xaml.Controls.PasswordBox)(target);
                }
                break;
            case 6: // RegisterPage.xaml line 51
                {
                    this.btnRegister = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)this.btnRegister).Click += this.btnRegister_Click;
                }
                break;
            default:
                break;
            }
            this._contentLoaded = true;
        }

        /// <summary>
        /// GetBindingConnector(int connectionId, object target)
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.19041.685")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

