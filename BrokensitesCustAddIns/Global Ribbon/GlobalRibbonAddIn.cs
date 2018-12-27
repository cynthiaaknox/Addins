////////////////////////////////////////////////////////////////////////////////
// Author: Chris Hunter
//
// File: GlobalRibbonAddIn.cs
//
// Comments: Simple add-in that creates a global ribbon add-in.
//
// Notes: 
//
// Pre-Conditions: 
//          1. You must have enabled add-ins for the appropriate profile
//          2. You must have uploaded the compiled .dll to the RightNow server
//
////////////////////////////////////////////////////////////////////////////////

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RightNow.AddIns.AddInViews;
using System.AddIn;
using System.Windows.Forms;

namespace BrokensitesCustAddIns.Global_Ribbon
{
    [AddIn("Global Ribbon Contact Tab Add-In", Version="1.0.0.0")]
    public class GlobalRibbonContactTabAddIn : IGlobalRibbonTab
    {

        public GlobalRibbonContactTabAddIn()
        {

        }

        private IGlobalContext _globalContext;

        #region IGlobalRibbonTab Members

        public string KeyTips
        {
            get 
            {
                return "G";
            }
        }

        public int Order
        {
            get 
            {
                return 0;
            }
        }

        public string Text
        {
            get 
            {
                return "Quick to Contact";
            }
        }

        private bool visible = true;

        public bool Visible
        {
            get 
            {
                return visible;
            }
            set
            {
                if (this.visible != value)
                {
                    this.visible = value;

                    if (this.VisibleChanged != null)
                    {
                        this.VisibleChanged(this, EventArgs.Empty);
                    }
                }
            }
        }

        public event EventHandler VisibleChanged;

        #endregion

        #region IAddInBase Members

        public bool Initialize(IGlobalContext context)
        {
            _globalContext = context;
            
            //Initialize must return true for the add-in to execute
            return true;
        }

        #endregion
    }

    [AddIn("Global Ribbon Task Tab Add-In", Version = "1.0.0.0")]
    public class GlobalRibbonTaskTabAddIn : IGlobalRibbonTab
    {

        public GlobalRibbonTaskTabAddIn()
        {

        }

        private IGlobalContext _globalContext;

        #region IGlobalRibbonTab Members

        public string KeyTips
        {
            get
            {
                return "T";
            }
        }

        public int Order
        {
            get
            {
                return 0;
            }
        }

        public string Text
        {
            get
            {
                return "Quick to Task";
            }
        }

        private bool visible = true;

        public bool Visible
        {
            get
            {
                return visible;
            }
            set
            {
                if (this.visible != value)
                {
                    this.visible = value;

                    if (this.VisibleChanged != null)
                    {
                        this.VisibleChanged(this, EventArgs.Empty);
                    }
                }
            }
        }

        public event EventHandler VisibleChanged;

        #endregion

        #region IAddInBase Members

        public bool Initialize(IGlobalContext context)
        {
            _globalContext = context;

            //Initialize must return true for the add-in to execute
            return true;
        }

        #endregion
    }

    [AddIn("Contact Global Ribbon Add-In Group", Version="1.0.0.0")]
    public class ContactGlobalRibbonGroupAddIn : IGlobalRibbonGroup
    {
        private IGlobalContext _globalContext;

        #region IGlobalRibbonGroup Members

        public int Order
        {
            get 
            {
                return 0;
            }
        }

        public string TabName
        {
            get 
            {
                return typeof(GlobalRibbonContactTabAddIn).FullName;
            }
        }

        public string Text
        {
            get 
            {
                return "Contacts";
            }
        }

        private bool visible = true;

        public bool Visible
        {
            get
            {
                return visible;
            }
            set
            {
                if (this.visible != value)
                {
                    this.visible = value;

                    if (this.VisibleChanged != null)
                    {
                        this.VisibleChanged(this, EventArgs.Empty);
                    }
                }
            }
        }

        public event EventHandler VisibleChanged;

        #endregion

        #region IAddInBase Members

        public bool Initialize(IGlobalContext context)
        {
            _globalContext = context;

            //Initialize must return true for the add-in to be executed
            return true;
        }

        #endregion
    }

    [AddIn("Task Global Ribbon Task Add-In Group", Version = "1.0.0.0")]
    public class TaskGlobalRibbonGroupAddIn : IGlobalRibbonGroup
    {
        private IGlobalContext _globalContext;

        #region IGlobalRibbonGroup Members

        public int Order
        {
            get
            {
                return 1;
            }
        }

        public string TabName
        {
            get
            {
                return typeof(GlobalRibbonTaskTabAddIn).FullName;
            }
        }

        public string Text
        {
            get
            {
                return "Tasks";
            }
        }

