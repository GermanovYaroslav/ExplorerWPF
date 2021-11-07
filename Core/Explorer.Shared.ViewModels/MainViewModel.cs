using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Explorer.Shared.ViewModels
{
    public class MainViewModel : BaseViewModel
    {
        #region Public Properties
        public ObservableCollection<DirectoryTabItemViewModel> DirectoryTabItems { get; set; } = new ObservableCollection<DirectoryTabItemViewModel>();

        public DirectoryTabItemViewModel CurrentDirectoryTabItem { get; set; }

        #endregion
        #region Commands





        #endregion

        #region Commands


        public DelegateCommand AddTabItemCommand { get; }



        #endregion


        #region Constuctor
        public MainViewModel()
        {
            AddTabItemCommand = new DelegateCommand(OnAddTabItem);

            AddTabItemViewModel();

            //CurrentDirectoryTabItem = DirectoryTabItems.FirstOrDefault();

        }



        #endregion


        #region Commands Methods

        private void OnAddTabItem(object obj)
        {
            AddTabItemViewModel();
        }

        #endregion

        #region Private Methods

        private void AddTabItemViewModel()
        {
            var vm = new DirectoryTabItemViewModel();
            vm.Closed += Vm_Closed;
            DirectoryTabItems.Add(vm);
            CurrentDirectoryTabItem = vm;
        }

        private void Vm_Closed(object sender, EventArgs e)
        {
            if (sender is DirectoryTabItemViewModel directoryTabItemViewModel)
            {
                CloseTab(directoryTabItemViewModel);
            }
        }

        private void CloseTab(DirectoryTabItemViewModel directoryTabItemViewModel)
        {
            directoryTabItemViewModel.Closed -= Vm_Closed;

            DirectoryTabItems.Remove(directoryTabItemViewModel);

            CurrentDirectoryTabItem = DirectoryTabItems.FirstOrDefault();
        }

        #endregion


        /*
                 <TextBox Text="{Binding FilePath}"/>

        <ListBox Grid.Row ="1"
                 ItemsSource="{Binding DirectoriesAndFile}"/>


        ///////////////////////////////////////////////////////////////



                    <TabItem Header="{Binding Name}">
                <Grid>

                    <Grid.RowDefinitions>
                        <RowDefinition Height="Auto"/>
                        <RowDefinition Height="*" />


                    </Grid.RowDefinitions>

                    <TextBox Text="{Binding FilePath}"/>

                    <ListBox Grid.Row ="1"
                 ItemsSource="{Binding DirectoriesAndFiles}"
                 SelectedItem="{Binding SelectedFileEntity}">

                        <b:Interaction.Triggers>
                            <b:EventTrigger EventName="MouseDoubleClick">
                                <b:InvokeCommandAction 
                        Command="{Binding OpenCommand}"
                        CommandParameter="{Binding SelectedFileEntity}"/>
                            </b:EventTrigger>
                        </b:Interaction.Triggers>


                        <ListBox.ItemTemplate>
                            <DataTemplate>
                                <Grid>
                                    <TextBlock Text="{Binding Name}"/>
                                </Grid>
                            </DataTemplate>
                        </ListBox.ItemTemplate>

                    </ListBox>
                </Grid>
            </TabItem>


         */


    }
}
