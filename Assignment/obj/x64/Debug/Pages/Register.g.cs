﻿#pragma checksum "D:\SEM3\Assignment\Assignment\Pages\Register.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "8D52EC10F4B9F45E14750C8148AAC08E"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Assignment.Pages
{
    partial class Register : 
        global::Windows.UI.Xaml.Controls.Page, 
        global::Windows.UI.Xaml.Markup.IComponentConnector,
        global::Windows.UI.Xaml.Markup.IComponentConnector2
    {
        /// <summary>
        /// Connect()
        /// </summary>
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.18362.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void Connect(int connectionId, object target)
        {
            switch(connectionId)
            {
            case 2: // Pages\Register.xaml line 14
                {
                    this.Firstname = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 3: // Pages\Register.xaml line 15
                {
                    this.FirstNameMessage = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 4: // Pages\Register.xaml line 16
                {
                    this.Lastname = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 5: // Pages\Register.xaml line 17
                {
                    this.LastNameMessage = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 6: // Pages\Register.xaml line 18
                {
                    global::Windows.UI.Xaml.Controls.AppBarButton element6 = (global::Windows.UI.Xaml.Controls.AppBarButton)(target);
                    ((global::Windows.UI.Xaml.Controls.AppBarButton)element6).Click += this.ButtonBase_Photo;
                }
                break;
            case 7: // Pages\Register.xaml line 19
                {
                    this.Avatar = (global::Windows.UI.Xaml.Controls.Image)(target);
                }
                break;
            case 8: // Pages\Register.xaml line 20
                {
                    this.AvatarUrl = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 9: // Pages\Register.xaml line 21
                {
                    this.Phone = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 10: // Pages\Register.xaml line 22
                {
                    this.PhoneMessage = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 11: // Pages\Register.xaml line 23
                {
                    this.Address = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 12: // Pages\Register.xaml line 24
                {
                    this.AddressMessage = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 13: // Pages\Register.xaml line 25
                {
                    this.Introduction = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 14: // Pages\Register.xaml line 26
                {
                    this.GenderLabel = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 15: // Pages\Register.xaml line 31
                {
                    this.Birthday = (global::Windows.UI.Xaml.Controls.DatePicker)(target);
                }
                break;
            case 16: // Pages\Register.xaml line 32
                {
                    this.Email = (global::Windows.UI.Xaml.Controls.TextBox)(target);
                }
                break;
            case 17: // Pages\Register.xaml line 33
                {
                    this.EmailMessage = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 18: // Pages\Register.xaml line 34
                {
                    this.Password = (global::Windows.UI.Xaml.Controls.PasswordBox)(target);
                }
                break;
            case 19: // Pages\Register.xaml line 35
                {
                    this.PasswordMessage = (global::Windows.UI.Xaml.Controls.TextBlock)(target);
                }
                break;
            case 20: // Pages\Register.xaml line 36
                {
                    global::Windows.UI.Xaml.Controls.Button element20 = (global::Windows.UI.Xaml.Controls.Button)(target);
                    ((global::Windows.UI.Xaml.Controls.Button)element20).Click += this.ButtonBase_OnClick;
                }
                break;
            case 21: // Pages\Register.xaml line 28
                {
                    global::Windows.UI.Xaml.Controls.RadioButton element21 = (global::Windows.UI.Xaml.Controls.RadioButton)(target);
                    ((global::Windows.UI.Xaml.Controls.RadioButton)element21).Checked += this.Gender_check;
                }
                break;
            case 22: // Pages\Register.xaml line 29
                {
                    global::Windows.UI.Xaml.Controls.RadioButton element22 = (global::Windows.UI.Xaml.Controls.RadioButton)(target);
                    ((global::Windows.UI.Xaml.Controls.RadioButton)element22).Checked += this.Gender_check;
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
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.Windows.UI.Xaml.Build.Tasks"," 10.0.18362.1")]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public global::Windows.UI.Xaml.Markup.IComponentConnector GetBindingConnector(int connectionId, object target)
        {
            global::Windows.UI.Xaml.Markup.IComponentConnector returnValue = null;
            return returnValue;
        }
    }
}

