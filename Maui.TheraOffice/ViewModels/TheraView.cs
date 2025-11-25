using Library.WordPress.Models;
using Library.WordPress.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Maui.WordPress.ViewModels
{
    public class TheraView
    {
        public TheraView() {
            Model = new Blog();
            SetUpCommands();
        }

        public TheraView(Blog? model)
        {
            Model = model;
            SetUpCommands();
        }

        private void SetUpCommands()
        {
            DeleteCommand = new Command(DoDelete);
            EditCommand = new Command((p) => DoEdit(p as TheraView));
        }

        private void DoDelete()
        {
            if (Model?.Id > 0)
            {
                BlogServiceProxy.Current.Delete(Model.Id);
                Shell.Current.GoToAsync("//MainPage");
            }
        }

        private void DoEdit(BlogViewModel? bv)
        {
            if (bv == null)
            {
                return;
            }
            var selectedId = bv?.Model?.Id ?? 0;
            Shell.Current.GoToAsync($"//Blog?blogId={selectedId}");
        }

        public Blog? Model { get; set; }


        public ICommand? DeleteCommand { get; set; }
        public ICommand? EditCommand { get; set; }
    }
}