        private bool visible = true;

        public bool Visible
        {
            get
            {
                return visible;
            }
            set
            {
                if (this.visible != value)
                {
                    this.visible = value;

                    if (this.VisibleChanged != null)
                    {
                        this.VisibleChanged(this, EventArgs.Empty);
                    }
                }
            }
        }

        public event EventHandler VisibleChanged;

        #endregion

        #region IAddInBase Members

        public bool Initialize(IGlobalContext context)
        {
            _globalContext = context;

            //Initialize must return true for the add-in to be executed
            return true;
        }

        #endregion
    }

    [AddIn("New Contact Global Ribbon Button Add-In", Version="1.0.0.0")]
    public class NewContactGlobalRibbonButtonAddIn : IGlobalRibbonButton
    {
        IGlobalContext _globalContext;

        #region IGlobalRibbonButton Members

        public void Click()
        {
            _globalContext.AutomationContext.CreateWorkspaceRecord(RightNow.AddIns.Common.WorkspaceRecordType.Contact);
        }

        private bool enabled = true;

        public bool Enabled
        {
            get 
            {
                return enabled;
            }
            set
            {
                if (this.enabled != value)
                {
                    this.enabled = value;

                    if (this.EnabledChanged != null)
                    {
                        this.EnabledChanged(this, EventArgs.Empty);
                    }
                }
            }
        }

        public event EventHandler EnabledChanged;

        public string GroupName
        {
            get 
            {
                return typeof(ContactGlobalRibbonGroupAddIn).FullName;
            }
        }

        public System.Drawing.Image Image16
        {
            get 
            {
                return Properties.Resources.AddIn16;
            }
        }

        public System.Drawing.Image Image32
        {
            get 
            {
                return Properties.Resources.AddIn32;
            }
        }

        public string KeyTips
        {
            get 
            {
                return "NC";
            }
        }

        public int Order
        {
            get 
            {
                return 0;
            }
        }

        public Keys Shortcut
        {
            get 
            {
                return Keys.None;
            }
        }

        public string Text
        {
            get 
            {
                return "New Contact";
            }
        }

        public string Tooltip
        {
            get 
            {
                return "Create a new contact record";
            }
        }

        private bool visible = true;

        public bool Visible
        {
            get
            {
                return visible;
            }
            set
            {
                if (this.visible != value)
                {
                    this.visible = value;

                    if (this.VisibleChanged != null)
                    {
                        this.VisibleChanged(this, EventArgs.Empty);
                    }
                }
            }
        }

        public event EventHandler VisibleChanged;

        #endregion

        #region IAddInBase Members

        public bool Initialize(IGlobalContext context)
        {
            _globalContext = context;
            //Initialize must return true for the add-in to execute
            return true;
        }

        #endregion
    }

    [AddIn("New Task Global Ribbon Button Add-In", Version = "1.0.0.0")]
    public class NewTaskGlobalRibbonButtonAddIn : IGlobalRibbonButton
    {
        IGlobalContext _globalContext;

        #region IGlobalRibbonButton Members

        public void Click()
        {
            _globalContext.AutomationContext.CreateWorkspaceRecord(RightNow.AddIns.Common.WorkspaceRecordType.Task);
        }

        private bool enabled = true;

        public bool Enabled
        {
            get
            {
                return enabled;
            }
            set
            {
                if (this.enabled != value)
                {
                    this.enabled = value;

                    if (this.EnabledChanged != null)
                    {
                        this.EnabledChanged(this, EventArgs.Empty);
                    }
                }
            }
        }

        public event EventHandler EnabledChanged;

        public string GroupName
        {
            get
            {
                return typeof(TaskGlobalRibbonGroupAddIn).FullName;
            }
        }

        public System.Drawing.Image Image16
        {
            get
            {
                return Properties.Resources.AddinTask16;
            }
        }

        public System.Drawing.Image Image32
        {
            get
            {
                return Properties.Resources.AddinTask32;
            }
        }

        public string KeyTips
        {
            get
            {
                return "NT";
            }
        }

        public int Order
        {
            get
            {
                return 1;
            }
        }

        public Keys Shortcut
        {
            get
            {
                return Keys.None;
            }
        }

        public string Text
        {
            get
            {
                return "New Task";
            }
        }

        public string Tooltip
        {
            get
            {
                return "Create a new task record";
            }
        }

        private bool visible = true;

        public bool Visible
        {
            get
            {
                return visible;
            }
            set
            {
                if (this.visible != value)
                {
                    this.visible = value;

                    if (this.VisibleChanged != null)
                    {
                        this.VisibleChanged(this, EventArgs.Empty);
                    }
                }
            }
        }

        public event EventHandler VisibleChanged;

        #endregion

        #region IAddInBase Members

