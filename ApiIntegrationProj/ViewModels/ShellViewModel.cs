using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ApiIntegrationProj.ViewModels
{
    public class ShellViewModel: Conductor<object>
    {
        public ShellViewModel() {
            ActivateItemAsync(new ComicViewModel());
        } 
        
        public void CallApi1() {
            ActivateItemAsync(new ComicViewModel());
        }

        public void CallApi2()
        {
            ActivateItemAsync(new NewsViewModel());
        }

        

    }
}
