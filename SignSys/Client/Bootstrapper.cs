using Prism.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Practices.Unity;
using Prism.Modularity;
using DataManager.Title;
using DataManager.Land;
using DataManager.ModifyPasswork;
using DataManager.Picture.ViewModels;
using DataManager.Picture;
using DataManager.State;
using DataManager.HistorySign;

namespace ClientProj
{
    public class Bootstrapper : UnityBootstrapper
    {
        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<Shell>();
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();

            //App.Current.MainWindow = (Window)Shell;
            App.Current.MainWindow.Show();
        }



        protected override IModuleCatalog CreateModuleCatalog()
        {
            ModuleCatalog catalog = new ModuleCatalog();


            catalog.AddModule(typeof(TitleModule));
            catalog.AddModule(typeof(LandViewModule));
            catalog.AddModule(typeof(ModifyPasswordViewModule));
            catalog.AddModule(typeof(PictureViewModule));
            catalog.AddModule(typeof(StateViewModule));
            catalog.AddModule(typeof(HistorySignViewModule));
            return catalog;
        }



        //protected override void ConfigureModuleCatalog()
        //{
        //    Type coreModuleType = typeof(LandViewModule);//{ModuleName = coreModuleType.Name ,ModuleType = coreModuleType.AssemblyQualifiedName}
        //    ModuleCatalog.AddModule(new ModuleInfo(coreModuleType.Name, coreModuleType.AssemblyQualifiedName));

        //    Type coreModuleType1 = typeof(ModifyPasswordViewModule);//{ModuleName = coreModuleType.Name ,ModuleType = coreModuleType.AssemblyQualifiedName}
        //    ModuleCatalog.AddModule(new ModuleInfo(coreModuleType1.Name, coreModuleType1.AssemblyQualifiedName));
        //    base.ConfigureModuleCatalog();
        //}
    }
}
