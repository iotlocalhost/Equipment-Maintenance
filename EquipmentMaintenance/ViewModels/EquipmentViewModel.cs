﻿using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace EquipmentMaintenance
{
    public class EquipmentViewModel : BindableBase
    {
        public EventHandler DetailClick;

        public EquipmentViewModel() { }

        private ICommand _gotoDetailCommand;
        public ICommand GoToDetailCommand
        {
            get
            {
                if (_gotoDetailCommand == null)
                {
                    _gotoDetailCommand = new DelegateCommand(()=> {
                        this.DetailClick?.Invoke(this, EventArgs.Empty);
                    });
                }
                return _gotoDetailCommand;
            }
        }

        private ICommand _closeCommand;
        public ICommand CloseCommand
        {
            get
            {
                if (_closeCommand == null)
                {
                    _closeCommand = new DelegateCommand(() => {
                        System.Windows.Application.Current.Shutdown();
                    });
                }
                return _closeCommand;
            }
        }

        public List<MaintenanceCheckItem> CheckList { get { return _checkList; } }

        private List<MaintenanceCheckItem> _checkList = new List<MaintenanceCheckItem> {
            new MaintenanceCheckItem {
                No = 1,
                Pro1 = "電源電圧",
                Pro2 = "通電時の電圧を確認して下さい。",
                Pro3 = true,
                Pro4 = false,
            },
            new MaintenanceCheckItem {
                No = 2,
                Pro1 = "電源ランプ",
                Pro2 = "通電による電源ランプの点灯切替を確認して下さい。",
                Pro3 = true,
                Pro4 = false
            },
            new MaintenanceCheckItem {
                No = 3,
                Pro1 = "扉センサ1",
                Pro2 = "前面右扉の開放によるランプ点灯を確認して下さい。",
                Pro3 = true,
                Pro4 = false
            },
            new MaintenanceCheckItem {
                No = 4,
                Pro1 = "扉センサ2",
                Pro2 = "前面左扉の開放によるランプ点灯を確認して下さい。",
                Pro3 = false,
                Pro4 = true
            }
        };
    }
}