        public bool Initialize(IGlobalContext context)
        {
            _globalContext = context;
            //Initialize must return true for the add-in to execute
            return true;
        }

        #endregion
    }

    [AddIn("Existing Contact Global Ribbon Button Add-In", Version = "1.0.0.0")]
    public class ExistingContactGlobalRibbonButtonAddIn : IGlobalRibbonButton
    {
        IGlobalContext _globalContext;

        #region IGlobalRibbonButton Members

        public void Click()
        {
            _globalContext.AutomationContext.EditWorkspaceRecord(RightNow.AddIns.Common.WorkspaceRecordType.Contact, SingletonContext.cID);
        }

        private bool enabled = false;

        public bool Enabled
        {
            get
            {
                return enabled;
            }
            set
            {
                if (this.enabled != value)
                {
                    this.enabled = value;

                    if (this.EnabledChanged != null)
                    {
                        this.EnabledChanged(this, EventArgs.Empty);
                    }
                }
            }
        }

        public event EventHandler EnabledChanged;

        public string GroupName
        {
            get
            {
                return typeof(ContactGlobalRibbonGroupAddIn).FullName;
            }
        }

        public System.Drawing.Image Image16
        {
            get
            {
                return Properties.Resources.AddIn16;
            }
        }

        public System.Drawing.Image Image32
        {
            get
            {
                return Properties.Resources.AddIn32;
            }
        }

        public string KeyTips
        {
            get
            {
                return "EC";
            }
        }

        public int Order
        {
            get
            {
                return 0;
            }
        }

        public Keys Shortcut
        {
            get
            {
                return Keys.None;
            }
        }

        public string Text
        {
            get
            {
                return "Last Contact";
            }
        }

        public string Tooltip
        {
            get
            {
                return "Open last opened contact record";
            }
        }

        private bool visible = true;

        public bool Visible
        {
            get
            {
                return visible;
            }
            set
            {
                if (this.visible != value)
                {
                    this.visible = value;

                    if (this.VisibleChanged != null)
                    {
                        this.VisibleChanged(this, EventArgs.Empty);
                    }
                }
            }
        }

        public event EventHandler VisibleChanged;

        #endregion

        #region IAddInBase Members

        public bool Initialize(IGlobalContext context)
        {
            _globalContext = context;
            SingletonContext.ExistingContactGlobalRibbonButtonAddIn = this;
            //Initialize must return true for the add-in to execute
            return true;
        }

        #endregion
    }

    [AddIn("Existing Task Global Ribbon Button Add-In", Version = "1.0.0.0")]
    public class ExistingTaskGlobalRibbonButtonAddIn : IGlobalRibbonButton
    {
        IGlobalContext _globalContext;

        #region IGlobalRibbonButton Members

        public void Click()
        {
            _globalContext.AutomationContext.EditWorkspaceRecord(RightNow.AddIns.Common.WorkspaceRecordType.Task, SingletonContext.tID);
        }

        private bool enabled = false;

        public bool Enabled
        {
            get
            {
                return enabled;
            }
            set
            {
                if (this.enabled != value)
                {
                    this.enabled = value;

                    if (this.EnabledChanged != null)
                    {
                        this.EnabledChanged(this, EventArgs.Empty);
                    }
                }
            }
        }

        public event EventHandler EnabledChanged;

        public string GroupName
        {
            get
            {
                return typeof(TaskGlobalRibbonGroupAddIn).FullName;
            }
        }

        public System.Drawing.Image Image16
        {
            get
            {
                return Properties.Resources.AddinTask16;
            }
        }

        public System.Drawing.Image Image32
        {
            get
            {
                return Properties.Resources.AddinTask32;
            }
        }

        public string KeyTips
        {
            get
            {
                return "ET";
            }
        }

        public int Order
        {
            get
            {
                return 1;
            }
        }

        public Keys Shortcut
        {
            get
            {
                return Keys.None;
            }
        }

        public string Text
        {
            get
            {
                return "Last Task";
            }
        }

        public string Tooltip
        {
            get
            {
                return "Open last opened task record";
            }
        }

        private bool visible = true;

        public bool Visible
        {
            get
            {
                return visible;
            }
            set
            {
                if (this.visible != value)
                {
                    this.visible = value;

                    if (this.VisibleChanged != null)
                    {
                        this.VisibleChanged(this, EventArgs.Empty);
                    }
                }
            }
        }

        public event EventHandler VisibleChanged;

        #endregion

        #region IAddInBase Members

        public bool Initialize(IGlobalContext context)
        {
            _globalContext = context;
            SingletonContext.ExistingTaskGlobalRibbonButtonAddIn = this;
            //Initialize must return true for the add-in to execute
            return true;
        }

        #endregion
    }
}
