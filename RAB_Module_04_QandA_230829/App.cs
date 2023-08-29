#region Namespaces
using Autodesk.Revit.ApplicationServices;
using Autodesk.Revit.Attributes;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.Versioning;
using System.Windows.Markup;

#endregion

namespace RAB_Module_04_QandA_230829
{
    internal class App : IExternalApplication
    {
        public bool IsVisible;
        public static App Instance { get; private set; }

        public PushButton Button1; 
        public Result OnStartup(UIControlledApplication app)
        {
            IsVisible = true;
            Instance = this;

            // 1. Create ribbon tab
            string tabName = "My First Revit Add-in";
            try
            {
                app.CreateRibbonTab(tabName);
            }
            catch (Exception)
            {
                Debug.Print("Tab already exists.");
            }

            // 2. Create ribbon panel 
            RibbonPanel panel = Utils.CreateRibbonPanel(app, tabName, "Revit Tools");

            // 3. Create button data instances
            //PushButtonData btnData1 = Command1.GetButtonData();
            //PushButtonData btnData2 = Command2.GetButtonData();

            ButtonDataClass btnData1 = new ButtonDataClass("Toggle", "Show Elements", "RAB_Module_04_QandA_230829.Command1",
                Properties.Resources.Green_32, Properties.Resources.Green_16, "Click to hide elements");

            PushButton button1 = panel.AddItem(btnData1.Data) as PushButton;
            Button1 = button1;

            //ButtonDataClass btnData4 = new ButtonDataClass("Button 4", "Button 4", "RAB_Module_04_QandA_230829.Command1",
            //    Properties.Resources.Green_32, Properties.Resources.Green_16, "Tool Tip");

            //ButtonDataClass btnData5 = new ButtonDataClass("Button 5", "Button 5", "RAB_Module_04_QandA_230829.Command1",
            //    Properties.Resources.Green_32, Properties.Resources.Green_16, "Tool Tip");

      
            //PulldownButtonData pdb1 = new PulldownButtonData("Pulldown 1", "Pulldown 1");
            //pdb1.LargeImage = ButtonDataClass.BitmapToImageSource(Properties.Resources.Green_32);
            //pdb1.Image = ButtonDataClass.BitmapToImageSource(Properties.Resources.Green_16);
            
            //IList<RibbonItem> buttonList = panel.AddStackedItems(btnData1, btnData2, pdb1);

            //PulldownButton pd1 = buttonList[2] as PulldownButton;

            //pd1.AddPushButton(btnData3.Data);
            //pd1.AddPushButton(btnData4.Data);
            //pd1.AddPushButton(btnData5.Data);
            
            
            // NOTE:
            // To create a new tool, copy lines 35 and 39 and rename the variables to "btnData3" and "myButton3". 
            // Change the name of the tool in the arguments of line 

            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication a)
        {
            return Result.Succeeded;
        }

        public void toggle()
        {
            if (IsVisible == true)
            {
                // make hidden
                IsVisible = false;
                Button1.LargeImage = ButtonDataClass.BitmapToImageSource(Properties.Resources.Red_32);
                Button1.Image = ButtonDataClass.BitmapToImageSource(Properties.Resources.Red_16);
                Button1.ItemText = "Hide Elements";
                Button1.ToolTip = "Click to show elements";
            }
            else
            {
                // make visible
                IsVisible = true;
                Button1.LargeImage = ButtonDataClass.BitmapToImageSource(Properties.Resources.Green_32);
                Button1.Image = ButtonDataClass.BitmapToImageSource(Properties.Resources.Green_16);
                Button1.ItemText = "Show Elements";
                Button1.ToolTip = "Click to hide elements";
            }
        }


    }
}
