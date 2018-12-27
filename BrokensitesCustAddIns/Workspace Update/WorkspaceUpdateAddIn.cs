////////////////////////////////////////////////////////////////////////////////
// Author: Chris Hunter
//
// File: WorkspaceUpdateAddIn.cs
//
// Comments: Updates the ribbon Add-In with latest contact id.
//
// Notes: 
//          Must be added to contact workspace on hidden tab
//
// Pre-Conditions: 
//          1. You must have enabled add-ins for the appropriate profile
//          2. You must have uploaded the compiled .dll to the RightNow server
//
////////////////////////////////////////////////////////////////////////////////

using System;
using System.AddIn;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using RightNow.AddIns.AddInViews;

namespace BrokensitesCustAddIns.Workspace_Update
{
    public class WorkspaceUpdateComponent : IWorkspaceComponent2
    {
        private IRecordContext _recContext;
        private IContact _contactRecord;
        private ITask _taskRecord;

        public WorkspaceUpdateComponent(bool inDesignMode, IRecordContext recContext)
        {
            //You can't access the IRecordContext when in design mode
            if (inDesignMode == false)
            {
                _recContext = recContext;
                _recContext.DataLoaded += new EventHandler(wsUpdateControl_WorkspaceLoaded);
                _recContext.Closing -= wsUpdateControl_WorkspaceLoaded;
                _recContext.Saving += new System.ComponentModel.CancelEventHandler(wsUpdateControl_ContactSaving);
            }
        }

        #region IWorkspaceComponent2 Members

        public bool ReadOnly
        {
            get;
            set;
        }

        public void RuleActionInvoked(string actionName)
        {
            //Not used
        }

        public string RuleConditionInvoked(string conditionName)
        {
            //Not used
            return "";
        }

        #endregion

        #region IAddInControl Members

        public Control GetControl()
        {
            WorkspaceUpdateUserControl wsUpdateControl = new WorkspaceUpdateUserControl();

            return wsUpdateControl;
        }

        void wsUpdateControl_ContactSaving(object sender, EventArgs e)
        {
            if (_contactRecord != null)
            {
                SingletonContext.cID = _contactRecord.ID;
            }

            if (_taskRecord != null)
            {
                SingletonContext.tID = _taskRecord.ID;
            }
        }

        void wsUpdateControl_WorkspaceLoaded(object sender, EventArgs e)
        {
            _contactRecord = _recContext.GetWorkspaceRecord(RightNow.AddIns.Common.WorkspaceRecordType.Contact) as IContact;
            if (_contactRecord != null && _contactRecord.NameFirst != null && _contactRecord.NameLast != null)
            {
                SingletonContext.cID = _contactRecord.ID;
            }

            _taskRecord = _recContext.GetWorkspaceRecord(RightNow.AddIns.Common.WorkspaceRecordType.Task) as ITask;
            if (_taskRecord != null && _taskRecord.Name != null)
            {
                SingletonContext.tID = _taskRecord.ID;
            }
        }


        #endregion
    }

    [AddIn("Workspace Update Add-In", Version="1.0.0.0")]
    public class WorkspaceUpdateAddInFactory : IWorkspaceComponentFactory2
    {
        #region IWorkspaceComponentFactory2 Members

        public IWorkspaceComponent2 CreateControl(bool inDesignMode, IRecordContext context)
        {
            WorkspaceUpdateComponent workspaceComponent = new WorkspaceUpdateComponent(inDesignMode, context);

            return workspaceComponent;
        }

        #endregion

        #region IFactoryBase Members

        public System.Drawing.Image Image16
        {
            get 
            {
                return Properties.Resources.AddIn16;
            }
        }

        public string Text
        {
            get 
            {
                return "Workspace Update Add-In";
            }
        }

        public string Tooltip
        {
            get 
            {
                return "Add-In that sets a contact id for use in ribbon Add-In";
            }
        }

        #endregion

        #region IAddInBase Members

        public bool Initialize(IGlobalContext context)
        {
            //Initialize must return true for the add-in to execute
            return true;
        }

        #endregion
    }

    [AddIn("Workspace Task Update Add-In", Version = "1.0.0.0")]
    public class WorkspaceTaskUpdateAddInFactory : IWorkspaceComponentFactory2
    {
        #region IWorkspaceComponentFactory2 Members

        public IWorkspaceComponent2 CreateControl(bool inDesignMode, IRecordContext context)
        {
            WorkspaceUpdateComponent workspaceComponent = new WorkspaceUpdateComponent(inDesignMode, context);

            return workspaceComponent;
        }

        #endregion

        #region IFactoryBase Members

        public System.Drawing.Image Image16
        {
            get
            {
                return Properties.Resources.AddinTask16;
            }
        }

        public string Text
        {
            get
            {
                return "Task Workspace Update Add-In";
            }
        }

        public string Tooltip
        {
            get
            {
                return "Add-In that sets a task id for use in ribbon Add-In";
            }
        }

        #endregion

        #region IAddInBase Members

        public bool Initialize(IGlobalContext context)
        {
            //Initialize must return true for the add-in to execute
            return true;
        }

        #endregion
    }
}
