using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BrokensitesCustAddIns
{
    public class SingletonContext
    {
        //hold the contact id of the last opened contact record
        private static int contactID = 0;
        private static int taskID = 0;

        public static int cID
        {
            get
            {
                return contactID;
            }
            set
            {
                if (contactID != value)
                {
                    contactID = value;

                    //used to toggle the button
                    if (contactID == 0)
                    {
                        ExistingContactGlobalRibbonButtonAddIn.Enabled = false;
                    }
                    else
                    {
                        ExistingContactGlobalRibbonButtonAddIn.Enabled = true;
                    }
                }
            }
        }

        public static int tID
        {
            get
            {
                return taskID;
            }
            set
            {
                if (taskID != value)
                {
                    taskID = value;

                    //used to toggle the button
                    if (taskID == 0)
                    {
                        ExistingTaskGlobalRibbonButtonAddIn.Enabled = false;
                    }
                    else
                    {
                        ExistingTaskGlobalRibbonButtonAddIn.Enabled = true;
                    }
                }
            }
        }

        // this is used to access the Contact button that is enabled/disabled
        private static Global_Ribbon.ExistingContactGlobalRibbonButtonAddIn _existingContactGlobalRibbonButtonAddIn;
        public static Global_Ribbon.ExistingContactGlobalRibbonButtonAddIn ExistingContactGlobalRibbonButtonAddIn
        {
            get { return _existingContactGlobalRibbonButtonAddIn; }
            set { _existingContactGlobalRibbonButtonAddIn = value; }
        }

        // this is used to access the Task button that is enabled/disabled
        private static Global_Ribbon.ExistingTaskGlobalRibbonButtonAddIn _existingTaskGlobalRibbonButtonAddIn;
        public static Global_Ribbon.ExistingTaskGlobalRibbonButtonAddIn ExistingTaskGlobalRibbonButtonAddIn
        {
            get { return _existingTaskGlobalRibbonButtonAddIn; }
            set { _existingTaskGlobalRibbonButtonAddIn = value; }
        }

        private static volatile SingletonContext _instance = null;
        private static object syncRoot = new Object();

        //fyi this was in addin samples and may be needed for singleton design pattern
        private Global_Ribbon.GlobalRibbonContactTabAddIn _globalRibbonTabAddIn;
        public Global_Ribbon.GlobalRibbonContactTabAddIn GlobalRibbonTabAddIn
        {
            get { return _globalRibbonTabAddIn; }
            set { _globalRibbonTabAddIn = value; }
        }

        private SingletonContext()
        {

        }

        //Double checked locking is supported by .NET
        public static SingletonContext GetInstance()
        {
            if (_instance == null)
            {
                lock (syncRoot)
                {
                    if (_instance == null)
                    {
                        _instance = new SingletonContext();
                    }
                }
            }

            return _instance;
        }
    }
}
